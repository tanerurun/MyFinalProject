using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErroDataResult<T> : DateResult<T>
    {
        public ErroDataResult(T data, string message) : base(data, false, message)
        {

        }

        public ErroDataResult(T data) : base(data, false)
        {

        }

        public ErroDataResult(string message) : base(default, false, message)
        {

        }

        public ErroDataResult() : base(default, false)
        {

        }
    }
}
