﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AppGST
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //MainWindow app = new MainWindow();
            //Current.Properties["MainWindow"] = app;
            //app.DataContext = Current.Properties["MainWindowViewModel"] as MainWindowViewModel;
            new LogonGST().Show();
        }
    }
}
