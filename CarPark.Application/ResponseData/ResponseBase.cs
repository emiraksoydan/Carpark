using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.ResponseData
{
    public class ResponseBase
    {
        public bool Success { get; init; }
        public string? Message { get; init; }
    }
}
