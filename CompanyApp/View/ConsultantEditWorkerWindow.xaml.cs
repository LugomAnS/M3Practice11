using CompanyApp.ViewModel;
using Data;
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

namespace CompanyApp
{
    /// <summary>
    /// Логика взаимодействия для ConsultantEditWorkerWindow.xaml
    /// </summary>
    public partial class ConsultantEditWorkerWindow : Window
    {
        public ConsultantEditWorkerWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
