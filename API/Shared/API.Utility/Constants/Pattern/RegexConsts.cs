namespace API.Utility.Constants.Pattern
{
    public class RegexConsts
    {
        public const string PasswordRegexPattern = @"(?=^.{8,}$)(?=.*\d)(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$";
    }
}
