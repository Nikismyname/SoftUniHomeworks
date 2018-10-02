namespace SIS.HTTP.Exceptions
{
    using System;

    public class InternalServerErrorException : Exception
    {
        private const string message = "The Server has encountered an error.";

        public InternalServerErrorException() :base(message)
        {
        }
    }
}
