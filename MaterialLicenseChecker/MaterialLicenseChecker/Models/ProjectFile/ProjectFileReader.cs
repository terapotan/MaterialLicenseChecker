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
    public class ProjectFileReader
    {
        private XDocument _loadedXMLFileInstance;

        public ProjectFileReader(string ProjectFileAbsolutePath)
        {
            _loadedXMLFileInstance = XDocument.Load(ProjectFileAbsolutePath);
        }

        /// <summary>
        /// ファイルから入力項目を読み込む。
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <returns></returns>
        public ProjectFileData LoadInputsItemData()
        {
            ProjectFileData ReturnedLicenseTextInputsItemsData = new ProjectFileData();
            var LoadedInputsItemsElement = _loadedXMLFileInstance.XPathSelectElement("/document");

            ReturnedLicenseTextInputsItemsData.LicenseTextFileRelativePath = LoadedInputsItemsElement.Element("licenseTextFileName").Value;
            ReturnedLicenseTextInputsItemsData.MaterialListFileRelativePath = LoadedInputsItemsElement.Element("materialListFileName").Value;
            ReturnedLicenseTextInputsItemsData.LicenseTextInputsItemsRelativePath = LoadedInputsItemsElement.Element("licenseTextInputsItems").Value;

            return ReturnedLicenseTextInputsItemsData;
        }
    }
}
