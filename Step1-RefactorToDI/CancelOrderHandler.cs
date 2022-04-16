namespace Step0_SingletonsEverywhere
{
    public class CancelOrderHandler
    {
        public CancelOrderHandler(ILogger logger, IOrderRepository repository) 
        {
            Logger = logger;
            Repository = repository;
        }
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
