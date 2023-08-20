namespace Bank.Application.Common
{
    public abstract class WrapperResult
    {
        public string? Message { get; set; }
        public List<Exception> ExceptionObjects { get; set; } = new List<Exception>();
        public bool IsSuccess
        {
            get => ExceptionObjects is null;
        }

        public static WrapperResult<T> Build<T>(T result, string? message = null, List<Exception>? error = null)
        {
            return new WrapperResult<T>
            {
                Result = result,
                Message = message,
                ExceptionObjects = error ?? new List<Exception>(),
            };
        }

        public static WrapperResult<T> Build<T>()
        {
            return new WrapperResult<T>
            {
                Result = default,
            };
        }
    }

    public class WrapperResult<T> : WrapperResult
    {
        public T? Result { get; set; }
    }
}
