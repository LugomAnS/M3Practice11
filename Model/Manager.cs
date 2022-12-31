using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Model
{
    /// <summary>
    /// Модель менеджера
    /// </summary>
    public class Manager : Consultant, IAddNewWorker, IDeleteWorker, IEditDepartment
    {
        public void AddNewDepartment(Department department)
        {
            department.DepartmentID = Department.NextID();
            _repository.AddNewDepartment(department);
        }

        public void DeleteDepartment(Department department)
        {
            _repository.DeleteDepartment(department);
        }

        public void AddNewWorker(Worker newWorker)
        {
            newWorker.ID = Worker.NextID();
            LogMessage logMessage = new LogMessage(LogMessage.NextLogID(),
                                                   newWorker.ID,
                                                   DateTime.Now,
                                                   "Создание новой записи",
                                                   "Менеджер");
            
            _repository.SaveNewWorker(newWorker, logMessage);
        }

        public void DeleteWorker(Worker workerTodelete)
        {
            LogMessage logMessage = new LogMessage(LogMessage.NextLogID(),
                                                   workerTodelete.ID,
                                                   DateTime.Now,
                                                   "Удаление записи",
                                                   "Менеджер");
            _repository.DeleteWorker(workerTodelete, logMessage);
        }

        public override void EditWorker(Worker worker)
        {
            Worker baseWorker = Workers.Single(w => w.ID == worker.ID);

            string[] changes = new string[] { };
            if (!string.Equals(baseWorker.Surname, worker.Surname))
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Фамилия";
            }
            if (!string.Equals(baseWorker.Name, worker.Name))
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Имя";
            }
            if (!string.Equals(baseWorker.Lastname, worker.Lastname))
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Отчество";
            }
            if (!string.Equals(baseWorker.Phone, worker.Phone))
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Телефон";
            }
            if (!string.Equals(baseWorker.Passport, worker.Passport))
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Паспорт";
            }
            if (baseWorker.DepartmentID != worker.DepartmentID)
            {
                Array.Resize(ref changes, changes.Length + 1);
                changes[changes.Length - 1] = "Отдел";
            }

            StringBuilder sb = new StringBuilder();
            sb.Append("Изменено: ");
            sb.AppendJoin(" ", changes);

            LogMessage logMessage = new LogMessage(LogMessage.NextLogID(),
                                                   worker.ID,
                                                   DateTime.Now,
                                                   sb.ToString(),
                                                   "Менеджер");
            _repository.SaveEditWorkerChanges(worker, logMessage);
        }

    }
}
