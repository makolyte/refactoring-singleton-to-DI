using Ninject;
using Ninject.Modules;
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
            var container = new StandardKernel(new Module());

            //using it
            var order = new Order() { Id = 1 };
            
            var repository = container.Get<IOrderRepository>();
            repository.Save(order); //just to add test data

            var cancelOrderHandler = container.Get<CancelOrderHandler>();
            cancelOrderHandler.Handle(new CancelOrder() { OrderId = order.Id });

            Console.ReadLine();
        }
    }
    public class Module : NinjectModule
    {
        public override void Load()
        {
            Bind<ILogger>().To<Logger>().InSingletonScope();
            Bind<IOrderRepository>().To<InMemoryRepository>().InSingletonScope();
            Bind<CancelOrderHandler>().ToSelf().InSingletonScope();
        }
    }
}
