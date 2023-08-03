namespace Bank.Application.Interfaces.Customers
{
    public interface ICustomerFactoryFromUser<in T, K>
    {
        void Create(T model, ref K? viewModel, string userName);
    }
}
