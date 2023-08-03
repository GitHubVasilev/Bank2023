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

        #region UserPermossions

        public const string FirstNameCustomerCanUpdate = "FirstNameCustomer";
        public const string LastNameCustomerCanUpdate = "LastNameCustomer";
        public const string PatronymicNameCustomerCanUpdate = "PatronymicCustomer";
        public const string TelephoneCustomerCanUpdate = "TelephoneCustomer";
        public const string PassportCustomerCanUpdate = "PassportCustomer";

        #endregion
    }
}
