namespace Bank.Application.Accounts.ViewModels.Base
{
    /// <summary>
    /// Абстрактный объект для передачи данных о счете
    /// </summary>
    public abstract record BaseAccountViewModel
    {
        /// <summary>
        /// Идентификтатор счета
        /// </summary>
        public Guid UID { get; init; }
        /// <summary>
        /// Название счета
        /// </summary>
        public string? Name { get; init; }
        /// <summary>
        /// Идентификатор клиента которому принадлежит счет
        /// </summary>
        public Guid ClientId { get; init; }
        /// <summary>
        /// Дата открытия счета
        /// </summary>
        public DateTime DateOpen { get; init; }
        /// <summary>
        /// Идентификатор типа аккаутна
        /// </summary>
        public Guid TypeAccountId { get; init; }
        /// <summary>
        /// Название типа аккаунта
        /// </summary>
        public string? TypeAccountName { get; init; }
        /// <summary>
        /// Количество валютной единицы
        /// </summary>
        public decimal CountMonetaryUnit { get; init; }
        /// <summary>
        /// Определяет можно ли производить денежные операции
        /// </summary>
        public bool IsLock { get; init; }
        /// <summary>
        /// Определяет закрыт ли счет. True - закрыт
        /// </summary>
        public bool IsClose { get; init; }
    }
}
