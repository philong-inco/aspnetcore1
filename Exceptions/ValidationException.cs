﻿namespace NetCrud2.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string? message) : base(message)
        {
        }
    }
}
