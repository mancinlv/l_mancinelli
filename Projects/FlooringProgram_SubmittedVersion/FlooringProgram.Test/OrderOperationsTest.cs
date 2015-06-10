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
            response = manager.CompleteOrder(input);

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
            response = manager.CompleteOrder(input);

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
            response = manager.CompleteOrder(input);

            Assert.AreEqual(false, response.Success);
        }

        [Test]
        public void CanCompleteFullOrderWithUserInput()
        {
            var response = new Response<Order>();
            var manager = ManagerFactory.CreateOrderManager();
            UserInputRequest input = new UserInputRequest();
            input.RequestOrder = new Order();
            input.RequestOrder.CustomerName = "Brian";
            input.RequestOrder.Area = 10;
            input.RequestOrder.StateAbbreviation = "OH";
            input.RequestOrder.ProductType = "Wood";

            response = manager.CompleteOrder(input);
            

            Assert.IsTrue(response.Success);
        }

    }
}
