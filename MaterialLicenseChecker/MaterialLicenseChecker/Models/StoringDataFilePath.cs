﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MaterialLicenseChecker.Models
{
    /// <summary>
    /// 各種データを保管しているファイルへの絶対パスを格納しているクラス。
    /// Singletonクラスである点に注意。
    /// </summary>
    public sealed class StoringDataFilePath
    {
        private static readonly StoringDataFilePath _singleInstance = new StoringDataFilePath();

        public static StoringDataFilePath GetInstance()
        {
            return _singleInstance;
        }

        private StoringDataFilePath() { 
 
        }

        public void StoreFilePath(ProjectFileData Data,string ProjectFileAbsolutePath)
        {
            //以下実行ファイルが存在するディレクトリの絶対パスを取得
            //Assembly assembly = Assembly.GetEntryAssembly();
            //string runingFilePath = assembly.Location;
            //System.IO.FileInfo fi = new System.IO.FileInfo(runingFilePath);
            //string runingDirectoryAbsolutePath = fi.Directory.FullName;

            LicenseTextFileAbsolutePath = ProjectFileAbsolutePath + Data.LicenseTextFileRelativePath;
            MaterialListFileAbsolutePath = ProjectFileAbsolutePath + Data.MaterialListFileRelativePath;
            LicenseTextInputsItemsFileAbsolutePath = ProjectFileAbsolutePath + Data.LicenseTextInputsItemsRelativePath;
        }

        public string LicenseTextFileAbsolutePath;
        public string MaterialListFileAbsolutePath;
        public string LicenseTextInputsItemsFileAbsolutePath;

    }
}
