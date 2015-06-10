using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.BLL;
using FlooringProgram.Models;
using FlooringProgram.Models.Interfaces;

namespace FlooringProgram.BLL
{

    public class OrderManager
    {
        private IOrderRepository _myOrderRepository;

        private LoggerManager logManager = ManagerFactory.CreateLoggerManager();

        public OrderManager(IOrderRepository aOrderRepository)
        {
            _myOrderRepository = aOrderRepository;

        }

        public Response<List<Order>> GetOrders(DateTime date)
        {

            var response = new Response<List<Order>>();


            try
            {
                var orders = _myOrderRepository.LoadOrders(date);

                if (orders.Count == 0)
                {
                    response.Success = false;
                    response.Message = "No orders for that date.";
                    response.Data = new List<Order>();
                }
                else
                {
                    response.Success = true;
                    response.Data = orders;
                }


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                var log = new Logger(DateTime.Now, response.Message);
                logManager.AddLog(log);

            }

            return response;
        }



        public Response<Order> AddOrder(UserInputRequest request)
        {
           
            var response = new Response<Order>();

            try
            {
                var orders = GetOrders(request.Date);

                var orderNumber = orders.Data.Count;
                

                if (orderNumber == 0 || orders.Data == null)
                {
                    request.RequestOrder.OrderNumber = 1;
                }
                else
                {
                    orderNumber++;

                    request.RequestOrder.OrderNumber = orderNumber;
                }


                _myOrderRepository.Add(request);
                response.Data = request.RequestOrder;

                response.Success = true;


            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                var log = new Logger(DateTime.Now, response.Message);
                logManager.AddLog(log);
            }

            return response;

           
        }

        public Response<Order> DeleteOrder(UserInputRequest request)
        {
            var response = new Response<Order>();

            try
            {
                _myOrderRepository.LoadOrders(request.Date);


                _myOrderRepository.Delete(request);
                response.Data = request.RequestOrder;

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                var log = new Logger(DateTime.Now, response.Message);
                logManager.AddLog(log);
            }
            return response;
        }


        public Response<Order> EditOrder(UserInputRequest request)
        {
            var response = new Response<Order>();
            

            try
            {
                    _myOrderRepository.LoadOrders(request.Date);               
                
                    _myOrderRepository.Edit(request);
                    response.Data = request.RequestOrder;
 
                    response.Success = true;

                
            }
            catch (Exception ex)
            {

                response.Success = false;
                response.Message = ex.Message;
                var log = new Logger(DateTime.Now, response.Message);
                logManager.AddLog(log);
            }

            return response;
        }


        public Response<Order> CompleteOrder(UserInputRequest request)
        {

            var productRepo = ManagerFactory.CreateProductManager();
            var taxRepo = ManagerFactory.CreateTaxManager();

            var response = new Response<Order>();

            OrderCalculations calc = new OrderCalculations();


            try
            {
                if (request.RequestOrder.Area <= 0)
                {
                    response.Success = false;
                    response.Message = "Area is too small to be floored.";
                }
                else if (productRepo.IsValidProduct(request.RequestOrder.ProductType) == false)
                {
                    response.Success = false;
                    response.Message = "We don't carry that product.";
                }
                else if (taxRepo.IsValidState(request.RequestOrder.StateAbbreviation) == false)
                {
                    response.Success = false;
                    response.Message = "We don't offer our services to that state.";
                }
                else
                {
                    response.Success = true;

                    
                    request.RequestOrder.StateAbbreviation = request.RequestOrder.StateAbbreviation;
                    request.RequestOrder.TaxRate = taxRepo.GetRate(request.RequestOrder.StateAbbreviation);

                    if (request.RequestOrder.CostPerSquareFoot == 0.0M)
                    {
                        request.RequestOrder.CostPerSquareFoot =
                        productRepo.GetCostPerSquareFoot(request.RequestOrder.ProductType);
                    }

                    if (request.RequestOrder.LaborCostPerSquareFoot == 0.0M)
                    {
                        request.RequestOrder.LaborCostPerSquareFoot =
                        productRepo.GetLaborCostPerSquareFoot(request.RequestOrder.ProductType);
                    }
                    
                    request.RequestOrder.MaterialCost = calc.CalculateTotalMaterialCost(request.RequestOrder.Area,
                        request.RequestOrder.CostPerSquareFoot);
                    request.RequestOrder.LaborCost = calc.CalculateTotalLaborCost(request.RequestOrder.Area,
                        request.RequestOrder.LaborCostPerSquareFoot);
                    request.RequestOrder.Tax = calc.CalculateTotalTax(request.RequestOrder.TaxRate,
                        request.RequestOrder.MaterialCost, request.RequestOrder.LaborCost);
                    request.RequestOrder.Total = calc.CalculateTotalCost(request.RequestOrder.LaborCost,
                        request.RequestOrder.MaterialCost, request.RequestOrder.Tax);

                    response.Data = request.RequestOrder;
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
                var log = new Logger(DateTime.Now, response.Message);
                logManager.AddLog(log);
            }
           
            return response;
        }




        
         public Response<Order> GetOrder(UserInputRequest request)
         {
            
               var response = new Response<Order>();

                try
                {

                    var orders = _myOrderRepository.LoadOrders(request.Date);

                    var order = orders.FirstOrDefault(o => o.OrderNumber == request.RequestOrder.OrderNumber);

                    if (orders.Count == 0)
                    {
                        response.Success = false;
                        response.Message = "There are no orders for that date.";
                    }
                    else if (order == null)
                    {
                        response.Success = false;
                        response.Message = "That order does not exist for that date.";
                    }
                    else
                    {
                        response.Success = true;

                        response.Data = order;
                    }


                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.Message = ex.Message;
                    var log = new Logger(DateTime.Now, response.Message);
                    logManager.AddLog(log);
                
                }

                return response;
         }
            

    }
}
    

