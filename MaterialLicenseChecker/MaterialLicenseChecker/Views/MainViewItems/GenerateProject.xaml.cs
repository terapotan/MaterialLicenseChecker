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
using MyException = MaterialLicenseChecker.MyException;

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
            Dialog.Description = "プロジェクトファイルを作成する、場所を選択";
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
            if (string.IsNullOrWhiteSpace(ProjectName.Text))
            {
                MessageBox.Show("プロジェクト名を入力してください", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ProjectFileLocation.Text))
            {
                MessageBox.Show("プロジェクト作成先を入力してください。", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            //プロジェクト名にファイル名として使用できない文字が含まれている場合
            if (!(ProjectName.Text.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) < 0))
            {
                MessageBox.Show("プロジェクト名に不正な文字が含まれています。\nプロジェクト名を変更してください。", "作成失敗", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                var cmd = new GenerateProjectFile();
                cmd.GeneratedProjectFileAbsolutePath = ProjectFileLocation.Text;
                cmd.ProjectName = ProjectName.Text;

                RecevierOfViewModel.CommandViewModelTo(cmd);

                //これが原因だぁーーーーーー！！！！！！！
                MaterialLicenseChecker.Views.CMainView.IReceiverCommandFromView ReceiverOfView = (MaterialLicenseChecker.Views.CMainView.IReceiverCommandFromView)this.Owner;
                MaterialLicenseChecker.Views.CMainView.LoadProjectFiles ViewCmd = new MaterialLicenseChecker.Views.CMainView.LoadProjectFiles();
                ViewCmd.LoadedProjectFileAbsolutePath = ProjectFileLocation.Text + "\\" + ProjectName.Text + "\\" + ProjectName.Text + ".projm";
                ViewCmd.ProjectName = ProjectName.Text;
                ReceiverOfView.CommandViewTo(ViewCmd);
                Close();
            }
            catch (MyException.SameNameProjectExistsException)
            {
                MessageBox.Show("既に同名のプロジェクトが存在します。\nプロジェクト名を変更してください。", "作成失敗", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
    }
}
