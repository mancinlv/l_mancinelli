using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Data;
using FlooringProgram.Models;
using NUnit.Framework;

namespace FlooringProgram.Test
{
    [TestFixture]
    public class OrderRepositoryTests
    {
        [Test]
        public void CanGetListOfOrdersFromRepo()
        {
            var repo = new TestOrderRepository();

            DateTime date = new DateTime(13, 4, 4);

            var orderList = repo.LoadOrders(date);

            Assert.IsNotEmpty(orderList);

        }
       

        [Test]
        public void RejectsInvalidState()
        {
            var manager = ManagerFactory.CreateTaxManager();
            var taxes = manager.ListAll();
            var state = "CA";
            var result = manager.IsValidState(state);

            Assert.IsFalse(result);
        }       

        [Test]
        public void RejectsInvalidProduct()
        {
            var manager = ManagerFactory.CreateProductManager();
            var product = "xxxx";

            Assert.IsFalse(manager.IsValidProduct(product));
        }

        [Test]
        public void CanWriteToFile()
        {
            var repo = new OrderRepository();
            var request = new UserInputRequest();


            request.Date = DateTime.Parse("06/05/2222");
            var beforeList = repo.LoadOrders(request.Date);



            request.RequestOrder = new Order() {OrderNumber = 1, Area = 100.00M, CostPerSquareFoot = 2.00M, CustomerName = "Lisa", LaborCost = 400.00M, 
                LaborCostPerSquareFoot = 4.00M, MaterialCost = 200.00M, ProductType = "Wood", StateAbbreviation = "OH", 
                Tax = 34.75M, TaxRate = 0.0575M, Total = 634.75M};
            
            
            repo.Add(request);


            var orders = repo.LoadOrders(request.Date);

            Assert.IsTrue(orders.Last().CustomerName == "Lisa");

            var afterList = repo.LoadOrders(request.Date);

            Assert.IsTrue(afterList.Count == beforeList.Count + 1);

        }

        [Test]
        public void CanEditSingleOrder()
        {
            var repo = new OrderRepository();
            var request = new UserInputRequest();

            request.Date = DateTime.Today;

            var beforeList = repo.LoadOrders(request.Date);

            request.RequestOrder = new Order()
            {
                OrderNumber = 1,
                Area = 100.00M,
                CostPerSquareFoot = 2.00M,
                CustomerName = "Lisa",
                LaborCost = 400.00M,
                LaborCostPerSquareFoot = 4.00M,
                MaterialCost = 200.00M,
                ProductType = "Wood",
                StateAbbreviation = "OH",
                Tax = 34.75M,
                TaxRate = 0.0575M,
                Total = 634.75M
            };
            repo.Add(request);

            var orders = repo.LoadOrders(request.Date);

            

            Assert.IsTrue(orders.Last().CustomerName == "Lisa");



            var afterList = repo.LoadOrders(request.Date);

            Assert.IsTrue(beforeList.Count + 1 == afterList.Count);


            var newRequest = new UserInputRequest();
            request.Date = DateTime.Today;


            request.RequestOrder = new Order()
            {
                OrderNumber = 1,
                Area = 100.00M,
                CostPerSquareFoot = 2.00M,
                CustomerName = "Sarah",
                LaborCost = 400.00M,
                LaborCostPerSquareFoot = 4.00M,
                MaterialCost = 200.00M,
                ProductType = "Wood",
                StateAbbreviation = "OH",
                Tax = 34.75M,
                TaxRate = 0.0575M,
                Total = 634.75M
            };

            repo.Edit(newRequest);

            Assert.AreEqual("Sarah", request.RequestOrder.CustomerName);

        }
    }
}
