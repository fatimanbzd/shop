using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common.Results
{
    public sealed class Result<T> : Result
    {
        private Result(
            T value,
            bool isSuccess,
            Error error)
            : base(isSuccess, error)
        {
            Value = value;
        }

        public T Value { get; }

        public static Result<T> Success(T value)
            => new(value, true, Error.None);

        public new static Result<T> Failure(Error error)
            => new(default!, false, error);
    }
}
