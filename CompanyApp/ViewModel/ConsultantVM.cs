using Data;
using Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;
using CompanyApp.View;
using System.Collections;
using CompanyApp.ViewModel;

namespace CompanyApp
{
    /// <summary>
    /// ViewModel для консультанта
    /// </summary>
    public class ConsultantVM : INotifyPropertyChanged
    {
        protected Consultant employee;
        Department selectedDepartment;
        Worker selectedWorker;
        private ObservableCollection<LogMessage> workerLog;

        #region Поля
        public Department SelectedDepartment
        {
            get { return selectedDepartment; }
            set
            {
                selectedDepartment = value;
                OnPropertyChanged();
            }
        }
        public Worker SelectedWorker
        {
            get { return selectedWorker; }
            set
            {
                selectedWorker = value;
                OnPropertyChanged();
                RefreshLogs();
            }
        }

        public ObservableCollection<Department> Departments { get { return employee.Departments; } }
        public ObservableCollection<LogMessage> WorkerLog { get { return workerLog; } }

        #endregion

        public ConsultantVM()
        {
            employee = new Consultant();
            workerLog = new ObservableCollection<LogMessage>();
        }

        /// <summary>
        /// обновление лога
        /// </summary>
        private void RefreshLogs()
        {
            workerLog.Clear();
            if (selectedWorker != null)
            {  
                for (int logId = 0; logId < employee.Logs.Count; logId++)
                {
                    if (employee.Logs[logId].WorkerID == selectedWorker.ID)
                    {
                        workerLog.Add(employee.Logs[logId]);
                    }
                }
            }
            else workerLog.Clear();
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion

        // Команды
        #region Редактирование сотрудника

        private ICommand editWorkerCommand;

        public ICommand EditWorkerCommand =>editWorkerCommand = new CompanyCommand(EditWorkerExecute, CanEditWorker);
       
        private bool CanEditWorker(object p) => p is Worker;

        protected virtual void EditWorkerExecute(object p)
        {
            ConsultantEditWorkerWindow editWorkerWindow = new ConsultantEditWorkerWindow();
            Worker editWorker = Worker.Copy((Worker)p);

            editWorkerWindow.DataContext = editWorker;
            editWorkerWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editWorkerWindow.ShowDialog();
            if (editWorkerWindow.DialogResult == true)
            {
                employee.EditWorker(editWorker);
            }
        }



        #endregion

    }
}
