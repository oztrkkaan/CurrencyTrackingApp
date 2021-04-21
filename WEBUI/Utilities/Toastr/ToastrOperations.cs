using Core.Constants.Enum;
using Core.Entities.Toastr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBUI.Utilities.Toastr
{
    public static class ToastrOperations
    {
        public static ToastrMessage AddToastrMessage(this Controller controller, string title, string message, ToastrEnum.Type toastrType = ToastrEnum.Type.Info)
        {
            ToastrOption toastr = controller.TempData["Toastr"] as ToastrOption;
            toastr = toastr ?? new ToastrOption();

            var toastMessage = toastr.AddToastrMessage(title, message, toastrType);
            controller.TempData["Toastr"] = JsonConvert.SerializeObject(toastr);
            return toastMessage;
        }
    }
}
