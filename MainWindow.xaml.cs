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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;

namespace FurnitureDataBase_WS
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //===========================   Строка подключения БД   =================================
        public static string ConnectionSrting { get; } = @"";
        //=======================================================================================

        public MainWindow()
        {
            InitializeComponent();
            AuthorizationPage start = new AuthorizationPage();
            MainMenu.NavigationService.Navigate(start);
        }
    }
}