using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;


namespace FlooringProgram.Data
{
    public class TestProductInformationRepository : IProductInformationRepository
    {
        public List<ProductInformation> ListAll()
        {
            return new List<ProductInformation>()
            {
                new ProductInformation()
                {
                    ProductType = "Wood",
                    CostPerSquareFoot = 2.00M,
                    LaborCostPerSquareFoot = 1.00M
                },
                new ProductInformation()
                {
                    ProductType = "Tile",
                    CostPerSquareFoot = 3.00M,
                    LaborCostPerSquareFoot = 1.00M
                },
                new ProductInformation()
                {
                    ProductType = "Marble",
                    CostPerSquareFoot = 5.00M,
                    LaborCostPerSquareFoot = 2.00M
                },
            };
        }
    }
}
