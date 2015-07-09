using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data
{
    public class TestOrderRepository : IOrderRepository
    {

        public void Add(UserInputRequest request)
        {
            return;
        }

        public void Edit(UserInputRequest request)
        {
            return;
        }

        public void Delete(UserInputRequest request)
        {
            return;
        }



        public List<Order> LoadOrders(DateTime orderDate)
        {
            var testList = new List<Order>();

            testList.Add(new Order() {OrderNumber = 1, Area = 100.00M, CostPerSquareFoot = 2.00M, CustomerName = "Brian", LaborCost = 400.00M, 
                LaborCostPerSquareFoot = 4.00M, MaterialCost = 200.00M, ProductType = "Wood", StateAbbreviation = "OH", 
                Tax = 34.75M, TaxRate = 0.0575M, Total = 634.75M});

            testList.Add(new Order() {OrderNumber = 2, Area = 200.00M, CostPerSquareFoot = 4.00M, CustomerName = "Lara", LaborCost = 1600.00M, 
                LaborCostPerSquareFoot = 8.00M, MaterialCost = 800.00M, ProductType = "Marble", StateAbbreviation = "OH", 
                Tax = 138.00M, TaxRate = 0.0575M, Total = 2538.00M});


            return testList;
        }
        






    }
}
