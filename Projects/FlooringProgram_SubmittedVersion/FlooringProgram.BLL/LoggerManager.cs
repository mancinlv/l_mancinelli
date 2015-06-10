using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.BLL 
{
    public class LoggerManager
    {
        private ILoggerRepository _myLoggerRepository;

        public LoggerManager(ILoggerRepository aLoggerRepository)
        {
            _myLoggerRepository = aLoggerRepository;
        }

        public List<Logger> ListAllLogs()
        {
            var logs = new List<Logger>();
            
                var manager = ManagerFactory.CreateLoggerManager();

                logs = manager.ListAllLogs();

            return logs;

        }

        public void AddLog(Logger logger)
        {
                
                _myLoggerRepository.Add(logger);

        }
    }
}
