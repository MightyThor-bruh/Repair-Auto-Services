using AutoService.ViewModel;
using System;
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

namespace AutoService.View
{
    /// <summary>
    /// Interaction logic for MainAdmin.xaml
    /// </summary>
    public partial class MainAdmin : Window
    {
        private readonly MainAdminViewModel _vm;
        public MainAdmin()
        {
            _vm = new MainAdminViewModel();
            _vm.Close = () => this.Close();
            this.DataContext = _vm;
            InitializeComponent();
        }
    }
}
