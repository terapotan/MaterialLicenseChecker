using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Reflection;
using System.Xml.Linq;
using System.Security;
using System.IO;

namespace MaterialLicenseChecker.Models
{
    public class LicenseTextInputsItemsFileAdapter
    {
        private XDocument _loadedXMLFileInstance;

        public LicenseTextInputsItemsFileAdapter()
        {
            _loadedXMLFileInstance = XDocument.Load(StoringDataFilePath.GetInstance().LicenseTextInputsItemsFileAbsolutePath);
        }
    }
}
