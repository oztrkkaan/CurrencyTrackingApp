using Core.Constants.Enum;
using System;
using System.Collections.Generic;

namespace Core.Entities.Toastr
{
    [Serializable]
    public class ToastrOption
    {
        public ToastrOption()
        {
            ToastrMessages = new List<ToastrMessage>();
            ShowNewestOnTop = true;
            ShowCloseButton = false;
        }

        public bool ShowNewestOnTop { get; set; }
        public bool ShowCloseButton { get; set; }
        public List<ToastrMessage> ToastrMessages { get; set; }

        public ToastrMessage AddToastrMessage(string title, string message, ToastrEnum.Type toastType)
        {
            var toast = new ToastrMessage()
            {
                Title = title,
                Message = message,
                ToastType = toastType
            };
            ToastrMessages.Add(toast);
            return toast;
        }


    }
}
