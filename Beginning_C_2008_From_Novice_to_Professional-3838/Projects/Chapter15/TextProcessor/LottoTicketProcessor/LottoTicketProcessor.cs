using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;
using LottoLibrary;
using System.IO;

namespace LottoTicketProcessor {
    class LottoTicketProcessor : IExtendedProcessor {
        List<Ticket> _tickets = new List<Ticket>();

        public string Process(string input) {
            TextReader reader = new StringReader(input);

            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ' });
                string[] dateSplit = splitUpText[0].Split('.');

                Ticket ticket =
                    new Ticket(
                        new DateTime(
                            int.Parse(dateSplit[0]),
                            int.Parse(dateSplit[1]),
                            int.Parse(dateSplit[2])),
                        new int[] {
                                int.Parse( splitUpText[ 1]),
                                int.Parse( splitUpText[ 2]),
                                int.Parse( splitUpText[ 3]),
                                int.Parse( splitUpText[ 4]),
                                int.Parse( splitUpText[ 5]),
                                int.Parse( splitUpText[ 6]) },
                                    int.Parse(splitUpText[7]));
                _tickets.Add(ticket);
            }
            return "";
        }


        #region IExtendedProcessor Members

        public string Initialize() {
            return "";
        }

        int FrequencyOfANumber(int numberToSearch) {
            var query = from lst in _tickets
                        where lst.Numbers[0] == numberToSearch
                        || lst.Numbers[1] == numberToSearch
                        || lst.Numbers[2] == numberToSearch
                        || lst.Numbers[3] == numberToSearch
                        || lst.Numbers[4] == numberToSearch
                        || lst.Numbers[5] == numberToSearch
                        select lst.Numbers;
            return query.Count();
        }
        public string Finalize() {
            StringBuilder builder = new StringBuilder();
            for (int c1 = 1; c1 < 46; c1++) {
                builder.Append("Number (" + c1 + ") Found (");
                int foundCount = 0;
                foundCount += FrequencyOfANumber(c1);
                builder.Append("" + foundCount + ")\n");
            }
            return builder.ToString();
        }

        #endregion
    }
}
