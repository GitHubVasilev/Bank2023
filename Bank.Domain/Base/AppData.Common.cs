namespace Bank.Domain.Base
{
    public static partial class AppData
    {
        #region AccountsType
        public const string DepositeAccountTypeName = "Депозитный счет";
        public const string NoDepositeAccountTypeName = "Расчетный счет";
        #endregion

        #region UserNames
        public const string ManagerUser = "Менеджер";
        public const string ConsultantUser = "Консультант";
        #endregion
    }
}
