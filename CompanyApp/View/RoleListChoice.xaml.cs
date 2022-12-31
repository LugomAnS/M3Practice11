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
    /// Логика взаимодействия для RoleListChoice.xaml
    /// </summary>
    public partial class RoleListChoice : Window
    {
        public RoleListChoice()
        {
            InitializeComponent();
            DataContext = new RoleListChoiceVM();
        }

        private void Choice_Click(object sender, RoutedEventArgs e)
        {
            string role = Roles.SelectedItem.ToString();
            {
                switch (role)
                {
                    case "Консультант":
                        ConsultantWindow cw = new ConsultantWindow();
                        cw.Show();
                        break;
                    case "Менеджер":
                        ManagerWindow mw = new ManagerWindow();
                        mw.Show();
                        break;
                    default:
                        MessageBox.Show("Что то пошло не так, обратитесь к разработчику");
                        break;
                }
            }    
           Close();
        }
    }
}
