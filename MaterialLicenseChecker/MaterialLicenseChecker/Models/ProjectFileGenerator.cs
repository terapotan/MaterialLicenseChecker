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

            File.WriteAllText(GeneratedFolderPath + "\\" + ProjectName + ".projm",                   WritingProjectFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "MaterialList.xml",                  WritingMaterialListFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "MaterialCreationSiteList.xml",      WritingMaterialCreationSiteListFileText);
            File.WriteAllText(GeneratedFolderPath + "\\" + "LicenseTextInputsItems.xml",        WritingLicenseTextInputsItemsFileText);

            //REMARK:ここのファイル名を変更する場合、この先の新規作成したプロジェクトファイルを読み込むところで
            //登場する、プロジェクト名も一緒に変更すること。
            //もし、変更しない場合、新規作成したプロジェクトファイルを読み込むところで、ソフトウェアがクラッシュしてしまう。

            ProjectFileWriter Writer = new ProjectFileWriter(GeneratedFolderPath + "\\" + ProjectName + ".projm");
            Writer.SetProjectName(ProjectName);
        }
    }
}