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
            LoadFile();
        }

        private void LoadFile()
        {
            _loadedXMLFileInstance = XDocument.Load(StoringDataFilePath.GetInstance().LicenseTextInputsItemsFileAbsolutePath);

        }
        /// <summary>
        /// ファイルから入力項目を読み込む。
        /// </summary>
        /// <param name="MaterialName"></param>
        /// <returns></returns>
        public LicenseTextInputsItemsData LoadInputsItemData()
        {
            LoadFile();

            LicenseTextInputsItemsData ReturnedLicenseTextInputsItemsData = new LicenseTextInputsItemsData();
            var LoadedInputsItemsElement = _loadedXMLFileInstance.XPathSelectElement("/document");

            ReturnedLicenseTextInputsItemsData.HeaderText           = LoadedInputsItemsElement.Element("Header").Value;
            ReturnedLicenseTextInputsItemsData.FooterText           = LoadedInputsItemsElement.Element("Footer").Value;
            ReturnedLicenseTextInputsItemsData.ExportingDirectory   = LoadedInputsItemsElement.Element("ExportFolder").Value;
            ReturnedLicenseTextInputsItemsData.FileName             = LoadedInputsItemsElement.Element("ExportingFileName").Value;

            return ReturnedLicenseTextInputsItemsData;
        }

        public void SaveInputsItemData(LicenseTextInputsItemsData WritingInputsItemData)
        {
            LoadFile();

            var LoadedInputsItemsElement = _loadedXMLFileInstance.XPathSelectElement("/document");

            LoadedInputsItemsElement.SetElementValue("Header", WritingInputsItemData.HeaderText);
            LoadedInputsItemsElement.SetElementValue("Footer", WritingInputsItemData.FooterText);
            LoadedInputsItemsElement.SetElementValue("ExportFolder", WritingInputsItemData.ExportingDirectory);
            LoadedInputsItemsElement.SetElementValue("ExportingFileName", WritingInputsItemData.FileName);

            _loadedXMLFileInstance.Save(StoringDataFilePath.GetInstance().LicenseTextInputsItemsFileAbsolutePath);

        }

    }
}
