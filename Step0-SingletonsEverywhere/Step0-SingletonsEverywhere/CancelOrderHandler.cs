namespace Step0_SingletonsEverywhere
{
    public class CancelOrderHandler
    {
        #region Singleton pattern
        private static CancelOrderHandler instance;
        public static CancelOrderHandler Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new CancelOrderHandler();
                }
                return instance;
            }
        }
        private CancelOrderHandler() { }
        #endregion

        public void Handle(CancelOrder command)
        {
            Logger.Instance.Log($"Cancelling order {command.OrderId}");
            var order = InMemoryRepository.Instance.GetById(command.OrderId);
            order.Status = OrderStatus.Cancelled;
            InMemoryRepository.Instance.Save(order);
        }
    }
}
