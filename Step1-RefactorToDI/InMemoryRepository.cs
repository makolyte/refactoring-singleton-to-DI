using System;
using System.Collections.Generic;

namespace Step0_SingletonsEverywhere
{
    public class InMemoryRepository : IOrderRepository
    {
        public InMemoryRepository(ILogger logger)
        {
            Logger = logger;
            InMemoryDatabase = new List<Order>();
        }

        private readonly ILogger Logger;

        private readonly List<Order> InMemoryDatabase;
        public Order GetById(int id)
        {
            Logger.Log($"Getting Order {id}");
            return InMemoryDatabase.Find(o => o.Id == id);
        }

        public void Save(Order order)
        {
            Logger.Log($"Saving order {order.Id}");
            if (InMemoryDatabase.Find(o => o.Id == order.Id) == null)
            {

                InMemoryDatabase.Add(order);
            }
        }


    }
}
