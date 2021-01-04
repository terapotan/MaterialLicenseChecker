using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MaterialLicenseChecker.Views;
using MainViewModel = MaterialLicenseChecker.ViewModels.MainViewModel;
using System.IO;

namespace MaterialLicenseChecker
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        //FIXME:将来的には、バージョン更新もGit側と同期させたい
        //NOTE:ここを変更する場合、ウィンドウ側のバージョン表示も書き換えること。
        public static readonly string SoftwareVersion = "alpha-final";
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var w = new MainView();
            w.Show();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //アプリケーション側で発生した未処理例外
            AppDomain.CurrentDomain.UnhandledException += (o, eh) =>
            {
                var Ex = eh.ExceptionObject as Exception;
                DoProcessWhenUnhandledException(Ex);
                //自ら強制終了。
                Environment.Exit(-1);
            };

            System.Windows.Forms.Application.ThreadException += (o, eh) =>
            {
                Exception Ex = eh.Exception;
                DoProcessWhenUnhandledException(Ex);
                Environment.Exit(-1);
            };



        }

        //WPFウィンドウ側で発生した例外
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            Exception Ex = e.Exception;
            DoProcessWhenUnhandledException(Ex);
            //ハンドルされない例外を処理済みとして扱うために、追加。
            e.Handled = true;
            Environment.Exit(-1);
        }

        private void DoProcessWhenUnhandledException(Exception Ex)
        {
            MessageBox.Show("予期せぬエラーが発生しました。ソフトウェアを強制終了します。\n\n\n不具合の報告は、以下のメールアドレス宛にお願いします。\nterapotan@gmail.com\n※「ERRORLOG.txt」の内容も一緒に送信してください。本ソフトウェアの実行可能ファイルと同じフォルダにあります。", "予期せぬエラー", MessageBoxButton.OK, MessageBoxImage.Error);

            string NowDateTimeStr = DateTime.Now.ToString();
            string ExceptionContent = Ex.ToString();

            string WritingTextToLogFile = $"\n発生時刻:{NowDateTimeStr}\n" +
                $"例外内容:\n{ExceptionContent}";


            File.AppendAllText(@"ERRORLOG.txt", WritingTextToLogFile);
        }
    }
}