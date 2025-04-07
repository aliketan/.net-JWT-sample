namespace API.Persistence.Validations.Concrete
{
    using Contracts;

    public class MessageProvider : IMessageProvider
    {
        public string InvalidEmailAddress() => "Invalid e-mail address.";

        public string MaxLength(string field, int length) => $"The {field} can be a maximum of {length} characters long.";

        public string MinLength(string field, int length) => $"The {field} must be at least {length} characters long.";

        public string NotEmpty(string field) => $"The {field} cannot be empty.";

        public string WeekPassword() => "Your password must be minimum 6 characters and contain, one uppercase digit and one digit.";

        public string GreaterThanOrEqualTo(string field, int number) => $"{field} must be greater than or equal to {number}.";

        public string GreaterThan(string field, int number) => $"{field} must be greater than {number}.";

        public string PrecisionScale(string field) => $"{field} must have a maximum of 10 digits with 2 decimal places.";
    }
}
