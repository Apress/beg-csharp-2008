using System;
using System.Collections.Generic;
using System.Text;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public static class SpreadsheetManager {

        public static IWorkbook CreateEmptyWorkbook(string identifier) {
            return new Workbook(identifier);
        }
        public static IWorksheet<DataType> CreateEmpytWorksheet<DataType>(string identifier) {
            return new Worksheet<DataType>(identifier);
        }
    }
}
