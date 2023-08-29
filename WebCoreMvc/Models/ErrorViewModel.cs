using System;

namespace WebCoreMvc.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        public int Code { get; set; }
        public string Message { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }

}
