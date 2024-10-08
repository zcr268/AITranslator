﻿using AITranslator.Mail;
using AITranslator.View.Models;
using AITranslator.View.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AITranslator.View.UserControls
{
    /// <summary>
    /// UserControl_LogsView.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl_SetView : UserControl
    {
        public UserControl_SetView()
        {
            InitializeComponent();
        }

        private void UserControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                ViewModel_SetView viewModel_SetView = ViewModel_SetView.Create();
                DataContext = viewModel_SetView;
            }
        }

        Regex re_Num = new Regex("[^0-9]+");
        public void NumberInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = re_Num.IsMatch(e.Text);
        }

        public void EnableSet()
        {
            (DataContext as ViewModel_SetView)!.Enable();
            Window_Message.ShowDialog("提示","应用成功");
        }
    }
}
