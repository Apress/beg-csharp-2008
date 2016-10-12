//#define DEBUG_OUTPUT
using System;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public static class Bootstrap {
        public static void DisplayHelp() {
            Console.WriteLine("You need help? Right now?");
        }
        public static void Process(string[] args, IProcessor processor) {
            TextReader reader = null;
            TextWriter writer = null;
            if (args.Length == 0) {
                reader = Console.In;
                writer = Console.Out;
            }
            else if (args.Length == 1) {
                if( args[ 0] == "-help") {
                    DisplayHelp();
                    return;
                }
                else {
                    reader = File.OpenText(args[0]);
                    writer = Console.Out;
                }
            }
            else if (args.Length == 2) {
                if (args[0] == "-out") {
                    reader = Console.In;
                    writer = File.CreateText(args[1]);
                }
                else {
                    DisplayHelp();
                    return;
                }
            }
            else if (args.Length == 3) {
                if (args[0] == "-out") {
                    reader = File.OpenText(args[2]);
                    writer = File.CreateText(args[1]);
                }
                else {
                    DisplayHelp();
                    return;
                }
            }
            else {
                DisplayHelp();
                return;
            }
            writer.Write(processor.Process( reader.ReadToEnd()));
#if DEBUG_OUTPUT
            Console.WriteLine("Argument count(" + args.Length + ")");
            foreach( string argument in args) {
                Console.WriteLine( "Argument (" + argument + ")");
            }
#endif
        }
    }
}
