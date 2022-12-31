using Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CompanyApp.ViewModel
{
    public class ManagerEditVM : INotifyDataErrorInfo, INotifyPropertyChanged
    {
        private bool canSave;
        private Worker worker;
        public Worker EditingWorker 
        { 
            get { return worker; } 
            set 
            { 
                worker = value;
                ValidateSurname();
                ValidateName();
                ValidateLastname();
                ValidatePhone();
                ValidatePassport();
            } 
        }
        public bool CanSave => !errorsValidation.Any();

        public string Surname
        {
            get { return EditingWorker.Surname; }
            set 
            { 
                EditingWorker.Surname = value;
                OnPropertyChanged();
                ValidateSurname();
            }
        }

        public string Name
        {
            get { return EditingWorker.Name; }
            set
            {
                EditingWorker.Name = value;
                OnPropertyChanged();
                ValidateName();
            }
        }

        public string Lastname
        {
            get { return EditingWorker.Lastname; }
            set
            {
                EditingWorker.Lastname = value;
                OnPropertyChanged();
                ValidateLastname();
            }
        }

        public string Phone
        {
            get { return EditingWorker.Phone; }
            set 
            {
                EditingWorker.Phone = value;
                OnPropertyChanged();
                ValidatePhone();
            }
        }

        public string Passport
        {
            get { return EditingWorker.Passport; }
            set 
            {
                EditingWorker.Passport = value;
                OnPropertyChanged();
                ValidatePassport();
            }
        }
               
        public ManagerEditVM() 
        {
            errorsValidation = new Dictionary<string, List<string>>();
        }

        #region PropertyChanged    
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName]string prop="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        #endregion


        #region Валидация

        // логика сбора ошибок
        private readonly Dictionary<string, List<string>> errorsValidation;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        public bool HasErrors => errorsValidation.Any();
        public IEnumerable GetErrors(string? propertyName)
        {
            return errorsValidation.ContainsKey(propertyName) ?
                errorsValidation[propertyName] : null;
        }

        private void OnErrorsChanger([CallerMemberName]string prop="")
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(prop));
            OnPropertyChanged("CanSave");
        }

        private void AddError(string propertyName, string error)
        {
            if (!errorsValidation.ContainsKey(propertyName))
            {
                errorsValidation[propertyName] = new List<string>();
            }

            if (!errorsValidation[propertyName].Contains(error))
            {
                errorsValidation[propertyName].Add(error);
                OnErrorsChanger(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (errorsValidation.ContainsKey(propertyName))
            {
                errorsValidation.Remove(propertyName);
                OnErrorsChanger(propertyName);
            }
        }

        // валидация значений
        private void ValidateSurname()
        {
            ClearErrors("Surname");
            if (string.IsNullOrEmpty(Surname))
            {
                AddError("Surname", "Фамилия не может быть пустым");
            }
        }

        private void ValidateName()
        {
            ClearErrors("Name");
            if (string.IsNullOrEmpty(Name))
            {
                AddError("Name", "Имя не может быть пустым");
            }
        }

        private void ValidateLastname()
        {
            ClearErrors("Lastname");
            if (string.IsNullOrEmpty(Lastname))
            {
                AddError("Lastname", "Отчество не может быть пустым");
            }
        }

        private void ValidatePhone()
        {
            ClearErrors("Phone");

            string phoneMask = @"[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]";

            if (Phone == null ||
                (!Regex.IsMatch(Phone, phoneMask) || Phone.Length != 9))
            {
                AddError("Phone", "Телефон должен соответсвовать маске: ХХХ-ХХ-ХХ");
            }
        }

        private void ValidatePassport()
        {
            ClearErrors("Passport");
            string passportMask = @"[0-9][0-9][0-9][0-9]\s[0-9][0-9][0-9][0-9][0-9][0-9]";

            if (Passport == null ||
                (!Regex.IsMatch(Passport, passportMask) || Passport.Length != 11))
            {
                AddError("Passport", "Паспорт по маске \"ХХХХ ХХХХХХ\"");
            }
        }

        #endregion
    }
}
