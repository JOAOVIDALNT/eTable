namespace eTable.API.Exceptions
{
    public class ErrorOnValidationException : eTableException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errorMessages) => ErrorMessages = errorMessages;
        
    }
}
