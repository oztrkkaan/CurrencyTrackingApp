using Core.Extensions;
using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Message { get; }
        IList<ValidationError> ValidationErrors { get; }
    }
}
