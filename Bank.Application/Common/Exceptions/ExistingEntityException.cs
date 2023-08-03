namespace Bank.Application.Common.Exceptions
{
    public class ExistingEntityException : Exception
    {
        public ExistingEntityException(string type, Guid uid)
            :base($"Entity {type} with Guid {uid} is already existing")
        {
            
        }
    }
}
