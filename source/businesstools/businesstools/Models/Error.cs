using System;
namespace businesstools.Models
{
    public class Error
    {
        public Error()
        {
        }

        public Error(int code, int message) {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }
        public string Message { get; set; }
    }
}
