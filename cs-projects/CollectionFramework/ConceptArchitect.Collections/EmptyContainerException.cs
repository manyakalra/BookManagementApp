using System.Runtime.Serialization;

namespace ConceptArchitect.Collections
{
    [Serializable]
    public class EmptyContainerException : Exception
    {
        public EmptyContainerException()
        {
        }

        public EmptyContainerException(string? message) : base(message)
        {
        }

        public EmptyContainerException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EmptyContainerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}