using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public static class Text2BinaryBootstrap {
        public static void DisplayHelp() {
            Console.WriteLine("You need help? Right now?");
        }
        public static void Process(string[] args, IText2BinaryProcessor processor) {
            TextReader reader = null;
            Stream writer = null;
            if (args.Length == 0) {
                reader = Console.In;
                writer = Console.OpenStandardOutput();
            }
            else if (args.Length == 1) {
                if (args[0] == "-help") {
                    DisplayHelp();
                    return;
                }
                else {
                    reader = File.OpenText(args[0]);
                    writer = Console.OpenStandardOutput();
                }
            }
            else if (args.Length == 2) {
                if (args[0] == "-out") {
                    reader = Console.In;
                    writer = File.Open(args[1], FileMode.Create);
                }
                else {
                    DisplayHelp();
                    return;
                }
            }
            else if (args.Length == 3) {
                if (args[0] == "-out") {
                    reader = File.OpenText(args[2]);
                    writer = File.Open(args[1], FileMode.Create);
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
            processor.Process(reader, writer);
            writer.Close();
#if DEBUG_OUTPUT
            Console.WriteLine("Argument count(" + args.Length + ")");
            foreach( string argument in args) {
                Console.WriteLine( "Argument (" + argument + ")");
            }
#endif
        }

    }
}
