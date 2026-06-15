using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task22.Models
{
    public  class Result<T>
    {
        public bool IsSuccess { get; set; }
        public T Value { get; set; }
        public string Error { get; set; }

        public static Result<T> Ok(T value)
        {
            var Result = new Result<T>();
            Result.IsSuccess = true;
            Result.Value = value;
            return Result;

        }
        public static Result<T>Fail(string ErrorMessage)
        {
            var Result = new Result<T>();
            Result.Error = ErrorMessage;
            Result.IsSuccess = false;
            return Result;
        }
    }
}
