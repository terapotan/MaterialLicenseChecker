using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialLicenseChecker;
using System.Windows;
using MaterialLicenseChecker.Models;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
   public class MainViewModel : IReceiverCommandFromView
    {
        public MainViewModel()
        {

        }

        public void CommandViewModelTo(GetMaterialList cmd)
        {
            ActiveProjectData.GetInstance().MateiralListLogicalData.GetMaterialList(cmd.MaterialDataList);
        }

        public void CommandViewModelTo(LoadProjectFile cmd)
        {
            ProjectFileReader Reader = new ProjectFileReader(cmd.LoadedProjectFileAbsolutePath);
            ProjectFileData Data = new ProjectFileData();

            Data = Reader.LoadProjectFilePathData();

            //フルパス名からディレクトリ名を取得
            System.IO.FileInfo fi = new System.IO.FileInfo(cmd.LoadedProjectFileAbsolutePath);
            string ProjectFileDirectoryAbsolutePath = fi.Directory.FullName;

            StoringDataFilePath.GetInstance().StoreFilePath(Data, ProjectFileDirectoryAbsolutePath);

            ActiveProjectData.GetInstance().MaterialSiteListData = new MaterialSiteListData();
            ActiveProjectData.GetInstance().MateiralListLogicalData = new MaterialListLogicalData();
        }

        public void CommandViewModelTo(GetProjectName cmd)
        {
            ProjectFileReader Reader = new ProjectFileReader(cmd.LoadedProjectFileAbsolutePath);
            cmd.FetchedProjectName = Reader.LoadProjectName();
        }

        void IReceiverCommandFromView.CommandViewModelTo(DeleteMaterialDataOfFile cmd)
        {
            //!!!:自前でインスタンスを作成しないこと！！！
            //見つかりづらい、質の悪いバグを生み出す可能性がある
            //var FileInstance = new MaterialListFileAdapter();
            ActiveProjectData.GetInstance().MateiralListLogicalData.DeleteMaterialData(cmd.ListFromDeletedMaterialName);
        }

        void IReceiverCommandFromView.CommandViewModelTo(SetActiveProjectDataToViewModel cmd)
        {
            throw new NotImplementedException();
        }

    }
}
