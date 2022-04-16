namespace Step0_SingletonsEverywhere
{
    public class CancelOrderHandler
    {
        #region Singleton pattern
        private static CancelOrderHandler instance;
        public static CancelOrderHandler GetInstance(ILogger logger, IOrderRepository repository)
        {
            if (instance == null)
            {
                instance = new CancelOrderHandler(logger, repository);
            }
            return instance;
        }
        private CancelOrderHandler(ILogger logger, IOrderRepository repository) 
        {
            Logger = logger;
            Repository = repository;
        }
        #endregion

        private readonly ILogger Logger;
        private readonly IOrderRepository Repository;

        public void Handle(CancelOrder command)
        {
            var order = Repository.GetById(command.OrderId);

            Logger.Log($"Cancelling order {command.OrderId}");
            order.Status = OrderStatus.Cancelled;

            Repository.Save(order);
        }
    }
}
