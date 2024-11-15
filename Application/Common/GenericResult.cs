using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public object? Data { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static Result SuccessResult(object data)
        {
            return new Result { IsSuccess = true, Data = data };
        }

        public static Result FailureResult(string errorMessage)
        {
            return new Result { IsSuccess = false, Data = default, ErrorMessage = errorMessage };
        }
    }
}
