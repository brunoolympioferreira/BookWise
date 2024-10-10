using System.Runtime.Serialization;

namespace BookWise.Core.Exceptions;
public class ValidationErrorsException : BookWiseException
{
    public List<string> ErrorMessages { get; set; }
    public ValidationErrorsException(List<string> errorMessages) : base(string.Empty)
    {
        ErrorMessages = errorMessages;
    }
    public ValidationErrorsException(string errorMessage) : base(errorMessage) { }
    protected ValidationErrorsException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
