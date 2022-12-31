using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Data;

namespace Model
{
    /// <summary>
    /// Модель консультанта
    /// </summary>
    public class Consultant : IEditWorker
    {
        protected Repository _repository;

        public ObservableCollection<Department> Departments { get { return _repository.Departments; } }
        public ObservableCollection<Worker> Workers { get { return _repository.Workers; } }
        public ObservableCollection<LogMessage> Logs { get { return _repository.LogMessages; } }
       

        public Consultant() 
        {
            _repository = new Repository();
           
        }

        public virtual void EditWorker (Worker worker)
        {
            LogMessage logEntry = new LogMessage(LogMessage.NextLogID(),
                                                 worker.ID,
                                                 DateTime.Now,
                                                 "Изменено: Телефон",
                                                 "Консультант"
                                                );
            _repository.SaveEditWorkerChanges(worker, logEntry);
        }
    }
}
