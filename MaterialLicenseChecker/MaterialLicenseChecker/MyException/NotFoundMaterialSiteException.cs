using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.MyException
{

    [Serializable]
    public class NotFoundMaterialSiteException : Exception
    {
        public NotFoundMaterialSiteException() { }
        public NotFoundMaterialSiteException(string message) : base(message) { }
        public NotFoundMaterialSiteException(string message, Exception inner) : base(message, inner) { }
        protected NotFoundMaterialSiteException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
