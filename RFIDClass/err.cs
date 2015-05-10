using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RFIDClass
{
    /// <summary>
    /// 丟出沒有訂定ServerIP的訊息
    /// </summary>
    [Serializable]
    
    public class NoServerIPException : Exception
    {
        public NoServerIPException() : base("未訂定ServerIP") { }
        public NoServerIPException(string message) : base(message) { }
        public NoServerIPException(string message , Exception inner) : base(message , inner) { }
        protected NoServerIPException(
          System.Runtime.Serialization.SerializationInfo info ,
          System.Runtime.Serialization.StreamingContext context)
            : base(info , context) { }
        
    }
}
