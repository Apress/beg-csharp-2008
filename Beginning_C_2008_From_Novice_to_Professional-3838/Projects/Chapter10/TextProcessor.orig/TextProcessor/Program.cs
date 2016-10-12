using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TextProcessor {
    public static class Program {
        /*[STAThread]
        static void Main(string[] args) {
            string currentLine = Console.In.ReadLine();
            while (currentLine != null) {
                Console.WriteLine(currentLine);
                currentLine = Console.In.ReadLine();
            }
        }*/

        static void Main(string[] args) {
            Console.WriteLine("hello");
            //Stream input = Console.OpenStandardInput();
            //StreamReader sr = new StreamReader(input);
            TextReader sr = Console.In;
            string buffer = sr.ReadToEnd();
            if (buffer.Length > 0) {
                Console.Out.WriteLine(buffer);
                Console.Out.WriteLine("Found something");
                //Console.Out.WriteLine("Found something");
            }
            else {
                Console.Out.WriteLine("Found nothing");
                //Console.Out.WriteLine("Found nothing");
            }
        }
    }
}
