using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MaterialLicenseChecker.Models
{
    public class ProjectFileGenerator
    {
        private static readonly string WritingProjectFileText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<document fileVersion = ""0"">

  <projectName></projectName>

  <fileNames>
    <licenseTextFileName>/MaterialCreationSiteList.xml</licenseTextFileName>
    <materialListFileName>/MaterialList.xml</materialListFileName>
    <licenseTextInputsItems>/LicenseTextInputsItems.xml</licenseTextInputsItems>
  </fileNames>

</document>
";

        private string WritingMaterialListFileText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<document fileVersion = ""0"">

</document>
";

        private string WritingMaterialCreationSiteListFileText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<document fileVersion = ""0"">

</document>
";
        private string WritingLicenseTextInputsItemsFileText = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<document fileVersion = ""0"">
  <Header></Header>
  <Footer></Footer>
  <ExportFolder></ExportFolder>
  <ExportingFileName></ExportingFileName>
</document>
";

        public void GenerateProjectFiles(string GeneratedProjectFileAbsolutePath, string ProjectName)
        {
            string GeneratedFolderPath = GeneratedProjectFileAbsolutePath + "\\" + ProjectName;
           
            if (Directory.Exists(GeneratedProjectFileAbsolutePath + "\\" + ProjectName))
            {
                throw new MyException.SameNameProjectExistsException();
            }

            Directory.CreateDirectory(GeneratedFolderPath);

            File.WriteAllText(GeneratedFolderPath + "\\" + "ProjectFile.projm",                   WritingProjectFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "MaterialList.xml",                  WritingMaterialListFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "MaterialCreationSiteList.xml",      WritingMaterialCreationSiteListFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "LicenseTextInputsItems.xml",        WritingLicenseTextInputsItemsFileText);

            ProjectFileWriter Writer = new ProjectFileWriter(GeneratedFolderPath + "\\" + "ProjectFile.projm");
            Writer.SetProjectName(ProjectName);
        }
    }
}
