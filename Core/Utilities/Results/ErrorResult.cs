using Core.Extensions;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {
        }
        public ErrorResult(string message) : base(false, message)
        {
        }
        public ErrorResult(IList<ValidationError> validationErrors) : base(false, validationErrors)
        {
        }

        public ErrorResult(string message, IList<ValidationError> validationErrors) : base(false, message, validationErrors)
        {
        }


    }
}
