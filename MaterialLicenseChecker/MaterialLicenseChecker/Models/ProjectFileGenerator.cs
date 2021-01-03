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
        public void GenerateProjectFiles(string GeneratedProjectFileAbsolutePath, string ProjectName)
        {
            string GeneratedFolderPath = GeneratedProjectFileAbsolutePath + "\\" + ProjectName;
           
            if (Directory.Exists(GeneratedProjectFileAbsolutePath + "\\" + ProjectName))
            {
                throw new MyException.SameNameProjectExistsException();
            }

            Directory.CreateDirectory(GeneratedFolderPath);

        }
    }
}
