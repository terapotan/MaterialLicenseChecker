using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MaterialLicenseChecker.Views;
using MainViewModel = MaterialLicenseChecker.ViewModels.MainViewModel;

namespace MaterialLicenseChecker
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var w = new MainView();
            w.Show();
        }
    }
}
