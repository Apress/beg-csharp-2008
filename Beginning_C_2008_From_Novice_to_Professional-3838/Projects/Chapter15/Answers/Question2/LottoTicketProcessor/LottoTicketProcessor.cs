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
        int FrequencyOfTwoNumbersList(int number1ToSearch, int number2ToSearch) {
            var query = _tickets.Where(
                (ticket, index) =>
                    ticket.Numbers[0] == number1ToSearch
                    || ticket.Numbers[1] == number1ToSearch
                    || ticket.Numbers[2] == number1ToSearch
                    || ticket.Numbers[3] == number1ToSearch
                    || ticket.Numbers[4] == number1ToSearch
                    || ticket.Numbers[5] == number1ToSearch
                    ).Where(
                (ticket, index) =>
                    ticket.Numbers[0] == number2ToSearch
                    || ticket.Numbers[1] == number2ToSearch
                    || ticket.Numbers[2] == number2ToSearch
                    || ticket.Numbers[3] == number2ToSearch
                    || ticket.Numbers[4] == number2ToSearch
                    || ticket.Numbers[5] == number2ToSearch);

            return query.Count();
        }
        int FrequencyOfThreeNumbersList(int number1ToSearch, int number2ToSearch, int number3ToSearch) {
            var query = _tickets.Where(
                (ticket, index) =>
                    ticket.Numbers[0] == number1ToSearch
                    || ticket.Numbers[1] == number1ToSearch
                    || ticket.Numbers[2] == number1ToSearch
                    || ticket.Numbers[3] == number1ToSearch
                    || ticket.Numbers[4] == number1ToSearch
                    || ticket.Numbers[5] == number1ToSearch
                    ).Where(
                (ticket, index) =>
                    ticket.Numbers[0] == number2ToSearch
                    || ticket.Numbers[1] == number2ToSearch
                    || ticket.Numbers[2] == number2ToSearch
                    || ticket.Numbers[3] == number2ToSearch
                    || ticket.Numbers[4] == number2ToSearch
                    || ticket.Numbers[5] == number2ToSearch
                    ).Where(
                (ticket, index) =>
                    ticket.Numbers[0] == number3ToSearch
                    || ticket.Numbers[1] == number3ToSearch
                    || ticket.Numbers[2] == number3ToSearch
                    || ticket.Numbers[3] == number3ToSearch
                    || ticket.Numbers[4] == number3ToSearch
                    || ticket.Numbers[5] == number3ToSearch);

            return query.Count();
        }

        public string Finalize() {
            StringBuilder builder = new StringBuilder();
            for (int c1 = 1; c1 < 46; c1++) {
                builder.Append("Number (" + c1 + ") Found (");
                builder.Append("Single (" + FrequencyOfANumber(c1) + ")");
            }
            for (int num1 = 1; num1 < 46; num1++) {
                for (int num2 = 1; num2 < 46; num2++) {
                    builder.Append("Pairs (" + num1 + ")(" + num2 + ")(" + FrequencyOfTwoNumbersList(num1, num2) + ")");
                }
            }
            for( int num1 = 1; num1 < 46; num1 ++) {
                for (int num2 = 1; num2 < 46; num2++) {
                    for (int num3 = 1; num3 < 46; num3++) {
                        builder.Append("Triple (" + num1 + ")(" + num2 + ")(" + num3 + ")(" + FrequencyOfThreeNumbersList(num1, num2, num3) + ")");
                    }
                }
            }
            return builder.ToString();
        }

        #endregion
    }
}
