namespace Bank.Domain.Base
{
    /// <summary>
    /// Абстрактный класс модели
    /// </summary>
    /// <typeparam name="TKey">Тип идентификатора</typeparam>
    public abstract class Identity
    {
        /// <summary>
        /// Идентификационный номер
        /// </summary>
        public Guid UID { get; set; }

    }
}
