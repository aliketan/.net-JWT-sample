namespace API.Persistence.Validations.Contracts
{
    public interface IMessageProvider
    {
        public string NotEmpty(string field);

        public string MaxLength(string field, int length);

        public string MinLength(string field, int length);

        public string InvalidEmailAddress();

        public string WeekPassword();

        public string GreaterThanOrEqualTo(string field, int number);

        public string GreaterThan(string field, int number);

        string PrecisionScale(string field);
    }
}
