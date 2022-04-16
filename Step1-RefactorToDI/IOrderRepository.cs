namespace Step0_SingletonsEverywhere
{
    public interface IOrderRepository
    {
        Order GetById(int id);
        void Save(Order order);
    }
}