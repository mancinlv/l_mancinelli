using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data
{
    public class TestLoggerRepository : ILoggerRepository
    {

        public List<Logger> ListAll()
        {
            return new List<Logger>();
        }

        public void Add(Logger logger)
        {
            return;
        }
    }
}
