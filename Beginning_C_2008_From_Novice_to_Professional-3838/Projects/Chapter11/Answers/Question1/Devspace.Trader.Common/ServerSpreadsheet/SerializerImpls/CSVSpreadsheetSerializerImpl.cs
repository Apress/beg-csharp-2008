using System;
using System.Collections.Generic;
using System.Text;
using LumenWorks.Framework.IO.Csv;
using System.IO;
using Devspace.Trader.Common.Automators;
using Devspace.Trader.Common.Tracer;
using System.Reflection;

namespace Devspace.Trader.Common.ServerSpreadsheet.SerializerImpls {
    class CSVSpreadsheetSerializerImpl : TraderBaseClass, ISpreadsheetSerializer {
        public void Save(IWorkbook workbook, string path) {
            StringBuilder builder = new StringBuilder();
            Directory.CreateDirectory(path);
            foreach (string identifier in ((IEnumerable<string>)workbook)) {
                builder.Append(identifier);
                builder.Append(",");
                IWorksheetBase worksheet = workbook[identifier] as IWorksheetBase;
                builder.Append("\"" + worksheet.GetType().AssemblyQualifiedName + "\"");
                builder.Append(",");
                builder.Append(worksheet.MaxRows);
                builder.Append(",");
                builder.Append(worksheet.MaxCols);
                builder.Append("\n");

                string worksheetpath = path + @"\" + identifier.ToString() + ".csv";
                StreamWriter sheetWriter = File.CreateText(worksheetpath);
                sheetWriter.Write(worksheet.ToString());
                sheetWriter.Close();
            }
            string workbookpath = path + @"\workbook.csv";
            StreamWriter fwriter = File.CreateText(workbookpath);
            fwriter.Write(builder.ToString());
            fwriter.Close();
        }

        public void Save(string path, string worksheetIdentifier, IWorksheetBase worksheet) {
            StringBuilder builder = new StringBuilder();
            Directory.CreateDirectory(path);

            string worksheetpath = path + @"\" + worksheetIdentifier.ToString() + ".csv";
            StreamWriter sheetWriter = File.CreateText(worksheetpath);
            sheetWriter.Write(worksheet.ToString());
            sheetWriter.Close();
        }

        void LoadSheet(string typeToIstantiate, string path, string identifier, IWorksheetBase sheet) {
            string[] baseType = typeToIstantiate.Split(new string[] { "[[", "]]" }, StringSplitOptions.None);
            if (baseType.Length == 0) {
                throw new Exception("There is no base type which cannot be");
            }
            if (Debug) {
                foreach (string str in baseType) {
                    GenerateOutput.Write("Workbook.Load", "basetype(" + str + ")");
                }
            }
            IWorksheetSerialize sheetSerialize = sheet as IWorksheetSerialize;
            Type celltype = Type.GetType(baseType[1]);
            string worksheetpath = path + @"\" + identifier.ToString() + ".csv";
            Type[] paramTypes = new Type[] { typeof(string) };
            MethodInfo theMethod = celltype.GetMethod("Parse", paramTypes);

            using (CsvReader csv =
                      new CsvReader(new StreamReader(worksheetpath), false)) {
                int totalColumns = csv.FieldCount;
                int rowCount = 0;
                while (csv.ReadNextRecord()) {
                    for (int colCount = 0; colCount < totalColumns; colCount++) {
                        Object[] objs = new Object[1];
                        objs[0] = csv[colCount];

                        if (theMethod == null) {
                            if (celltype.IsEnum) {
                                object val = Enum.Parse(celltype, csv[colCount]);
                                sheetSerialize.AssignCellState(rowCount, colCount, val);
                            }
                            else if (celltype.FullName == "System.Object") {
                                sheetSerialize.AssignCellState(rowCount, colCount, csv[colCount]);
                            }
                            else {
                                throw new NotSupportedException("Cell type (" + celltype.AssemblyQualifiedName + ") not supported");
                            }
                        }
                        else {
                            object retval = theMethod.Invoke(null, objs);
                            sheetSerialize.AssignCellState(rowCount, colCount, retval);
                        }
                    }
                    rowCount++;
                }
            }
        }
        public bool Load(IWorkbook workbook, string path) {
            if (!Directory.Exists(path)) {
                return false;
            }
            string workbookpath = path + @"\workbook.csv";
            using (CsvReader csv =
                      new CsvReader(new StreamReader(workbookpath), false)) {
                int fieldCount = csv.FieldCount;

                while (csv.ReadNextRecord()) {
                    string identifier = csv[0];
                    string typeToIstantiate = csv[1];
                    Type retrievedType = Type.GetType(typeToIstantiate);
                    IWorksheetBase sheet = Activator.CreateInstance(retrievedType) as IWorksheetBase;
                    int rows = int.Parse(csv[2]);
                    int cols = int.Parse(csv[3]);
                    sheet.Dimension(rows, cols);
                    LoadSheet(typeToIstantiate, path, identifier, sheet);
                    workbook[identifier] = sheet;
                    if (Debug) {
                        for (int i = 0; i < fieldCount; i++) {
                            GenerateOutput.Write("Workbook.Load", "Field (" + csv[i] + ")");
                        }
                        GenerateOutput.Write("Workbook.Load", "Sheet(\n" + sheet.ToString() + ")");
                    }
                }
            }
            return true;
        }

        public IWorksheet<DataType> LoadSheet<DataType>(string path, int rows, int cols) {
            IWorksheet<DataType> sheet = new Worksheet<DataType>();
            sheet.Dimension(rows, cols);
            Type celltype = typeof(DataType);
            Type[] paramTypes = new Type[] { typeof(string) };
            MethodInfo theMethod = celltype.GetMethod("Parse", paramTypes);
            IWorksheetSerialize sheetSerialize = sheet as IWorksheetSerialize;

            using (CsvReader csv =
                      new CsvReader(new StreamReader(path), false)) {
                int totalColumns = csv.FieldCount;
                int rowCount = 0;
                while (csv.ReadNextRecord()) {
                    int colCount = 0;
                    for (; colCount < totalColumns; colCount++) {
                        Object[] objs = new Object[1];
                        objs[0] = csv[colCount];

                        if (theMethod == null) {
                            if (celltype.IsEnum) {
                                object val = Enum.Parse(celltype, csv[colCount]);
                                sheetSerialize.AssignCellState(rowCount, colCount, val);
                            }
                            else if (celltype.FullName == "System.Object") {
                                sheetSerialize.AssignCellState(rowCount, colCount, csv[colCount]);
                            }
                            else {
                                throw new NotSupportedException("Cell type (" + celltype.AssemblyQualifiedName + ") not supported");
                            }
                        }
                        else {
                            object retval = theMethod.Invoke(null, objs);
                            sheetSerialize.AssignCellState(rowCount, colCount, retval);
                        }
                    }
                    rowCount++;
                }
            }
            return sheet;
        }

    }
}
