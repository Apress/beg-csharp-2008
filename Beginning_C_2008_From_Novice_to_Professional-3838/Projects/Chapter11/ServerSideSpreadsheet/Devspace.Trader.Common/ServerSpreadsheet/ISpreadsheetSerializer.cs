using System;
using System.Collections.Generic;
using System.Text;

namespace Devspace.Trader.Common.ServerSpreadsheet {
    public interface ISpreadsheetSerializer {
        void Save(IWorkbook workbook, string path);
        void Save(string path, string worksheetIdentifier, IWorksheetBase worksheet);
        bool Load(IWorkbook workbook, string path);
        IWorksheet<DataType> LoadSheet<DataType>(string path, int rows, int cols);
    }
}
