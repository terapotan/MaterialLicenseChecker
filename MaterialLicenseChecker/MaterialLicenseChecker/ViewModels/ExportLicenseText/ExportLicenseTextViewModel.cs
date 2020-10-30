﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.ExportLicenseText
{
    class ExportLicenseTextViewModel : IReceiverCommandFromView
    {
        public ExportLicenseTextViewModel()
        {
        }

        public void CommandViewModelTo(ExportLicenseText cmd)
        {
            ExportingLicenseText Instance = new ExportingLicenseText(cmd.ExportedLicenseTextFilePath);
            MaterialSiteListFileAdapter LicenseTextInstance = new MaterialSiteListFileAdapter();
            ClassStoreMaterialList MaterialList = new ClassStoreMaterialList();

            var ConvertedInSiteName = new List<string>();

            //素材名をサイト名に変換
            foreach (var MaterialName in cmd.MateiralNameList)
            {
                ConvertedInSiteName.Add(MaterialList.FetchMaterialSiteGivenMaterialName(MaterialName));
            }

            IEnumerable<string> DistinctedResult = ConvertedInSiteName.Distinct();


            var list = LicenseTextInstance.GetLicenseTextLists(DistinctedResult);

            string strs = "";
            foreach (var str in list)
            {
                strs += (str + '\n');
            }

            Instance.WriteLicenseTextFile(strs);

        }


    }
}
