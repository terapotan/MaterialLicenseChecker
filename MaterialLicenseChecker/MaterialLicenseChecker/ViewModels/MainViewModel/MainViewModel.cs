using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MaterialLicenseChecker;
using System.Windows;
using MaterialLicenseChecker.Models;
using MaterialLicenseChecker.VAndVMCommons.MainViewModel;

namespace MaterialLicenseChecker.ViewModels.MainViewModel
{
    class MainViewModel : IReceiverCommandFromView
    {
        public MainViewModel()
        {

            MainViewModelEventMessenger.Default.
                RegisterAction<ClickedRemoveMaterialFromListEventMessage>
                (this, ClickedRemoveMaterialFromListEvent);
        }


        private void ClickedRemoveMaterialFromListEvent(ClickedRemoveMaterialFromListEventMessage msg)
        {
            var FileInstance = new ClassStoreMaterialList();
            FileInstance.DeleteMaterialData(msg.ListFromDeletedMaterialName);
        }

        private string MakeDisplayedLicenseText()
        {
            ClassStoreLicenseText ClassStore = new ClassStoreLicenseText();
            List<string> FetchLicenseTextSite = new List<string>();



            return "";

        }

        void IReceiverCommandFromView.CommandViewModelTo(DeleteMaterialDataOfFile cmd)
        {
            var FileInstance = new ClassStoreMaterialList();
            FileInstance.DeleteMaterialData(cmd.ListFromDeletedMaterialName);
        }

        //以下のコードは「getはpublicにしたいが、setはprivateとしたい」目的で書かれている。
        private DelegateCommand _ShowDialogCommand;


        public DelegateCommand ShowDialogCommand
        {
            get
            {
                //Privateな変数に代入することをを忘れないように!!!
                //Publicな変数に対して動作を行うと……何も表示されなくなる
                if(_ShowDialogCommand == null)
                {
                    _ShowDialogCommand = new DelegateCommand(
                        _ => MessageBox.Show(
                            MakeDisplayedLicenseText()));
                }

                return _ShowDialogCommand;
            }
        }

        private DelegateCommand _ShowMaterialSiteAdditionalDialog;

        public DelegateCommand ShowMaterialSiteAdditionalDialog
        {
            get
            {
                if (_ShowMaterialSiteAdditionalDialog == null)
                {
                    var msg = new MainVewModelMessage(this);
              
                    _ShowMaterialSiteAdditionalDialog = new DelegateCommand(
                        _ => MainViewModelMessanger.Default.ExecuteAction<MainVewModelMessage>(this,msg));
                }

                return _ShowMaterialSiteAdditionalDialog;
            }
        }

    }
}
