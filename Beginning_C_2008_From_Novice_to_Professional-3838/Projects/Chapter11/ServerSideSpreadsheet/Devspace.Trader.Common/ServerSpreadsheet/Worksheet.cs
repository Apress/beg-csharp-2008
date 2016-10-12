using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;
using Devspace.Trader.Common.Automators;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    class Worksheet<StateType> : TraderBaseClass, IWorksheet<StateType>, IWorksheetSerialize {
        StateType[,] CellState;
        Func<IWorksheet<StateType>, int, int, StateType>[,] Cells;
        Func<IWorksheet<StateType>, int, int, StateType>[] ColCells;
        int[,] CalculationVersion;
        int CurrVersion;
        int _maxRows;
        int _maxCols;

        string _identifier;
        public Worksheet() {
        }
        public Worksheet(string identifier) {
            _identifier = identifier;
        }
        public void Dimension(int rows, int cols) {
            CellState = new StateType[rows, cols];
            Cells = new Func<IWorksheet<StateType>, int, int, StateType>[rows, cols];
            CalculationVersion = new int[rows, cols];
            ColCells = new Func<IWorksheet<StateType>, int, int, StateType>[cols];
            CurrVersion = 0;
            _maxRows = rows;
            _maxCols = cols;
        }

        public int MaxRows {
            get {
                return _maxRows;
            }
        }
        public int MaxCols {
            get {
                return _maxCols;
            }
        }
        public StateType[,] Data {
            get {
                return CellState;
            }
        }
        public void AssignCellState(int row, int col, object value) {
            CellState[row, col] = (StateType)value;
        }
public void AssignCellState<ValueType>(int row, int col, ValueType value) {
    if (typeof(StateType).IsAssignableFrom(typeof(ValueType))) {
        CellState[row, col] = (StateType)(object)value;
    }
    else if (value is string && typeof(double).IsAssignableFrom(typeof(StateType))) {
        CellState[row, col] = (StateType)(object)double.Parse((string)(object)value);
    }
    else {
        throw new InvalidCastException("Could not perform conversion");
    }
}
        public void AssignCellCalculation(int row, int col, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            Cells[row, col] = cb;
        }
        public StateType GetCellState(int row, int col) {
            return CellState[row, col];
        }
        public void SetCellState(int row, int col, StateType val) {
            CellState[row, col] = val;
            Cells[row, col] = null;
        }
        public void AssignCellCalculation(SheetCoordinate coords, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            AssignCellCalculation(coords.Row, coords.Column, cb);
        }
        public void AssignColCalculation(int col, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            ColCells[col] = cb;
        }
        public StateType GetCellState(SheetCoordinate coords) {
            return GetCellState(coords.Row, coords.Column);
        }
        public void SetCellState(SheetCoordinate coords, StateType val) {
            SetCellState(coords.Row, coords.Column, val);
        }
        public StateType Calculate(int row, int col) {
            if (CurrVersion > CalculationVersion[row, col]) {
                CellState[row, col] = Cells[row, col](this, row, col);
                CalculationVersion[row, col] = CurrVersion;
            }
            return CellState[row, col];
        }
        public StateType Calculate(SheetCoordinate coords) {
            return Calculate(coords.Row, coords.Column);
        }
        public void Calculate() {
            CurrVersion++;
            for (int row = 0; row < Cells.GetLength(0); row++) {
                for (int col = 0; col < Cells.GetLength(1); col++) {
                    if (Cells[row, col] != null) {
                        Calculate(row, col);
                    }
                }
            }
        }
        public void CalculateRow(int row) {
            CurrVersion++;
            for (int col = 0; col < Cells.GetLength(1); col++) {
                if (Cells[row, col] != null) {
                    Calculate(row, col);
                }
            }
        }
        public void CalculateCol(int col) {
            CurrVersion++;
            if (ColCells[col] == null) {
                return;
            }
            for (int row = 0; row < Cells.GetLength(0); row++) {
                CellState[row, col] = ColCells[col](this, row, col);
            }
        }
        bool _generateRowCounter;
        public bool GenerateRowCounter {
            get {
                return _generateRowCounter;
            }
            set {
                _generateRowCounter = value;
            }
        }
        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            for (int row = 0; row < Cells.GetLength(0); row++) {
                bool needComma = false;
                if (_generateRowCounter) {
                    needComma = true;
                    builder.Append(row);
                }
                for (int col = 0; col < Cells.GetLength(1); col++) {
                    if (needComma) {
                        builder.Append(",");
                    }
                    else {
                        needComma = true;
                    }
                    if (CellState[row, col] != null) {
                        builder.Append(CellState[row, col].ToString());
                    }
                }
                builder.Append("\n");
            }
            return builder.ToString();
        }
    }
}
