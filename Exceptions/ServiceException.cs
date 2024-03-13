namespace CitasMedico.Exceptions
{
    public enum ErrorType
    {
        NotFound,
        BadRequest,
        UnexpectedError
    }

    public class ServiceException : Exception
    {
        private Exception? innerException;

        public ErrorType Error { get; set; }
        public ServiceException(ErrorType error) 
        {
            Error = error;
        }
        public ServiceException(ErrorType error, String message) : base(message)
        {
            Error = error;
        }

        public ServiceException(ErrorType error, String message, Exception? innerException) : base(message, innerException)
        {
            this.innerException = innerException;
        }
    }
}