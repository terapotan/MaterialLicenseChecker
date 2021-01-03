using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.MyException
{
        [Serializable]
        public class SameNameProjectExistsException : Exception
        {
            public SameNameProjectExistsException() { }
            public SameNameProjectExistsException(string message) : base(message) { }
            public SameNameProjectExistsException(string message, Exception inner) : base(message, inner) { }
            protected SameNameProjectExistsException(
              System.Runtime.Serialization.SerializationInfo info,
              System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
        }
}
