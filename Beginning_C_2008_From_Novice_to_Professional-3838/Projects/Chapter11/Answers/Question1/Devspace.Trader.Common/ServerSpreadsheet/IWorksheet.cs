using System;
using System.Collections.Generic;
using System.Text;
using Devspace.Trader.Common;
using System.Linq;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public delegate StateType CellCalculation<StateType>(IWorksheet<StateType> worksheet, int row, int col);

    public struct SheetCoordinate {
        public int Row;
        public int Column;
        public SheetCoordinate(int row, int column) {
            if (row < 0) {
                throw new ArgumentOutOfRangeException("Row is below zero");
            }
            if (column < 0) {
                throw new ArgumentOutOfRangeException("Column is below zero");
            }
            Row = row;
            Column = column;
        }
        public SheetCoordinate OneUp {
            get {
                return new SheetCoordinate(Row - 1, Column);
            }
        }
        public SheetCoordinate OneDown {
            get {
                return new SheetCoordinate(Row + 1, Column);
            }
        }
        public SheetCoordinate OneLeft {
            get {
                return new SheetCoordinate(Row, Column - 1);
            }
        }
        public SheetCoordinate OneRight {
            get {
                return new SheetCoordinate(Row, Column + 1);
            }
        }
    }

    public interface IWorksheet<StateType> : IWorksheetBase {
        void AssignColCalculation(int col, Func<IWorksheet<StateType>, int, int, StateType> cb);
        void AssignCellCalculation(int row, int col, Func<IWorksheet<StateType>, int, int, StateType> cb);
        StateType GetCellState(int row, int col);
        void SetCellState(int row, int col, StateType val);
        void AssignCellCalculation(SheetCoordinate coords, Func<IWorksheet<StateType>, int, int, StateType> cb);
        StateType GetCellState(SheetCoordinate coords);
        void SetCellState(SheetCoordinate coords, StateType val);
        void Calculate();
        void CalculateCol(int col);
        void CalculateRow(int row);
        StateType Calculate(int row, int col);
        StateType Calculate(SheetCoordinate coords);
        StateType[,] Data { get; }
    }

    public interface IWorksheetBase : IDebug {
        void Dimension(int rows, int cols);
        int MaxRows { get; }
        int MaxCols { get; }
    }
    public interface IWorksheetSerialize {
        void AssignCellState(int row, int col, object value);
        void AssignCellState<ValueType>(int row, int col, ValueType value);
    }

}
