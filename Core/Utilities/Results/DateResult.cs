using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DateResult<T> : Result, IDataResult<T>
    {
        public DateResult(T data,bool success,string message):base(success,message)
        {
            Data = data;
        }
        public DateResult(T data,bool success): base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
