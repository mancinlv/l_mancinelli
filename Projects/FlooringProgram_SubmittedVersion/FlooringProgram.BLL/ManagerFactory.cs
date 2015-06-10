using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProgram.Data;
using FlooringProgram.Data.Prod;

namespace FlooringProgram.BLL
{
    public class ManagerFactory
    {
        public static TaxManager CreateTaxManager()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            if(mode == "Test")
                return new TaxManager(new TestStateTaxInformationRepository());
            else
            {
                return new TaxManager(new StateTaxInformationRepository());
            }
        }

        public static ProductManager CreateProductManager()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            if(mode == "Test")
                return new ProductManager(new TestProductInformationRepository());
            else
            {
                return new ProductManager(new ProductInformationRepository());
            }
        }

        public static OrderManager CreateOrderManager()
        {
            string mode = ConfigurationManager.AppSettings["Mode"];

            if(mode == "Test")
                return new OrderManager(new TestOrderRepository());
            else
            {
                return new OrderManager(new OrderRepository());
            }

        }

        public static LoggerManager CreateLoggerManager()
        {
            //string mode = ConfigurationManager.AppSettings["Mode"];

            return new LoggerManager(new LoggerRepository());
          
        }
    }
}
