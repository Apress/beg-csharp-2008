using System;
using Devspace.Commons.Trader.Util;
using Devspace.Trader.Common.Tracer;
using Devspace.Trader.Common.ServerSpreadsheet;

namespace Devspace.Trader.Common.Automators {
    public static class TraderCommon {
        public static DateTime ConvertFromIBDate( string buffer) {
            //GenerateOutput.Write( "Converters.ConvertFromIBDate", "Input date (" + buffer + ")");
            int year = int.Parse( buffer.Substring( 0, 4));
            int month = int.Parse( buffer.Substring( 4, 2));
            int day = int.Parse( buffer.Substring( 6, 2));
            int hour = int.Parse( buffer.Substring( 10, 2));
            int minute = int.Parse( buffer.Substring( 13, 2));
            int second = int.Parse( buffer.Substring( 16, 2));
            return new DateTime( year, month, day, hour, minute, second, 0);
        }
        public static bool ConvertFromOptionTicker( string comboticker, out string ticker, out double strike,
                                                   out string expiry, out string action) {
            string[] pieces = comboticker.Split( '_');
            
            ticker = "";
            strike = 0.0;
            expiry = "";
            action = "";
            
            if( pieces.Length != 4) {
                return false;
            }
            ticker = pieces[ 0];
            strike = double.Parse( pieces[ 1]) / 100.0;
            expiry = pieces[ 2];
            action = pieces[ 3];
            return true;
        }
        public static string ConvertToOptionTicker( string ticker, double strike, string expiry, string right) {
            return String.Format("{0}_{1}_{2}_{3}", ticker, (int)(strike * 100.0), expiry, right);
        }
        public static double CalculateHFactor(double strike, double spot, double volatility, double timeToExpiry) {
            if( strike > spot) {
                return (Math.Log(strike / spot)) / (volatility * Math.Sqrt(timeToExpiry));
            }
            else {
                return (Math.Log(strike / spot)) / (volatility * Math.Sqrt(timeToExpiry));
            }
        }
        public static int GetDaysToExpiry( string expiry) {
            DateTime expiryDate = DateTime.Now;
            
            if( expiry.CompareTo( "200705") == 0) {
                expiryDate = new DateTime( 2007, 5, 18, 0, 0, 0, 0);
            }
            else if( expiry.CompareTo( "200708") == 0) {
                expiryDate = new DateTime( 2007, 8, 17, 0, 0, 0, 0);
            }
            
            TimeSpan diff = expiryDate.Subtract( DateTime.Now);
            return (int)diff.TotalDays + 1;
        }
		public static DateTime GetUSTradingDayStart( DateTime dateToMod) {
			return new DateTime( dateToMod.Year, dateToMod.Month, dateToMod.Day, 15, 30, 0, 0);
		}
        public static DateTime GetUSTradingDayEnd(DateTime dateToMod) {
            return new DateTime(dateToMod.Year, dateToMod.Month, dateToMod.Day, 22, 0, 0, 0);
        }
    }
}

