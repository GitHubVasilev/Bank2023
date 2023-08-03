using Bank.Domain.Base;

namespace Bank.Domain
{
    /// <summary>
    /// Модель данных клиента
    /// </summary>
    public class Customer : Auditable
    {
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; } = null!;
        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; } = null!;
        /// <summary>
        /// Отчество
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Телефон
        /// </summary>
        public string? Telephone { get; set; }
        /// <summary>
        /// Данные паспорта
        /// </summary>
        public string? Passport { get; set; }
    }
}
