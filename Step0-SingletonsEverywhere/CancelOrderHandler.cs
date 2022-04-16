namespace Step0_SingletonsEverywhere
{
    public class CancelOrderHandler
    {
        #region Singleton pattern
        private static CancelOrderHandler instance;
        public static CancelOrderHandler GetInstance()
        {
            if (instance == null)
            {
                instance = new CancelOrderHandler();
            }
            return instance;
        }
        private CancelOrderHandler() { }
        #endregion

        public void Handle(CancelOrder command)
        {
            var order = InMemoryRepository.GetInstance().GetById(command.OrderId);

            Logger.GetInstance().Log($"Cancelling order {command.OrderId}");
            order.Status = OrderStatus.Cancelled;

            InMemoryRepository.GetInstance().Save(order);
        }
    }
}
