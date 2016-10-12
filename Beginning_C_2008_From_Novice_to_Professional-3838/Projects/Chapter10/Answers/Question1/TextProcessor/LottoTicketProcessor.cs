using System;
using System.Text;
using ReaderWriter;
using System.IO;
using System.Collections.Generic;

namespace TextProcessor {
    class LottoTicketProcessor : IProcessor {
        IList<string> _dates = new List<string>();

        public string Process(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                if (_dates.Contains(splitUpText[0])) {
                    continue;
                }
                if (splitUpText[0].Length == 0) {
                    continue;
                }
                if (splitUpText[0].Contains("-")) {
                    string[] dateSplit = splitUpText[0].Split('-');
                    string newDate = dateSplit[0] + "." + dateSplit[1] + "." + dateSplit[2];
                    if (_dates.Contains(newDate)) {
                        continue;
                    }
                    _dates.Add(newDate);
                    retval.Append(newDate);
                    for (int c1 = 1; c1 < 8; c1++) {
                        retval.Append(" " + splitUpText[c1]);
                    }
                }
                else {
                    _dates.Add(splitUpText[0]);
                    retval.Append(lineOfText);
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
        public string Process01(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                for (int c1 = 0; c1 < splitUpText.Length; c1++) {
                    retval.Append("(" + splitUpText[c1] + ")");
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
        public string Process02(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                if (splitUpText[0].Length == 0) {
                    continue;
                }
                for (int c1 = 0; c1 < splitUpText.Length; c1++) {
                    retval.Append("(" + splitUpText[c1] + ")");
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
        public string Process03(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                if (splitUpText[0].Length == 0) {
                    continue;
                }
                if (splitUpText[0].Contains("-")) {
                    string[] dateSplit = splitUpText[0].Split('-');
                    string newDate = dateSplit[0] + "." + dateSplit[1] + "." + dateSplit[2];
                    retval.Append("(" + newDate + ")");
                    for (int c1 = 1; c1 < splitUpText.Length; c1++) {
                        retval.Append("(" + splitUpText[c1] + ")");
                    }
                }
                else {
                    for (int c1 = 0; c1 < splitUpText.Length; c1++) {
                        retval.Append("(" + splitUpText[c1] + ")");
                    }
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
        public string Process04(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                if (splitUpText[0].Length == 0) {
                    continue;
                }
                if (splitUpText[0].Contains("-")) {
                    string[] dateSplit = splitUpText[0].Split('-');
                    string newDate = dateSplit[0] + "." + dateSplit[1] + "." + dateSplit[2];
                    retval.Append("(" + newDate + ")");
                    for (int c1 = 1; c1 < 8; c1++) {
                        retval.Append("(" + splitUpText[c1] + ")");
                    }
                }
                else {
                    for (int c1 = 0; c1 < splitUpText.Length; c1++) {
                        retval.Append("(" + splitUpText[c1] + ")");
                    }
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
        public string Process05(string input) {
            TextReader reader = new StringReader(input);
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ', '\t' });
                if (splitUpText[0].Length == 0) {
                    continue;
                }
                if (splitUpText[0].Contains("-")) {
                    string[] dateSplit = splitUpText[0].Split('-');
                    string newDate = dateSplit[0] + "." + dateSplit[1] + "." + dateSplit[2];
                    retval.Append(newDate);
                    for (int c1 = 1; c1 < 8; c1++) {
                        retval.Append(" " + splitUpText[c1]);
                    }
                }
                else {
                    retval.Append(lineOfText);
                }
                retval.Append("\n");
            }
            return retval.ToString();
        }
    }
}
