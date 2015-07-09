using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrders(DateTime orderDate);

        void Add(UserInputRequest request);

        void Edit(UserInputRequest request);

        void Delete(UserInputRequest request);

    }

}
