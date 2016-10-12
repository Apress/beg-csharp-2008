using System;
using System.Text;
using System.Collections;

namespace Devspace.Trader.Common.Tracer {
    public class GenerateOutput {
        public static void Write( String identifier, int[][] var) {
            Logging.Debug( "(int[][] " + identifier + "\n  (Length (" + var.Length + ")\n");
            foreach( int[] numbers in var) {
                Logging.Debug( "    Element (Length " + numbers.Length + ") (Numbers ");
                foreach( int value in numbers) {
                    Logging.Debug( "(" + value + ")");
                }
                Logging.Debug( "))\n");
            }
            Logging.Debug( "  ))\n");
        }
        public static void Write( String identifier, int[] var) {
            Logging.Debug( "(int[] " + identifier + "\n  (Length (" + var.Length + ") Numbers (");
            foreach( int value in var) {
                Logging.Debug( "(" + value + ")");
            }
            Logging.Debug( "))\n");
        }
        public static void Write( String identifier, double[] var) {
            Logging.Debug( "(double[] " + identifier + "\n  (Length (" + var.Length + ") Numbers (");
            foreach( double value in var) {
                Logging.Debug( "(" + value + ")");
            }
            Logging.Debug( "))\n");
        }
        public static void Write( String identifier, bool[] var) {
            Logging.Debug( "(int[] " + identifier + "\n  (Length (" + var.Length + ") Numbers (");
            foreach( bool value in var) {
                if( value) {
                    Logging.Debug( "(true)");
                }
                else {
                    Logging.Debug( "(false)");
                }
            }
            Logging.Debug( "))\n");
        }
        public static void Write( String identifier, IEnumerable list) {
            Logging.Debug( "(Type" + list.GetType().Name + " " + identifier + "(\n");
            foreach( Object obj in list) {
                Logging.Debug( "(" + obj.ToString() + ")");
            }
            Logging.Debug( "))\n");
        }
        public static void Write( String identifier, Object obj) {
            Logging.Debug( "(Type" + obj.GetType().Name + " " + identifier + "(\n"
                          + obj.ToString() + "))\n");
        }
        public static void Write( String identifier, String value) {
            Logging.Debug( "(String " + identifier + " (" + value + "))\n");
        }
        public static void Write( String identifier, double value) {
            Logging.Debug( "(double " + identifier + " (" + value + "))\n");
        }
        public static void Write( String identifier, int value) {
            Logging.Debug( "(int " + identifier + " (" + value + "))\n");
        }
        public static void Write( String identifier, ulong value ) {
            Logging.Debug( "(ulong " + identifier + " (" + value + "))\n" );
        }
        public static void Write( String identifier, DateTime value) {
            string buffer = "" + value.Year + "-" + value.Month + "-" + value.Day +
                " " + value.Hour + ":" + value.Minute + ":" + value.Second + " " + value.Millisecond +
                " ticks(" + value.Ticks + ")";
            Logging.Debug( "(datetime " + identifier + " (" + buffer + "))\n");
        }
        public static void WriteSingle( String identifier, double[] var) {
            string buffer = "(double[] " + identifier + "\n  (Length (" + var.Length + ") Numbers (";
            foreach( double value in var) {
                buffer += "(" + value + ")";
            }
            buffer += "))\n";
            Logging.Debug( buffer);
        }
        public static void Write( String buffer) {
            Logging.Debug( buffer + "\n");
        }
    }}
