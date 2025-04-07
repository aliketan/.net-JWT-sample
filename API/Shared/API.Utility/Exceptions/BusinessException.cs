namespace API.Utility.Exceptions
{
    [Serializable]
    public class BusinessException:Exception
    {
        public BusinessException() : base("An error occurred! Please try again later.")
        { }

        public BusinessException(string message) : base(message)
        { }
    }
}
