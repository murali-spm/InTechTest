using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace InTechCommon.DTO
{
    public class ResponseDto()
    { 
        public int StatusCode { get; set; }
        public string Status { get; set; }
        public object? Data { get; set; }
        public string Message { get; set; }
        public ResponseDto(int statusCode, string status, object? data, string message ) : this() {
            StatusCode = statusCode;
            Status = status;
            Data = data;
            Message = message;
        }
        public ResponseDto(int statusCode, string status, object? data):this()
        {
            StatusCode = statusCode;
            Status = status;
            Data = data;
        }
    }
}
