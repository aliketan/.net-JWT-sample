namespace API.Utility.Results.Contracts
{
    public interface IValidationResult
    {
        public string Status { get; }
        public string Response { get; }
    }
}
