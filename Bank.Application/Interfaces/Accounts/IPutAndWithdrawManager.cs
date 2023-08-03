using Bank.Domain;

namespace Bank.Application.Interfaces.Accounts
{
    /// <summary>
    /// Содержит методы для пополнения и снятия средств со счетов.
    /// Звено обраточика цепочки обязанности
    /// </summary>
    public interface IPutAndWithdrawManager
    {
        /// <summary>
        /// Слудеющий менеджер для обработки
        /// </summary>
        IPutAndWithdrawManager? NextManager { get; set; }
        /// <summary>
        /// Пополняет указанный счет
        /// </summary>
        /// <param name="model">Счет для пополения</param>
        /// <param name="sum">Сумма пополнения</param>
        Account Put(Account model, decimal sum);
        /// <summary>
        /// Снимает средства со счета
        /// </summary>
        /// <param name="model">Счет для снятия</param>
        /// <param name="sum">Сумма снятия</param>
        Account Withdraw(Account model, decimal sum);
    }
}
