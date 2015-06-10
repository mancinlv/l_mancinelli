using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models
{
    public class Logger
    {
        public Logger(DateTime date, string message)
        {
            EventDate = date;
            ErrorMessage = message;
        }


        public DateTime EventDate { get; set; }

        public string ErrorMessage { get; set; }
    }
}
