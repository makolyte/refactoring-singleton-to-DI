namespace Step0_SingletonsEverywhere
{
    public class CancelOrderHandler
    {
        #region Singleton pattern
        private static CancelOrderHandler instance;
        public static CancelOrderHandler GetInstance(ILogger logger)
        {
            if (instance == null)
            {
                instance = new CancelOrderHandler(logger);
            }
            return instance;
        }
        private CancelOrderHandler(ILogger logger) 
        {
            Logger = logger;
        }
        #endregion

        private readonly ILogger Logger;

        public void Handle(CancelOrder command)
        {
            var order = InMemoryRepository.GetInstance(Logger).GetById(command.OrderId);

            Logger.Log($"Cancelling order {command.OrderId}");
            order.Status = OrderStatus.Cancelled;

            InMemoryRepository.GetInstance(Logger).Save(order);
        }
    }
}
