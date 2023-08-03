using Bank.Domain.Base;

namespace Bank.Domain
{
    /// <summary>
    /// Модель данных о счете
    /// </summary>
    public class Account : Identity
    {
        /// <summary>
        /// Название счета
        /// </summary>
        public string Name { get; set; } = null!;
        /// <summary>
        /// Дата открытия счета
        /// </summary>
        public DateTime DateOpen { get; set; }
        /// <summary>
        /// Процентр
        /// </summary>
        public int Procent { get; set; }
        /// <summary>
        /// Количество валютной единицы
        /// </summary>
        public decimal CountMonetaryUnit { get; set; }
        /// <summary>
        /// Тип аккаунта
        /// </summary>
        public TypeAccount TypeAccount { get; set; } = null!;
        /// <summary>
        /// Идентификатор типа аккаутна
        /// </summary>
        public Guid TypeAccountId { get; set; }
        /// <summary>
        /// Определяет можно ли производить денежные операции
        /// </summary>
        public bool IsLock { get; set; }
        /// <summary>
        /// Определяет закрыт ли счет. True - закрыт
        /// </summary>
        public bool IsClose { get; set; }
        /// <summary>
        /// Идентификатор клиента
        /// </summary>
        public Guid? ClientId { get; set; }
    }
}
