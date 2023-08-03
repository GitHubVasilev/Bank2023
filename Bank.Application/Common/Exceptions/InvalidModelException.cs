namespace Bank.Application.Common.Exceptions
{
    public class InvalidModelException : Exception
    {
        public InvalidModelException(string name, object key)
            : base($"Model \"{name}\" ({key}) is invalid")
        {

        }
    }
}
