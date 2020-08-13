using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.VAndVMCommons.ExportLicenseText;
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;
using System.Windows;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.ExportLicenseText
{
    class ExportLicenseTextViewModel
    {
        public ExportLicenseTextViewModel()
        {
            ExportLicenseTextEventMessenger.Default
                .RegisterAction<ClickedExportLicenseTextEventMessage>(this, ClickedExportLicenseTextEvent);
        }


        private void ClickedExportLicenseTextEvent(ClickedExportLicenseTextEventMessage msg)
        {
            ExportingLicenseText Instance = new ExportingLicenseText(msg.ExportedLicenseTextFilePath);
            ClassStoreLicenseText LicenseTextInstance = new ClassStoreLicenseText();
            GetMaterialListMessage MaterialListMessage = new GetMaterialListMessage(this);

            MainViewModelMessanger.Default.ExecuteAction(this, MaterialListMessage);

            var list = LicenseTextInstance.GetLicenseTextLists(LicenseTextInstance.GetMaterialSiteList());
            
            string strs = "";
            foreach (var str in list)
            {
                strs += (str + '\n');
            }

            Instance.WriteLicenseTextFile(strs);

            strs = "";
            foreach (var str in MaterialListMessage.MateiralNameList)
            {
                strs += (str + '\n');
            }

            MessageBox.Show(strs);

        }
    }
}
