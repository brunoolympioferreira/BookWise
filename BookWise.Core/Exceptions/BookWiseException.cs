using System.Runtime.Serialization;

namespace BookWise.Core.Exceptions;
[Serializable]
public class BookWiseException : SystemException
{
    public BookWiseException(string message) : base(message) { }
    protected BookWiseException(SerializationInfo info, StreamingContext context) : base(info, context) { }
}
