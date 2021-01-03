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
using MaterialLicenseChecker.ViewModels.GenerateProjectDialog;

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// GenerateProject.xaml の相互作用ロジック
    /// </summary>
    public partial class GenerateProject : Window
    {
        private IReceiverCommandFromView RecevierOfViewModel;
        public GenerateProject()
        {
            InitializeComponent();
            RecevierOfViewModel = new GenerateProjectDialogViewModel();
        }

        private void ClickedReferenceButton(object sender, RoutedEventArgs e)
        {
            var Dialog = new System.Windows.Forms.FolderBrowserDialog();
            Dialog.Description = "素材が置かれている場所を選択";
            if (Dialog.ShowDialog() != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            ProjectFileLocation.Text = Dialog.SelectedPath;
        }

        private void ClickedCancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ClickedGenerateButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("作成ボタンがクリックされました");
            Close();
        }
    }
}
