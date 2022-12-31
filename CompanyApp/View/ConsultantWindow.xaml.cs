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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CompanyApp;
using CompanyApp.View;

namespace CompanyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConsultantWindow : Window
    {
        public ConsultantWindow()
        {
            InitializeComponent();
            DataContext = new ConsultantVM();
            
        }

        private void ChooseRole_Click(object sender, RoutedEventArgs e)
        {
            RoleListChoice roleListChoice = new RoleListChoice();
            Close();
            roleListChoice.Show();

        }
    }
}
