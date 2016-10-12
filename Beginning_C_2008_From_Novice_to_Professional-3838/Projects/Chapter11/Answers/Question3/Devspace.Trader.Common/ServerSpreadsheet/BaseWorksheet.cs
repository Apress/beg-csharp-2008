using System;
using System.Collections.Generic;
using System.Text;
using Devspace.Trader.Common.Automators;
using System.Linq;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public abstract class BaseWorksheet< StateType> : TraderBaseClass {
        protected IWorksheet<StateType> _worksheet;
        public BaseWorksheet(IWorksheet< StateType> worksheet) {
            _worksheet = worksheet;
        }
        public void Dimension(int rows, int cols) {
            _worksheet.Dimension(rows, cols);
        }
        public void AssignColCalculation(int col, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            _worksheet.AssignColCalculation(col, cb);
        }
        public void AssignCellCalculation(int row, int col, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            _worksheet.AssignCellCalculation(row, col, cb);
        }
        public StateType GetCellState(int row, int col) {
            return _worksheet.GetCellState(row, col);
        }
        public void SetCellState(int row, int col, StateType val) {
            _worksheet.SetCellState(row, col, val);
        }
        public void AssignCellCalculation(SheetCoordinate coords, Func<IWorksheet<StateType>, int, int, StateType> cb) {
            _worksheet.AssignCellCalculation(coords.Row, coords.Column, cb);
        }

        public StateType GetCellState(SheetCoordinate coords) {
            return _worksheet.GetCellState(coords.Row, coords.Column);
        }
        public void SetCellState(SheetCoordinate coords, StateType val) {
            _worksheet.SetCellState(coords.Row, coords.Column, val);
        }
        public virtual void Calculate() {
            _worksheet.Calculate();
        }
        public IWorksheet<StateType> Worksheet {
            get {
                return _worksheet;
            }
        }
        public override string ToString() {
            return _worksheet.ToString();
        }
    }
}
