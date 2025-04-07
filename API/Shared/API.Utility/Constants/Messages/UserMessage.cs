namespace API.Utility.Constants.Messages
{
    public static class UserMessage
    {
        public static class Register
        {
            public const string Success = "User account has been created.";
            public const string AlreadyExists = "An account already exists with this email address.";
            public const string InvalidUserRole = "Invalid user role(s)";
        }

        public static class Update
        {
            public const string Success = "Your account has been updated.";
            public const string PasswordChanged = "Your password has been changed successfully";
        }

        public static class Login
        {
            public const string InvalidUsernameOrPassword = "Invalid username or password.";
        }

        public const string UserNotFound = "User not found!";
    }
}
