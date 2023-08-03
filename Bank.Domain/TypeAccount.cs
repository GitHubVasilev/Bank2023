using Bank.Domain.Base;

namespace Bank.Domain
{
    /// <summary>
    /// Тип Аккаунта
    /// </summary>
    public class TypeAccount : Identity
    {
        /// <summary>
        /// Название типа
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
