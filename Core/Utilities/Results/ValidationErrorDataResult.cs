using Core.Extensions;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ValidationErrorDataResult<T> : DataResult<T>
    {
        public ValidationErrorDataResult(T data, IList<ValidationError> validationErrors) : base(data, false, validationErrors)
        {
        }
        public ValidationErrorDataResult(T data, string message, IList<ValidationError> validationErrors) : base(data, false, message, validationErrors)
        {
        }
    }
}
