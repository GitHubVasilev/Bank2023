namespace Bank.Application.Accounts.ViewModels.Base
{
    public class BaseAccountPostViewModel
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
        public Guid UIDClient { get; init; }
        /// <summary>
        /// Идентификатор типа аккаутна
        /// </summary>
        public Guid TypeAccountId { get; set; }
    }
}
