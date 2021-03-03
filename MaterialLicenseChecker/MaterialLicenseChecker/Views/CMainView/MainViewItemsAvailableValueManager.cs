using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialLicenseChecker.Views;

namespace MaterialLicenseChecker.Views.CMainView
{
    public class MainViewItemsAvailableValueManager
    {
        private MainView MainViewInstance;

        public MainViewItemsAvailableValueManager(MainView InputInstance)
        {
            MainViewInstance = InputInstance;
        }

        public void EnableMainViewItems()
        {
            MainViewInstance.MaterialMenu.IsEnabled                 = true;
            MainViewInstance.MaterialCreationsiteMenu.IsEnabled     = true;
            MainViewInstance.ExportLicenseTextButton.IsEnabled      = true;
            MainViewInstance.AddMaterialButton.IsEnabled            = true;
            MainViewInstance.RemoveMaterialMenu.IsEnabled           = true;
        }

    }
}