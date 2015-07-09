using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.BLL
{
    public class TaxManager
    {
        private IStateTaxInformationRepository _myStateTaxInformationRepository;

        public TaxManager(IStateTaxInformationRepository aStateTaxInformationRepository)
        {
            _myStateTaxInformationRepository = aStateTaxInformationRepository;
        }

        public List<StateTaxInformation> ListAll()
        {
            return _myStateTaxInformationRepository.ListAll();
        }

        public decimal GetRate(string stateAbbreviation)
        {
            var allStates = _myStateTaxInformationRepository.ListAll();
            var state = allStates.First(a => a.StateAbbreviation == stateAbbreviation);
            return state.TaxRate;
        }

        public bool IsValidState(string stateAbbreviation)
        {
            var allStates = _myStateTaxInformationRepository.ListAll();

            return allStates.Any(s => s.StateAbbreviation == stateAbbreviation);
        }

    }
}
