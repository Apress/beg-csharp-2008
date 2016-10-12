using System;
using System.Collections.Generic;
using System.Linq;


namespace Spreadsheets {
class Spreadsheet {
    public Func<object>[,] Cells;
    public object[,] State;
    public Spreadsheet() {
        Cells = new Func<object>[10, 10];
        State = new object[10, 10];
    }
    public void Execute() {
        Console.WriteLine("Rows (" + Cells.GetLength(0) + ") Cols (" + Cells.GetLength(1) + ")");
        for (int col = 0; col < Cells.GetLength(1); col++) {
            for (int row = 0; row < Cells.GetLength(0); row++) {
                if (Cells[col, row] != null) {
                    State[col, row] = Cells[col, row]();
                }
            }
        }
    }
        public void Display() {
            for (int col = 0; col < Cells.GetLength(1); col++) {
                for (int row = 0; row < Cells.GetLength(0); row++) {
                    if (Cells[col, row] != null) {
                        Console.WriteLine("Row (" + row + ") Col (" + col + ") Value (" + State[col, row].ToString() + ")");
                    }
                }
            }
        }
    }
static class CellFactories {
    public static Func<object> DoAdd(Func<object> cell1, Func<object> cell2) {
        return () => (double)cell1() + (double)cell2();
    }
    public static Func<object> DoMultiply(Func<object> cell1, Func<object> cell2) {
        return () => (double)cell1() * (double)cell2();
    }
    public static Func<object> Static(object value) {
        return () => value;
    }
}

    static class Tests {
        public static void RunAll() {
Spreadsheet spreadsheet = new Spreadsheet();

spreadsheet.Cells[1, 0] = CellFactories.Static(10.0);
spreadsheet.Cells[0, 1] = CellFactories.Static(10.0);
spreadsheet.Cells[1, 2] = CellFactories.DoAdd(spreadsheet.Cells[1, 0], spreadsheet.Cells[0, 1]);
spreadsheet.Cells[2, 2] = CellFactories.DoMultiply(spreadsheet.Cells[1, 2],
    CellFactories.Static(2.0));
spreadsheet.Execute();

spreadsheet.Display();
        }
    }
}