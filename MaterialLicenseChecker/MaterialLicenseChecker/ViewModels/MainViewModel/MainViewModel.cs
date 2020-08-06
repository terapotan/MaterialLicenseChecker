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
        }

        private void ClickedMaterialSiteMenuEvent(ClickedMaterialSiteMenuEventMessage msg)
        {
            MessageBox.Show("asfdjlk");
        }

        private string MakeDisplayedLicenseText()
        {
            ClassStoreLicenseText ClassStore = new ClassStoreLicenseText();
            List<string> FetchLicenseTextSite = new List<string>();

            //XXX:地獄みたいなif文の羅列である。何とかしろ!!!

            if (CheckBoxAState)
            {
                FetchLicenseTextSite.Add("A");
            }

            if (CheckBoxBState)
            {
                FetchLicenseTextSite.Add("B");
            }

            if (CheckBoxCState)
            {
                FetchLicenseTextSite.Add("C");
            }

            if (CheckBoxDState)
            {
                FetchLicenseTextSite.Add("D");
            }

            if (CheckBoxEState)
            {
                FetchLicenseTextSite.Add("E");
            }

            var ReturnedList = ClassStore.GetLicenseTextLists(FetchLicenseTextSite);

            string ReturnedText = "";

            foreach (var Text in ReturnedList)
            {
                ReturnedText = ReturnedText + Text + '\n';
            }

            return ReturnedText;

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


        //FIXME:とりあえずチェックボックス5つの状態を別の変数として宣言して、
        //データバインディングしている。この機能はあくまでテスト用のもので、
        //将来的に削除される予定である。
        //もし、そうでないならマルチバインディングなりを使って修正する必要がある。

        private bool _checkBoxAState;
        public bool CheckBoxAState
        {
            get { return _checkBoxAState; }
            set
            {
                _checkBoxAState = value;
            }
        }

        private bool _checkBoxBState;
        public bool CheckBoxBState
        {
            get { return _checkBoxBState; }
            set
            {
                _checkBoxBState = value;
            }
        }

        private bool _checkBoxCState;
        public bool CheckBoxCState
        {
            get { return _checkBoxCState; }
            set
            {
                _checkBoxCState = value;
            }
        }

        private bool _checkBoxDState;
        public bool CheckBoxDState
        {
            get { return _checkBoxDState; }
            set
            {
                _checkBoxDState = value;
            }
        }

        private bool _checkBoxEState;
        public bool CheckBoxEState
        {
            get { return _checkBoxEState; }
            set
            {
                _checkBoxEState = value;
            }
        }
    }
}
