using System;
using System.Windows;
using System.Windows.Controls;
//…more using statements

namespace Practice
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            ViewModel vm = new ViewModel();
            this.DataContext = vm;
        }
    }
}
