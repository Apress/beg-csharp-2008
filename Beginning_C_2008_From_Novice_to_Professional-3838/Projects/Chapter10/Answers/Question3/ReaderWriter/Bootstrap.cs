//#define DEBUG_OUTPUT
using System;
using System.Text;
using System.IO;

namespace ReaderWriter {
    public static class Bootstrap {
        public static void DisplayHelp( string[] args, IProcessor processor) {
            Console.WriteLine("This application is used to input and output text and has the following options");
            Console.WriteLine("-help: displays this message");
            Console.WriteLine("-out: defines where the generated data is saved, otherwise output to console");
            Console.WriteLine("General usage is:");
            Console.WriteLine("[app.exe] [-out filename] [filename]");
            IDisplayHelp help = processor as IDisplayHelp;
            if (help != null) {
                Console.WriteLine(help.DisplayHelp(args));
            }
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
                    DisplayHelp(args,processor);
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
                    DisplayHelp(args, processor);
                    return;
                }
            }
            else if (args.Length == 3) {
                if (args[0] == "-out") {
                    reader = File.OpenText(args[2]);
                    writer = File.CreateText(args[1]);
                }
                else {
                    DisplayHelp(args, processor);
                    return;
                }
            }
            else {
                DisplayHelp(args, processor);
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
