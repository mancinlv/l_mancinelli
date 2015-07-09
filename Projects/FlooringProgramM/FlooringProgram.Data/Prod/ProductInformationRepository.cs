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
    public class ProductInformationRepository : IProductInformationRepository
    {
        public List<ProductInformation> ListAll()
        {
            string file = @"DataFiles/Products.txt";

            if (!File.Exists(file))
                return new List<ProductInformation>();

            var reader = File.ReadAllLines(file);

            var productList = new List<ProductInformation>();

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var product = new ProductInformation();

                product.ProductType = columns[0];
                product.CostPerSquareFoot = decimal.Parse(columns[1]);
                product.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                productList.Add(product);
            }

            return productList; 
        } 

    }
}
