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

namespace MaterialLicenseChecker.ViewModels.MainViewModelPac
{
    class MainViewModel
    {
        public MainViewModel()
        {
            MainViewModelEventMessenger.Default.
                RegisterAction<ClickedMaterialSiteMenuEventMessage>
                (this, ClickedMaterialSiteMenuEvent);

            MainViewModelEventMessenger.Default.
                RegisterAction<ClickedMaterialAdditionalMenuEventMessage>
                (this, ClickedMaterialMenuEvent);
        }

        private void ClickedMaterialSiteMenuEvent(ClickedMaterialSiteMenuEventMessage msg)
        {
            var SendMsg = new GenerateNewDialogMessage(this);
            SendMsg.GeneratingDialogNumber = GenerateNewDialogMessage.MATERIAL_SITE_WINDOW;
            MainViewModelMessanger.Default.ExecuteAction(this, SendMsg);
        }

        private void ClickedMaterialMenuEvent(ClickedMaterialAdditionalMenuEventMessage msg)
        {
            var SendMsg = new GenerateNewDialogMessage(this);
            SendMsg.GeneratingDialogNumber = GenerateNewDialogMessage.MATERIAL_WINDOW;
            MainViewModelMessanger.Default.ExecuteAction(this, SendMsg);
        }

        private string MakeDisplayedLicenseText()
        {
            ClassStoreLicenseText ClassStore = new ClassStoreLicenseText();
            List<string> FetchLicenseTextSite = new List<string>();

            //XXX:地獄みたいなif文の羅列である。何とかしろ!!!


            return "";

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
