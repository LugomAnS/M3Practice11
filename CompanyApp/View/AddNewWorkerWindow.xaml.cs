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
    /// Логика взаимодействия для AddNewWorkerWindow.xaml
    /// </summary>
    public partial class AddNewWorkerWindow : Window
    {
        public ManagerCreateVM managerCreate;

        public AddNewWorkerWindow()
        {
            InitializeComponent();
            managerCreate = new ManagerCreateVM();
            DataContext = managerCreate;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
