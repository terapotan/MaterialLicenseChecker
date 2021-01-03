﻿using System;
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

namespace MaterialLicenseChecker.Views
{
    /// <summary>
    /// GenerateProject.xaml の相互作用ロジック
    /// </summary>
    public partial class GenerateProject : Window
    {
        public GenerateProject()
        {
            InitializeComponent();
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
    }
}
