using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerSideSpreadsheet;
using Devspace.Trader.Common.ServerSpreadsheet;

namespace TestServerSideSpreadsheets {
    static class TestAverage {
        static void TestWorksheet() {
            Average average = new Average(SpreadsheetManager.CreateEmpytWorksheet<double>(AverageIdentifiers.Identifier));
            average.AddItems(new double[] { 1.0, 2.0, 3.0 });
            Console.WriteLine(average.ToString());
            average.Calculate();
            Console.WriteLine(average.ToString());
        }
        static void TestWorkbookRaw() {
            IWorksheet<double> sheetAverage = SpreadsheetManager.CreateEmpytWorksheet<double>("");
            double[] items = new double[] { 1.0, 2.0, 3.0 };
            sheetAverage.Dimension(items.Length + 10, 3);
            for (int row = 0; row < items.Length; row++) {
                sheetAverage.SetCellState(row, 0, items[row]);
            }

            int columnToAverage = 0;
            int startRow = 0;
            int endRow = items.Length;

            sheetAverage.AssignCellCalculation(items.Length, 0,
                    (IWorksheet<double> worksheet, int cellRow, int cellCol) => {
                        double runningTotal = 0.0;
                        for (int row = startRow; row < endRow; row++) {
                            runningTotal += worksheet.GetCellState(row, columnToAverage);
                        }
                        return runningTotal / (endRow - startRow);
                    });
            for (int row = 0; row < items.Length; row++) {
                sheetAverage.AssignCellCalculation(row, 1,
                    (worksheet, cellRow, cellCol) => {
                        return worksheet.GetCellState(cellRow, 0) - worksheet.GetCellState(items.Length, 0);
                    }
                );
            }
            sheetAverage.Calculate();
            Console.WriteLine(sheetAverage.ToString());
        }
        static void TestWorkbook() {
            IWorkbook workbook = SpreadsheetManager.CreateEmptyWorkbook("example");
            IWorksheet<double> sheetAverage = workbook.GetSheet<double>(AverageIdentifiers.Identifier);
            Average average = new Average(sheetAverage);
            average.AddItems(new double[] { 1.0, 2.0, 3.0 });
            Console.WriteLine(average.ToString());
            average.Calculate();
            Console.WriteLine(average.ToString());
            Console.WriteLine("Workbook contents (" + workbook.ToString() + ")");
        }
        static void TestConversion() {
            IWorksheetBase sheetBase = SpreadsheetManager.CreateEmpytWorksheet<double>("");
            sheetBase.Dimension(10, 10);
            IWorksheetSerialize sheet = sheetBase as IWorksheetSerialize;
            sheet.AssignCellState(0, 0, "10.0");
            Console.WriteLine(sheet.ToString());
        }
        static void TestWorkbookDynamic() {
            IWorksheet<double> sheet = SpreadsheetManager.CreateEmpytWorksheet<double>("");

            sheet.SetCellState(5, 5, 10.0);
            sheet.SetCellState(200, 200, 20);

            if (sheet.GetCellState(5, 5) != 10.0) {
                Console.WriteLine("oops 5,5 is not the right number");
            }
            if( sheet.GetCellState( 200, 200) != 20.0) {
                Console.WriteLine( "oops 200, 200 is not the right number");
            }
        }
        public static void RunAll() {
            //TestWorksheet();
            //TestWorkbook();
            //TestConversion();
            //TestWorkbookRaw();
            TestWorkbookDynamic();
        }
    }
}
