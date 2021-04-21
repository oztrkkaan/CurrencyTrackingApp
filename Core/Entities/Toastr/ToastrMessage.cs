using Core.Constants.Enum;
using System;

namespace Core.Entities.Toastr
{
    [Serializable]
    public class ToastrMessage
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public ToastrEnum.Type ToastType { get; set; }
        public bool IsSticky { get; set; }
    }
}
