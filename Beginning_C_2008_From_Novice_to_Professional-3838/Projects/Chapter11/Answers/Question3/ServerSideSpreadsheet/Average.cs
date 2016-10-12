using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Devspace.Trader.Common.ServerSpreadsheet;

namespace ServerSideSpreadsheet {
    public static class AverageIdentifiers {
        public const string Identifier = "average";
    }

    public class Average : BaseWorksheet<double> {
        public Average(IWorksheet<double> worksheet) : base(worksheet) { }

        public void AddItems(double[] items) {
            Dimension(items.Length + 10, 3);
            for (int row = 0; row < items.Length; row++) {
                SetCellState(row, 0, items[row]);
            }

            AssignCellCalculation(items.Length, 0,
                    (IWorksheet<double> worksheet, int cellRow, int cellCol) => {
                        double runningTotal = 0.0;
                        for (int row = 0; row < cellRow; row++) {
                            runningTotal += worksheet.GetCellState(row, 0);
                        }
                        return runningTotal / cellRow;
                    });
            for (int row = 0; row < items.Length; row++) {
                AssignCellCalculation(row, 1,
                    (worksheet, cellRow, cellCol) => {
                        return worksheet.GetCellState(cellRow, 0) - worksheet.GetCellState(items.Length, 0);
                    }
                );
            }
        }
    }
}
