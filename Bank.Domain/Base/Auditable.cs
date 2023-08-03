namespace Bank.Domain.Base
{
    /// <summary>
    /// Содержит свойства с изменениями сущности
    /// </summary>
    public class Auditable : Identity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Пользователь, создавший запись
        /// </summary>
        public string CreatedBy { get; set; } = null!;

        /// <summary>
        /// Дата последнего обновления
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Пользователь, изменивший запись
        /// </summary>
        public string? UpdatedBy { get; set; }
    }
}
