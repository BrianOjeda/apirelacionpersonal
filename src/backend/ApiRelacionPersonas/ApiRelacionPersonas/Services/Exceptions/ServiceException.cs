namespace ApiRelacionPersonas.Services
{
    public class ServiceException : Exception
    {
        public ServiceException(string message)
            : base(message)
        {
        }

        public ServiceException(string message, Exception e)
            : base(message, e)
        {
        }
    }

}
