using System;
using System.Runtime.Serialization;

namespace UniversitySystem.Manager
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