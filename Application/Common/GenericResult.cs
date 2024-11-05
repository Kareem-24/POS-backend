using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Data { get; private set; }
        public string? ErrorMessage { get; private set; }

        public static Result<T> SuccessResult(T data)
        {
            return new Result<T> { IsSuccess = true, Data = data };
        }

        public static Result<T> FailureResult(string errorMessage)
        {
            return new Result<T> { IsSuccess = false, Data = default, ErrorMessage = errorMessage };
        }
    }
}
