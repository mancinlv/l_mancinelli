using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data
{
    public class TestStateTaxInformationRepository : IStateTaxInformationRepository
    {
        public List<StateTaxInformation> ListAll()
        {
            return new List<StateTaxInformation>()
            {
                new StateTaxInformation() {StateAbbreviation = "OH", StateName = "Ohio", TaxRate = 6.25M},
                new StateTaxInformation() {StateAbbreviation = "PA", StateName = "Pennsylvania", TaxRate = 7.50M},
                new StateTaxInformation() {StateAbbreviation = "NY", StateName = "New York", TaxRate = 10.00M},
            };
        }
    }
}
