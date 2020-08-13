using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.VAndVMCommons.MainViewModel
{
    class GetMaterialListMessage : BaseMessage
    {
        public GetMaterialListMessage(object sender) : base(sender)
        {
            MateiralNameList = new List<string>();
        }

        public List<string> MateiralNameList;
    }
}
