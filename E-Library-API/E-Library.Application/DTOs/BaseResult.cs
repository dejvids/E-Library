using System;
using System.Collections.Generic;
using System.Text;

namespace E_Library.Application.DTOs
{
    public class BaseResult
    {
        public BaseResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get;}
        public string Message { get;}
    }
}