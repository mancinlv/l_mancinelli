using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data.Prod
{
    public class StateTaxInformationRepository : IStateTaxInformationRepository
    {
        public List<StateTaxInformation> ListAll()
        {
            string file = @"DataFiles/Taxes.txt";

            if (!File.Exists(file))
                return new List<StateTaxInformation>();

            var reader = File.ReadAllLines(file);

            var stateList = new List<StateTaxInformation>();

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var state = new StateTaxInformation();

                state.StateAbbreviation = columns[0];
                state.TaxRate = decimal.Parse(columns[1]);

                stateList.Add(state);
            }

            return stateList; 
        }

         
    }
}
