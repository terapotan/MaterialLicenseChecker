using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker
{
    class BaseEventMessage
    {
        public BaseEventMessage(object sender)
        {
            Sender = sender;
        }

        public object Sender { get; protected set; }
    }
}
