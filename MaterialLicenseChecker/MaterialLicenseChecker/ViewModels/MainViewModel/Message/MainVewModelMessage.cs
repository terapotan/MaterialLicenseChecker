using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker;

namespace MaterialLicenseChecker.ViewModels
{
    class MainVewModelMessage : BaseMessage
    {
        public MainVewModelMessage(object sender) : base(sender)
        {

        }
        //今は何も渡さない。このクラスを使ってM,VMの双方向のやりとりを実現する。
    }
}
