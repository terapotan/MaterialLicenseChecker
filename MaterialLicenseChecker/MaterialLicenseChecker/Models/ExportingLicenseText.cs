using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace MaterialLicenseChecker.Models
{
    class ExportingLicenseText
    {
        private string ExportingLicenseTextFilePath = "";

        public ExportingLicenseText(string FilePath)
        {
            ExportingLicenseTextFilePath = FilePath;
        }

        public void WriteSomething()
        {
            Encoding unicodeEnc = Encoding.UTF8;
            using (StreamWriter writer = new StreamWriter(ExportingLicenseTextFilePath,false,unicodeEnc))
            {
                writer.WriteLine("何かを新しく書き込む。");
            }
        }
   
    }

}
