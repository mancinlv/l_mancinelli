using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.Data
{
    public class OrderRepository : IOrderRepository
    {
        private const string Dir = @"DataFiles/";

        private string GenerateFileName(DateTime date)
        {
            string file = string.Format("{0}Orders_{1}.txt", Dir, date.ToString("MMddyyyy"));
            return file;
        }


        public List<Order> LoadOrders(DateTime date)
        {
            string file = GenerateFileName(date);

            if (!File.Exists(file))
                return new List<Order>();

            var reader = File.ReadAllLines(GenerateFileName(date));

            var orderList = new List<Order>();

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = CreateOrder(columns);

                orderList.Add(order);
            }

            return orderList;
        }


        public void Add(UserInputRequest request)
        {

            var orders = LoadOrders(request.Date);

                orders.Add(request.RequestOrder);

                OverwriteFile(orders, request.Date);
      
        }

        public void Delete(UserInputRequest request)
        {
            var orders = LoadOrders(request.Date);

            var orderToDelete = orders.First(o => o.OrderNumber == request.RequestOrder.OrderNumber);
            orders.Remove(orderToDelete);

            OverwriteFile(orders, request.Date);
        }

        public void Edit(UserInputRequest request)
        {
            var orders = LoadOrders(request.Date);

            foreach (var order in orders.ToList())
            {
                if (request.RequestOrder.OrderNumber == order.OrderNumber)
                {
                    orders[order.OrderNumber-1] = request.RequestOrder;
                }
            }

            OverwriteFile(orders, request.Date);
        }

        private void OverwriteFile(List<Order> orders, DateTime date)
        {

            Directory.CreateDirectory(Dir);

             File.Delete(GenerateFileName(date));
           
            using (var writer = File.CreateText(GenerateFileName(date)))
            {
                writer.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot," +
                                 "MaterialCost,LaborCost,Tax,Total");

                foreach (var order in orders)
                {
                    order.CustomerName = DataSanitizer.SanitizeData(order.CustomerName);

                    writer.WriteLine("{0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}", order.OrderNumber, order.CustomerName,
                                order.StateAbbreviation, order.TaxRate, order.ProductType, order.Area, order.CostPerSquareFoot,
                                order.LaborCostPerSquareFoot, order.MaterialCost, order.LaborCost, order.Tax, order.Total);
                }
            }

        }

        private static Order CreateOrder(string[] columns)
        {

            var order = new Order();

            order.OrderNumber = int.Parse(columns[OrderColumns.OrderNumber]);
            order.CustomerName = columns[OrderColumns.CustomerName];
            order.StateAbbreviation = columns[OrderColumns.StateAbbreviation];
            order.TaxRate = decimal.Parse(columns[OrderColumns.TaxRate]);
            order.ProductType = columns[OrderColumns.ProductType];
            order.Area = decimal.Parse(columns[OrderColumns.Area]);
            order.CostPerSquareFoot = decimal.Parse(columns[OrderColumns.CostPerSquareFoot]);
            order.LaborCostPerSquareFoot = decimal.Parse(columns[OrderColumns.LaborCostPerSquareFoot]);
            order.MaterialCost = decimal.Parse(columns[OrderColumns.MaterialCost]);
            order.LaborCost = decimal.Parse(columns[OrderColumns.LaborCost]);
            order.Tax = decimal.Parse(columns[OrderColumns.Tax]);
            order.Total = decimal.Parse(columns[OrderColumns.Total]);

            order.CustomerName = DataSanitizer.ContaminateData(order.CustomerName);
            return order;
        }

        public Order LoadOrder(UserInputRequest request)
        {

            //we used this for file path one day long ago 
            //@"DataFiles/Orders_" + String.Format("{0:MMddyyyy}", date) + ".txt"

            var reader = File.ReadAllLines(GenerateFileName(request.Date));

            for (int i = 1; i < reader.Length; i++)
            {
                var columns = reader[i].Split(',');

                var order = CreateOrder(columns);

                if (order.OrderNumber == request.RequestOrder.OrderNumber)
                    return order;
            }

            return null;
        }
    }

    
}
