using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Data
{
    public class DataSanitizer
    {
        public static string SanitizeData(string incomingData)
        {
            incomingData = incomingData.Replace(',', '|');

            return incomingData;
        }

        public static string ContaminateData(string outgoingData)
        {
            outgoingData = outgoingData.Replace('|', ',');

            return outgoingData;

        }

    }
}
