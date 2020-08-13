using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.VAndVMCommons.ExportLicenseText;
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
            Instance.WriteSomething();
        }
    }
}
