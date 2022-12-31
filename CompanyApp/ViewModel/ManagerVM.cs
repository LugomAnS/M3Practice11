using CompanyApp.View;
using Data;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CompanyApp.ViewModel
{
    /// <summary>
    /// ViewModel для менеджера
    /// </summary>
    public class ManagerVM : ConsultantVM
    {
        public ManagerVM():base()
        {
            employee = new Manager();
        }

        #region Команды

        //добавление нового работника
        private ICommand addNewWorker;

        public ICommand AddNewWorker => addNewWorker = 
            new CompanyCommand(AddNewWorkerExecute,CanAddNewWorkerExecute);

        private void AddNewWorkerExecute(object w)
        {
            AddNewWorkerWindow addWorkerWindow = new AddNewWorkerWindow();
            Worker newWorker = new Worker();
            newWorker.DepartmentID = SelectedDepartment.DepartmentID;

            addWorkerWindow.managerCreate.EditingWorker = newWorker;

            addWorkerWindow.ShowDialog();
            if (addWorkerWindow.DialogResult == true)
            {
                ((Manager)employee).AddNewWorker(newWorker);
            }
        }

        private bool CanAddNewWorkerExecute(object w) => SelectedDepartment != null ? true : false;

        // удаление работника
        private ICommand deleteWorker;

        public ICommand DeleteWorker => deleteWorker = 
            new CompanyCommand(DeleteWorkerExecute, CanDeleteWorkerExecute);

        private bool CanDeleteWorkerExecute(object w) => w is Worker;

        private void DeleteWorkerExecute(object w)
        {
            if (MessageBox.Show("Вы уверены? Действие удаления нельзя отменить.",
                            "Удаление сотрудника",
                            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ((Manager)employee).DeleteWorker((Worker)w);
            }
        }

        // переопределяем исполнение команды редактирования
        protected override void EditWorkerExecute(object p)
        {
            ManagerEditWindow editWorkerWindow = new ManagerEditWindow();
            Worker editWorker = Worker.Copy((Worker)p);
            
            editWorkerWindow.ManagerEdit.EditingWorker = editWorker;
            editWorkerWindow.ShowDialog();
            if (editWorkerWindow.DialogResult == true)
            {
                employee.EditWorker(editWorker);
            }
        }

        // добаление отдела
        private ICommand addNewDepartment;
        public ICommand AddNewDepartment => addNewDepartment = 
            new CompanyCommand(AddDepartmentExecute);

       // private bool CanAddDepartmentExecute(object d) => true;

        private void AddDepartmentExecute(object d)
        {
            AddDepartmentWindow addDepartmentWindow = new AddDepartmentWindow();
            Department newDepartment = new Department();
            addDepartmentWindow.DataContext = newDepartment;
            addDepartmentWindow.ShowDialog();

            if (addDepartmentWindow.DialogResult ==true)
            {
                ((Manager)employee).AddNewDepartment(newDepartment);
            }
        }

        // удаление отдела
        private ICommand deleteDepartment;

        public ICommand DeleteDepartment => deleteDepartment = 
            new CompanyCommand(DeleteDepartmentExecute, CanDeleteDepartmentExecute);

        private bool CanDeleteDepartmentExecute(object d) => SelectedDepartment != null ? true : false;
        private void DeleteDepartmentExecute(object d)
        {
            if (SelectedDepartment.Workers.Count == 0)
            {
                ((Manager)employee).DeleteDepartment(SelectedDepartment);
            }
            else
            {
                MessageBox.Show("Нельзя удалить отдел пока там есть сотрудники",
                                "ВНИМАНИЕ!",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
