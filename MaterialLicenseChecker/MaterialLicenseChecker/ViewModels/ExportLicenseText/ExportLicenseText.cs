using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialLicenseChecker.ViewModels.ExportLicenseText
{
    public class ExportLicenseText
    {
        public ExportLicenseText()
        {
            MateiralNameList = new List<string>();
        }
        public string ExportedLicenseTextFilePath = "";
        public List<string> MateiralNameList;
    }
}
