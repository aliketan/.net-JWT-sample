using FluentValidation.Results;

namespace API.Utility.Results.Concrete
{
    using Enums.ComplexTypes;
    using Contracts;
    using Enums.Extenders;

    public class ValidationResult : IValidationResult
    {
        public ValidationResult(IEnumerable<ValidationFailure> errors, ResultStatus status = ResultStatus.Error)
        {
            Status = status.ToText();
            Response = errors?.Select(s => s.ErrorMessage).FirstOrDefault();
        }

        public string Status { get; }

        public string Response { get; }
    }
}
