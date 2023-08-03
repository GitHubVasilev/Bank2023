using Bank.Application.Accounts.ViewModels.Base;

namespace Bank.Application.Interfaces.Accounts
{
    /// <summary>
    /// Интрефейс с методами управления счетами
    /// </summary>
    /// <typeparam name="K">Тип viewModel</typeparam>
    public interface IAccountHeandler<K>
        where K : BaseAccountPostViewModel
    {
        /// <summary>
        /// Создает счет
        /// </summary>
        /// <param name="account">Данные о создаваемом счете</param>
        public Task CreateAccountAsync(K account, CancellationToken token);
    }
}
