using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Step0_SingletonsEverywhere
{
    class Program
    {
        static void Main(string[] args)
        {
            var order = new Order() { Id = 1 };
            InMemoryRepository.GetInstance().Save(order);

            var cancelOrderCommand = new CancelOrder() { OrderId = order.Id };
            CancelOrderHandler.GetInstance().Handle(cancelOrderCommand);

            Console.ReadLine();
        }
    }
}
