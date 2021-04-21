using Core.Extensions;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ValidationErrorResult : Result
    {
        public ValidationErrorResult()
        {
        }
        public ValidationErrorResult(IList<ValidationError> validationErrors) : base(false, validationErrors)
        {
        }
        public ValidationErrorResult(string message, IList<ValidationError> validationErrors) : base(false, message, validationErrors)
        {
        }

    }
}
