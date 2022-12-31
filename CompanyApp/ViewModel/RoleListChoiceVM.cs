using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyApp.ViewModel
{
    
    public class RoleListChoiceVM : INotifyPropertyChanged
    {
        string[] _roles;
        string _selectedRole;
        public bool Choice { get; set; }

        public string[] Roles { get { return _roles; } }
        public string SelectedRole 
        { 
            get { return _selectedRole; } 
            set 
            {
                _selectedRole = value; 
                Choice = true;
                OnPropertyChanged("Choice");
            }  
        }

        public RoleListChoiceVM()
        {
            _roles = new string[] { "Консультант", "Менеджер" };
            Choice = false;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }


    }
}
