using System;

namespace UniversitySystem.Core.Exceptions
{
    [Serializable]
    internal class UniversalException : Exception
    {        

        public UniversalException(string message) : base(message)
        {
        }

        public UniversalException(string message, Exception innerException) : base(message, innerException)
        {
        }
        
    }
}