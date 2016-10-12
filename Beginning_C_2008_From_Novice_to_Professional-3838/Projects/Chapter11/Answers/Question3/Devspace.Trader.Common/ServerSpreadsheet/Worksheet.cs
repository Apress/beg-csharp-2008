using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Linq;
using Devspace.Trader.Common.Automators;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public interface IGrowthAlgorithm {
        int GrowRows(int currMax, int desired);
        int GrowColumns(int currMax, int desired);
    }

    // A Growth algorithm that grows an automatic 30%
    class GrowthAlgorithm : IGrowthAlgorithm {
        private const double GrowthRowFactor = 1.3;
        private const double GrowthColumnFactor = 1.2;

        #region IGrowthAlgorithm Members

        public int GrowRows(int currMax, int desired) {
            int newRowCount = (int)((double)currMax * GrowthRowFactor);

            if (newRowCount < desired) {
                newRowCount = desired + 100;
            }
            return newRowCount;
        }

        public int GrowColumns(int currMax, int desired) {
            int newColCount = (int)((double)currMax * GrowthColumnFactor);

            if (newColCount < desired) {
                newColCount = desired + 5;
            }
            return newColCount;
        }

        #endregion
    }
    class Worksheet<StateType> : TraderBaseClass, IWorksheet<StateType>, IWorksheetSerialize {
        StateType[,] CellState;
        Func<IWorksheet<StateType>, int, int, StateType>[,] Cells;
        Func<IWorksheet<StateType>, int, int, StateType>[] ColCells;
        int[,] CalculationVersion;
        int CurrVersion;
        int _maxRows;
        int _maxCols;
        readonly IGrowthAlgorithm _growthAlgorithm;

        string _identifier;
        public Worksheet() {
            _growthAlgorithm = new GrowthAlgorithm();
        }
        public Worksheet(string identifier) : this() {
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

        private void ReallocateIfNecessary(int row, int col) {
            bool didChange = false;
            int newRowCount = _maxRows;
            int newColCount = _maxCols;

            if (row > _maxRows) {
                newRowCount = _growthAlgorithm.GrowRows(_maxRows, row);
                didChange = true;
            }
            if (col > _maxCols) {
                newColCount = _growthAlgorithm.GrowColumns(_maxCols, col);
                didChange = true;
            }
            if (didChange) {
                StateType[,] oldCellState = CellState;
                Func<IWorksheet<StateType>, int, int, StateType>[,] oldCells = Cells;
                int[,] oldCalculationVersion = CalculationVersion;
                Func<IWorksheet<StateType>, int, int, StateType>[] oldColCells = ColCells;
                int oldMaxRows = _maxRows;
                int oldMaxCols = _maxCols;

                Dimension(newRowCount, newColCount);

                if (oldCellState != null) {
                    for (int iterRow = 0; iterRow < oldMaxRows; iterRow++) {
                        for (int iterCol = 0; iterCol < oldMaxCols; iterCol++) {
                            CellState[iterRow, iterCol] = oldCellState[iterRow, iterCol];
                        }
                    }
                }
                if (oldCells != null) {
                    for (int iterRow = 0; iterRow < oldMaxRows; iterRow++) {
                        for (int iterCol = 0; iterCol < oldMaxCols; iterCol++) {
                            oldCells[iterRow, iterCol] = Cells[iterRow, iterCol];
                        }
                    }
                }
                if (oldCalculationVersion != null) {
                    for (int iterRow = 0; iterRow < oldMaxRows; iterRow++) {
                        for (int iterCol = 0; iterCol < oldMaxCols; iterCol++) {
                            oldCalculationVersion[iterRow, iterCol] = CalculationVersion[iterRow, iterCol];
                        }
                    }
                }
                if (oldColCells != null) {
                    for (int iterCol = 0; iterCol < oldMaxCols; iterCol++) {
                        oldColCells[ iterCol] = ColCells[iterCol];
                    }
                }
            }
        }
        public void AssignCellState(int row, int col, object value) {
            ReallocateIfNecessary(row, col);
            CellState[row, col] = (StateType)value;
        }
        public void AssignCellState<ValueType>(int row, int col, ValueType value) {
            ReallocateIfNecessary(row, col);
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
            ReallocateIfNecessary(row, col);
            Cells[row, col] = cb;
        }
        // You should combine the two so that whenever you retrieve the lastest state
        // it will be calculated if necessary
        public StateType GetCellState(int row, int col) {
            ReallocateIfNecessary(row, col);
            if (CurrVersion > CalculationVersion[row, col]) {
                if (Cells[row, col] != null) {
                    CellState[row, col] = Cells[row, col](this, row, col);
                }
                CalculationVersion[row, col] = CurrVersion;
            }
            return CellState[row, col];
        }
        public void SetCellState(int row, int col, StateType val) {
            ReallocateIfNecessary(row, col);
            CellState[row, col] = val;
            Cells[row, col] = null;
        }
        public void AssignCellCalculation(SheetCoordinate coords, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            AssignCellCalculation(coords.Row, coords.Column, cb);
        }
        public void AssignColCalculation(int col, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            ReallocateIfNecessary(_maxRows, col);
            ColCells[col] = cb;
        }
        public StateType GetCellState(SheetCoordinate coords) {
            return GetCellState(coords.Row, coords.Column);
        }
        public void SetCellState(SheetCoordinate coords, StateType val) {
            SetCellState(coords.Row, coords.Column, val);
        }
        public void Calculate() {
            CurrVersion++;
            for (int row = 0; row < Cells.GetLength(0); row++) {
                for (int col = 0; col < Cells.GetLength(1); col++) {
                    if (Cells[row, col] != null) {
                        GetCellState(row, col);
                    }
                }
            }
        }
        public void CalculateRow(int row) {
            CurrVersion++;
            for (int col = 0; col < Cells.GetLength(1); col++) {
                if (Cells[row, col] != null) {
                    GetCellState(row, col);
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
