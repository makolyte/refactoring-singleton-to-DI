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
            //composition root
            var logger = new Logger();
            var repository = new InMemoryRepository(logger);

            //using it
            var order = new Order() { Id = 1 };
            repository.Save(order);

            var cancelOrderCommand = new CancelOrder() { OrderId = order.Id };
            CancelOrderHandler.GetInstance(logger, repository).Handle(cancelOrderCommand);

            Console.ReadLine();
        }
    }
}
