using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary2Text {
    class LottoTicketProcessor : IBinary2TextProcessor {
        public void Process(System.IO.Stream input, System.IO.TextWriter output) {
            StringBuilder builder = new StringBuilder();
            try {
                while (true) {
                    BinaryFormatter formatter = new BinaryFormatter();

                    LottoLibrary.Ticket ticket = (LottoLibrary.Ticket)formatter.Deserialize(input);

                    builder.AppendFormat("{0}.{1}.{2} {3} {4} {5} {6} {7} {8} {9}\n",
                        ticket.DrawDate.Year, ticket.DrawDate.Month, ticket.DrawDate.Day,
                        ticket.Numbers[0], ticket.Numbers[1], ticket.Numbers[2],
                        ticket.Numbers[3], ticket.Numbers[4], ticket.Numbers[5],
                        ticket.Bonus);
                }
            }
            catch (Exception e) {
            }
            output.Write(builder.ToString());
        }
    }
}
