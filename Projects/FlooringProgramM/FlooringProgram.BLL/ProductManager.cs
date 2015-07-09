using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.BLL
{
    public class ProductManager
    {
        private IProductInformationRepository _myProductInformationRepository;

        public ProductManager(IProductInformationRepository aProductInformationRepository)
        {
            _myProductInformationRepository = aProductInformationRepository;
        }

        public List<ProductInformation> ListAll()
        {
            return _myProductInformationRepository.ListAll();
        }

        public decimal GetCostPerSquareFoot(string product)
        {
            var allProducts = _myProductInformationRepository.ListAll();
            var cost = allProducts.First(c => c.ProductType == product);
            return cost.CostPerSquareFoot;
        }

        public decimal GetLaborCostPerSquareFoot(string productType)
        {
            var allProducts = _myProductInformationRepository.ListAll();
            var cost = allProducts.First(c => c.ProductType == productType);
            return cost.LaborCostPerSquareFoot;
        }

        public bool IsValidProduct(string product)
        {
            var allProducts = _myProductInformationRepository.ListAll();

            return allProducts.Any(p => p.ProductType == product);
        }
    }
}
