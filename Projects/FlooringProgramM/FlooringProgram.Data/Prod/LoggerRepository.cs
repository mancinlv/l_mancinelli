using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data
{
    public class LoggerRepository : ILoggerRepository
    {
        private const string file = @"DataFiles/Log.txt";

        public List<Logger> ListAll()
        {
            

            if (!File.Exists(file))
                return new List<Logger>();

            var reader = File.ReadAllLines(file);

            var loggerList = new List<Logger>();

            for (int i = 1; i < reader.Length; i++)
            {
                //fix
                var columns = reader[i].Split(',');

                DateTime date;
                DateTime.TryParse(columns[0], out date);

                var logger = new Logger(date, columns[1]);
                
                loggerList.Add(logger);
            }

            return loggerList;
        }

        public void Add(Logger logger)
        {
            var loggers = ListAll();

            loggers.Add(logger);

            OverwriteFile(loggers);
        }

        private void OverwriteFile(List<Logger> loggers)
        {

            File.Delete(file);

            using (var writer = File.CreateText(file))
            {
                writer.WriteLine("Event Date, Error Message");

                foreach (var log in loggers)
                {
                    writer.WriteLine("Date: {0}, ;{1}, .", log.EventDate, log.ErrorMessage);
                }
            }
        }
    }
}
