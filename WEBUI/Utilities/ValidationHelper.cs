using Core.Extensions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBUI.Utilities
{
    public static class ValidationHelper
    {
        public static void ValidateModel(this ModelStateDictionary modelState, IList<ValidationError> validationErrors, string rootTypeName = null)
        {
            foreach (var error in validationErrors)
                modelState.AddModelError(string.IsNullOrEmpty(rootTypeName) ? error.TypeName : rootTypeName + "." + error.TypeName + "." + error.PropertyName, error.ErrorMessage);
        }
    }
}
