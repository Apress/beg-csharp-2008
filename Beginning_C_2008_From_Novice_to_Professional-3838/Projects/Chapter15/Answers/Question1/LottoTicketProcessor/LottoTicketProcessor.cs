using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;
using LottoLibrary;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace LottoTicketProcessor {
    class LottoTicketProcessor : IBinary2TextProcessorExtended {
        List<Ticket> _tickets = new List<Ticket>();

        public void Process(System.IO.Stream input, System.IO.TextWriter output) {
            StringBuilder builder = new StringBuilder();
            try {
                while (true) {
                    BinaryFormatter formatter = new BinaryFormatter();

                    LottoLibrary.Ticket ticket = (LottoLibrary.Ticket)formatter.Deserialize(input);
                    _tickets.Add(ticket);
                }
            }
            catch (Exception e) {
            }
            output.Write("");
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
