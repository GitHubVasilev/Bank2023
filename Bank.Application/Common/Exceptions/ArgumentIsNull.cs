namespace Bank.Application.Common.Exceptions
{
    public class ArgumentIsNull : Exception
    {
        public ArgumentIsNull(string nameArgument) : base($"{nameArgument} is null")
        {
            
        }
    }
}
