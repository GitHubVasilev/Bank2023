namespace Bank.Application.Common.Exceptions
{
    public class ManagersNotFoundException : Exception
    {
        public ManagersNotFoundException(string nameClass)
            : base($"Menegers for class {nameClass} not founded")
        {

        }
    }
}
