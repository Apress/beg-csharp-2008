using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public static class Binary2TextBootstrap {
        public static void DisplayHelp() {
            Console.WriteLine("You need help? Right now?");
        }
        public static void Process(string[] args, IBinary2TextProcessor processor) {
            Stream reader = null;
            TextWriter writer = null;
            if (args.Length == 0) {
                reader = Console.OpenStandardInput();
                writer = Console.Out;
            }
            else if (args.Length == 1) {
                if (args[0] == "-help") {
                    DisplayHelp();
                    return;
                }
                else {
                    reader = new FileStream(args[0], FileMode.Open);
                    writer = Console.Out;
                }
            }
            else if (args.Length == 2) {
                if (args[0] == "-out") {
                    reader = Console.OpenStandardInput();
                    writer = File.CreateText(args[1]);
                }
                else {
                    DisplayHelp();
                    return;
                }
            }
            else if (args.Length == 3) {
                if (args[0] == "-out") {
                    reader = File.Open(args[2], FileMode.Open);
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
            if (processor is IBinary2TextProcessorExtended) {
                writer.Write(((IBinary2TextProcessorExtended)processor).Initialize());
            }

            processor.Process(reader, writer);
            if (processor is IBinary2TextProcessorExtended) {
                writer.Write(((IBinary2TextProcessorExtended)processor).Finalize());
            }

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
