using CompanyApp.ViewModel;
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

namespace CompanyApp.View
{
    /// <summary>
    /// Логика взаимодействия для ManagerEditWindow.xaml
    /// </summary>
    public partial class ManagerEditWindow : Window
    {
        public ManagerEditVM ManagerEdit { get; set; }

        public ManagerEditWindow()
        {
            InitializeComponent();
            ManagerEdit = new ManagerEditVM(); 
            DataContext = ManagerEdit;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
