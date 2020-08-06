using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

//FIXME:大抵というか原則として、ViewとViewModelは一組である。
//そこで、一組にした名前空間を別に作ってViewsと階層構造にするというのはどうか。
//たぶんそのほうがいいのでは?
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;


namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// MainView.xaml の相互作用ロジック
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            MainViewModelMessanger.Default.RegisterAction<MainVewModelMessage>(this, ShowMaterilalSiteDialog);
        }

        private void ShowMaterilalSiteDialog(MainVewModelMessage msg)
        {
            var win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();

        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }
    }
}
