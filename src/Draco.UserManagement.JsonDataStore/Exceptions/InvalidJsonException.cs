using System;

namespace Draco.UserManagement.JsonDataProvider.Exceptions
{
    public class InvalidJsonException : Exception
    {
        public InvalidJsonException(string message) : base(message)
        {

        }
    }
}
