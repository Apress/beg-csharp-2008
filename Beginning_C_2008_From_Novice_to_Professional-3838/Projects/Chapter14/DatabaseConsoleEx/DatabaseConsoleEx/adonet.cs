using System;
using System.Data.SqlServerCe;
using System.Data;

namespace ADONet {
    static class Tests {
        static void DoConnection() {
            IDbConnection connection = new SqlCeConnection(DatabaseConsoleEx.Properties.Settings.Default.lotteryConnectionString);
            connection.Open();
            connection.Close();
        }
        static void AddToDrawsTableParameters() {
            IDbConnection connection = new SqlCeConnection(DatabaseConsoleEx.Properties.Settings.Default.lotteryConnectionString);
            connection.Open();

            IDbCommand cmd = new SqlCeCommand(
                                 @"insert into draws (draw_date, first_number, second_number, third_number, fourth_number, " +
                                 @"fifth_number, sixth_number, bonus) values (@draw_date, @first_number, @second_number, @third_number," +
                                 @"@fourth_number,@fifth_number,@sixth_number,@bonus)");
            cmd.Connection = connection;

            cmd.Parameters.Add(new SqlCeParameter("@draw_date", DateTime.Now));
            cmd.Parameters.Add(new SqlCeParameter("@first_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@second_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@third_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@fourth_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@fifth_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@sixth_number", 1));
            cmd.Parameters.Add(new SqlCeParameter("@bonus", 1));

            int retval = cmd.ExecuteNonQuery();
            Console.WriteLine("retval (" + retval + ")");
            connection.Close();
        }

        static void AddToDrawsTable() {
            IDbConnection connection = new SqlCeConnection(DatabaseConsoleEx.Properties.Settings.Default.lotteryConnectionString);
            connection.Open();

            IDbCommand cmd = new SqlCeCommand(
                                 @"insert into draws (draw_date, first_number, second_number, third_number, fourth_number, " +
                                 @"fifth_number, sixth_number, bonus) values (?, ?, ?, ?, ?, ?, ?, ?)");
            cmd.Connection = connection;

            IDbDataParameter paramDate = new SqlCeParameter();
            paramDate.ParameterName = "@draw_date";
            paramDate.DbType = System.Data.DbType.DateTime;
            paramDate.Size = 8;
            paramDate.SourceColumn = "draw_date";
            paramDate.Value = DateTime.Now;
            cmd.Parameters.Add(paramDate);

            IDbDataParameter param = new SqlCeParameter();
            param.ParameterName = "@first_number";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "first_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@second_numer";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "second_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@third_number";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "third_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@fourth_number";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "fourth_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@fifth_number";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "fifth_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@sixth_number";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "sixth_number";
            param.Value = 1;
            cmd.Parameters.Add(param);

            param = new SqlCeParameter();
            param.ParameterName = "@bonus";
            param.DbType = System.Data.DbType.Int32;
            param.Size = 4;
            param.SourceColumn = "bonus";
            param.Value = 1;
            cmd.Parameters.Add(param);

            int retval = cmd.ExecuteNonQuery();
            Console.WriteLine("retval (" + retval + ")");
            connection.Close();
        }
        public static void SelectAll() {
            IDbConnection connection = new SqlCeConnection(DatabaseConsoleEx.Properties.Settings.Default.lotteryConnectionString);
            connection.Open();

            IDbCommand cmd = new SqlCeCommand(@"select * from draws");
            cmd.Connection = connection;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                Console.WriteLine("(" + reader.GetDateTime(0) + ") " +
                    reader.GetInt32(1) + "");
            }
            reader.Close();
            connection.Close();
        }
        public static void RunAll() {
            DoConnection();
            //AddToDrawsTable();
            //AddToDrawsTableParameters();
            SelectAll();
        }
    }
}