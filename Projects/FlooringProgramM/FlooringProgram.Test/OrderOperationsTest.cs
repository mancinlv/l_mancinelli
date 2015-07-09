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
    public class OrderOperationsTest
    {
        [Test]
        public void RejectsInvalidArea()
        {
            var response = new Response<Order>();
            var manager = ManagerFactory.CreateOrderManager();
            UserInputRequest input = new UserInputRequest();
            input.RequestOrder = new Order();
            input.RequestOrder.Area = 0;
            response = manager.AddOrder(input);

            Assert.AreEqual(false, response.Success);

        }

        [Test]
        public void RejectsInvalidProduct()
        {
            var response = new Response<Order>();
            var manager = ManagerFactory.CreateOrderManager();
            UserInputRequest input = new UserInputRequest();
            input.RequestOrder = new Order();
            input.RequestOrder.ProductType = "stuff";
            response = manager.AddOrder(input);

            Assert.AreEqual(false, response.Success);
        }

        [Test]
        public void RejectsInvalidState()
        {
            var response = new Response<Order>();
            var manager = ManagerFactory.CreateOrderManager();
            UserInputRequest input = new UserInputRequest();
            input.RequestOrder = new Order();
            input.RequestOrder.StateAbbreviation = "ULl";
            response = manager.AddOrder(input);

            Assert.AreEqual(false, response.Success);
        }

        [Test]
        public void CanAddFullOrderWithUserInput()
        {
            var response = new Response<Order>();
            var manager = ManagerFactory.CreateOrderManager();
            UserInputRequest input = new UserInputRequest();
            input.RequestOrder = new Order();
            input.RequestOrder.CustomerName = "Brian";
            input.RequestOrder.Area = 10;
            input.RequestOrder.StateAbbreviation = "OH";
            input.RequestOrder.ProductType = "Wood";

            response = manager.AddOrder(input);

            Assert.IsTrue(response.Success);

            Assert.AreEqual(3, response.Data.OrderNumber);
            Assert.AreEqual("Brian", response.Data.CustomerName);
            Assert.AreEqual(10, response.Data.Area);
            Assert.AreEqual("OH", response.Data.StateAbbreviation);
            Assert.AreEqual("Wood", response.Data.ProductType);
            Assert.AreEqual(1.00M, response.Data.LaborCostPerSquareFoot);
            Assert.AreEqual(2.00M, response.Data.CostPerSquareFoot);
            Assert.AreEqual(0.0625M, response.Data.TaxRate);
            Assert.AreEqual(20M, response.Data.MaterialCost);
            Assert.AreEqual(10M, response.Data.LaborCost);
            Assert.AreEqual(1.875M, response.Data.Tax);
            Assert.AreEqual(31.875M, response.Data.Total);
            
        }

    }
}
