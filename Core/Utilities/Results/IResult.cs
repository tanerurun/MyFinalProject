using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    //temel voidler için başlangıc
    public interface IResult
    {
           bool Success { get; }//başarlı mı başarısız mı  true false
        //get sadece okunabilir.
        //set yazmak için.
        string Message { get; }
    }
}
