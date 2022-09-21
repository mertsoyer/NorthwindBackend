using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        /// <summary>
        /// burada this kullanılarak eger contructordan hem success hem message gönderilmiş olursa this ile ikinci constructor da tetiklenmiş oluyor, eğer sadece success gönderilirse alttaki constructor devreye giriyor yani sadece success i set eder.
        /// </summary>
        /// <param name="success"></param>
        /// <param name="message"></param>
        public Result(bool success,string message):this(success)
        {
            Message = message;
        }

        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
