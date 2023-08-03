namespace Bank.Application.Interfaces.Customers
{
    public interface ICustomerFactory<in T, out K>
    {
        K GetCustomerFromUser(T entity, string userName);
    }
}
