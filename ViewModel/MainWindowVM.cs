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


namespace CompanyApp
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        readonly Consultant consultant;
        Department selectedDepartment;
        Worker selectedWorker;
        private ObservableCollection<LogMessage> workerLog;

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

        public ObservableCollection<Department> Departments { get { return consultant.Departments; } }
        public ObservableCollection<LogMessage> WorkerLog { get { return workerLog; } }

        public MainWindowVM()
        {
            consultant = new Consultant();
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
                for (int logId = 0; logId < consultant.Logs.Count; logId++)
                {
                    if (consultant.Logs[logId].WorkerID == selectedWorker.ID)
                    {
                        workerLog.Add(consultant.Logs[logId]);
                    }
                }
            }
            else workerLog.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        private ICommand testCommand;

        public ICommand TestCommand
        {
            get 
            {
                return testCommand = new CompanyCommand(TestDo, CanTestDO);
            }
        }

        private bool CanTestDO(object p) => p is Worker;

        private void TestDo(object p)
        {
            EditWorkerWindow ew = new EditWorkerWindow();
        }
    }
}
