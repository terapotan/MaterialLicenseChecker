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
    /// EditingMaterialSite.xaml の相互作用ロジック
    /// </summary>
    public partial class EditingMaterialSite : Window
    {
        public EditingMaterialSite()
        {
            InitializeComponent();
        }

        private void ClickedEditingAMaterialSite(object sender, RoutedEventArgs e)
        {
            Window win = new EditingAMaterialSite();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }

        private void ClickedMaterialSiteAdditional(object sender, RoutedEventArgs e)
        {
            Window win = new MaterialSiteAdditionalScreen();
            win.Owner = GetWindow(this);
            win.ShowDialog();
        }
    }
}
