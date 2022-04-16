using System;
using System.Collections.Generic;

namespace Step0_SingletonsEverywhere
{
    public class InMemoryRepository
    {
        #region Singleton pattern
        private static InMemoryRepository instance;
        public static InMemoryRepository GetInstance()
        {
            if (instance == null)
            {
                instance = new InMemoryRepository();
            }
            return instance;
        }
        private InMemoryRepository() 
        {
            InMemoryDatabase = new List<Order>();
        }
        #endregion
        private readonly List<Order> InMemoryDatabase;
        public Order GetById(int id)
        {
            Logger.GetInstance().Log($"Getting Order {id}");
            return InMemoryDatabase.Find(o => o.Id == id);
        }

        public void Save(Order order)
        {
            Logger.GetInstance().Log($"Saving order {order.Id}");
            if (InMemoryDatabase.Find(o => o.Id == order.Id) == null)
            {
                
                InMemoryDatabase.Add(order);
            }
        }

        
    }
}
