using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.ResponseData
{
    public class ServiceResult : ResponseBase
    {
        public static ServiceResult Ok(string? message = null)
            => new() { Success = true, Message = message };

        public static ServiceResult Fail(string message)
            => new() { Success = false, Message = message };

        public static ServiceResult<T> Ok<T>(T data, string? message = null)
            => ServiceResult<T>.Ok(data, message);

        public static ServiceResult<T> Fail<T>(string message)
            => ServiceResult<T>.Fail(message);
    }

    public class ServiceResult<T> : ServiceResult
    {
        public T? Data { get; init; }

        public new static ServiceResult<T> Ok(T data, string? message = null)
            => new() { Success = true, Message = message, Data = data };
        public new static ServiceResult<T> Fail(string message)
            => new() { Success = false, Message = message, Data = default };

    }
}
