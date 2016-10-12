using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ReaderWriter;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Text2Binary {
    class LottoTicketProcessor : IText2BinaryProcessor {
        public void Process(TextReader reader, Stream writer) {
            StringBuilder retval = new StringBuilder();
            while (reader.Peek() != -1) {
                string lineOfText = reader.ReadLine();
                string[] splitUpText = lineOfText.Split(new char[] { ' ' });
                string[] dateSplit = splitUpText[0].Split('.');

                LottoLibrary.Ticket ticket =
                    new LottoLibrary.Ticket(
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

                BinaryFormatter formatter = new BinaryFormatter();

                formatter.Serialize(writer, ticket);
            }
        }
    }
}
