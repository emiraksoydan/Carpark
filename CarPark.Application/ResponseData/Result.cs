using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.ResponseData
{
    public class Result
    {
        public bool Success { get;  set; }
        public string? Message { get;  set; }

        public static Result Succeed(string? message = null)
            => new Result { Success = true, Message = message };

        public static Result Fail(string message)
            => new Result { Success = false, Message = message };
    }

    public class Result<T> : Result
    {
        public T? Data { get;  set; }

        public static Result<T> Succeed(T data, string? message = null)
            => new Result<T> { Success = true, Data = data, Message = message };

        public new static Result<T> Fail(string message)
            => new Result<T> { Success = false, Message = message, Data = default };
    }
}
