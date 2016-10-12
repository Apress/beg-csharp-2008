using System;

namespace GeneratedCode {
    static class Tests {
        static void Connection() {
DatabaseConsoleEx.lotteryDataSet dataset = new DatabaseConsoleEx.lotteryDataSet();
DatabaseConsoleEx.lotteryDataSetTableAdapters.drawsTableAdapter table =
    new DatabaseConsoleEx.lotteryDataSetTableAdapters.drawsTableAdapter();
int count = table.Fill(dataset.draws);
Console.WriteLine("Record count is (" + dataset.draws.Count + ")(" + count + ")");
foreach (DatabaseConsoleEx.lotteryDataSet.drawsRow row in dataset.draws) {
    Console.WriteLine("Date (" + row.draw_date + ") (" + row.first_number + ")");                
}
        }
        static void AddItem() {
DatabaseConsoleEx.lotteryDataSetTableAdapters.drawsTableAdapter table =
    new DatabaseConsoleEx.lotteryDataSetTableAdapters.drawsTableAdapter();
table.Insert(DateTime.Now, 2, 2, 2, 2, 2, 2, 2);
        }
        public static void RunAll() {
            Connection();
            AddItem();
        }
    }
}