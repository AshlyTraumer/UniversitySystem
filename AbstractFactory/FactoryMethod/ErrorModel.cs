using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory.FactoryMethod
{
    public class ErrorModel
    {
        public bool State { get; private set; }
        public string Message { get; private set; }

        private ErrorModel(bool state, string message)
        {
            State = state;
            Message = message;
        }

        public static ErrorModel Success()
        {
            return new ErrorModel(true, null);
        }

        public static ErrorModel Error( string message)
        {
            return new ErrorModel(false, message);
        }
    }
}
