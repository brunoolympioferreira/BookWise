namespace BookWise.Core.Exceptions;
public class NotFoundErrorsException : BookWiseException
{
    public string ErrorMessage { get; set; }
    public NotFoundErrorsException(string errorMessage) : base(errorMessage)
    {
        ErrorMessage = errorMessage;
    }
}
