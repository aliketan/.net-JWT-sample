﻿namespace API.Utility.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Not found!")
        { }

        public NotFoundException(string message) : base(message)
        { }
    }
}
