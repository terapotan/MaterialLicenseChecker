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
        }
        public string ExportedLicenseTextFileAbsolutePath = "";
        public string HeaderText = "";
        public string FooterText = "";
        public int ErrorNum = 0;//出力するものが一件もない場合、-1が入る。正常に出力された場合、0が入る。
        public List<string> MaterialNameList;
    }
}
