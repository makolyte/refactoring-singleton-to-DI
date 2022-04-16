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
            InMemoryRepository.Instance.Save(new Order() { Id = 1 });

            var cancelOrderCommand = new CancelOrder() { OrderId = 1 };
            CancelOrderHandler.Instance.Handle(cancelOrderCommand);

            var order = InMemoryRepository.Instance.GetById(1);
            Logger.Instance.Log($"Order {order.Id} status = {order.Status}");
        }
    }
}
