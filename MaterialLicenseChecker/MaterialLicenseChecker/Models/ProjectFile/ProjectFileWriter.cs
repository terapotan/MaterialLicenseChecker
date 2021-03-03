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
    public class ProjectFileWriter
    {
        private XDocument _loadedXMLFileInstance;
        private string projectFileAbsolutePath;

        public ProjectFileWriter(string ProjectFileAbsolutePath)
        {
            _loadedXMLFileInstance = XDocument.Load(ProjectFileAbsolutePath);
            projectFileAbsolutePath = ProjectFileAbsolutePath;
        }
        public void SetProjectName(string SetProjectName)
        {
            var LoadedInputsItemsElement = _loadedXMLFileInstance.XPathSelectElement("/document");
            LoadedInputsItemsElement.SetElementValue("projectName", SetProjectName);

            _loadedXMLFileInstance.Save(projectFileAbsolutePath);

        }
    }
}
