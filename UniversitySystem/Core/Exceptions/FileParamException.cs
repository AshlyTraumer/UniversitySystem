using System;
using System.Runtime.Serialization;

namespace UniversitySystem.Core.Csvs
{
    [Serializable]
    internal class FileParamException : Exception
    {
        public FileParamException()
        {
        }

        public FileParamException(string message) : base(message)
        {
        }

        public FileParamException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FileParamException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}