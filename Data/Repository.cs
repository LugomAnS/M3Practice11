using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Data
{
    /// <summary>
    /// Хранилище данных о компании
    /// </summary>
    public class Repository
    {
        const string DP_PATH = "DepartmentDB.xml";
        const string WORKER_PATH = "WorkerDB.xml";
        const string LOG_PATH = "LogDB.txt";
        const string INDEX_PATH = "Properties.txt";

        ObservableCollection<Department> _departments;
        ObservableCollection<Worker> _workers;
        ObservableCollection<LogMessage> _logMessages;

        public ObservableCollection<Department> Departments { get { return _departments; } }
        public ObservableCollection<Worker> Workers { get { return _workers; } }
        public ObservableCollection<LogMessage> LogMessages { get { return _logMessages; } }

        public Repository()
        {
            InitDB.DataBase.CreateDB();

            _departments = new ObservableCollection<Department>(); 
            ReadDepartmentData();

            _workers = new ObservableCollection<Worker>(); 
            ReadWorkerData();

            _logMessages = new ObservableCollection<LogMessage>();
            ReadLogMessageData();

            DepartmentWorkersFill();
            SetDataBaseIndex();
        }

        #region Методы внесения изменений в БД

        /// <summary>
        /// Добавление нового отдела
        /// </summary>
        /// <param name="newDepartment">Отдел для добавления</param>
        public void AddNewDepartment(Department newDepartment)
        {
            _departments.Add(newDepartment);
            SaveDepartmentsToFile();
            ReWriteIndexSettings();
        }
        /// <summary>
        /// Удаление отдела
        /// </summary>
        /// <param name="deleteDepartment">Отдел для удаления</param>
        public void DeleteDepartment(Department deleteDepartment)
        {
            _departments.Remove(deleteDepartment);
            SaveDepartmentsToFile();
        }

        /// <summary>
        /// Удаление работника из БД
        /// </summary>
        /// <param name="workerToDelete">Работник для удаления</param>
        /// <param name="logMessage">Логфайл</param>
        public void DeleteWorker(Worker workerToDelete, LogMessage logMessage)
        {
            _workers.Remove(workerToDelete);
            SaveWorkersToFile();
            _logMessages.Add(logMessage);
            SaveLogMessageToFile(logMessage);
            DepartmentWorkersFill();
            ReWriteIndexSettings();
        }
        /// <summary>
        /// Сохранения информации по новому работнику
        /// </summary>
        /// <param name="newWorker">Работник для сохранения</param>
        /// <param name="logMessage">Логфайл</param>
        public void SaveNewWorker(Worker newWorker, LogMessage logMessage)
        {
            _workers.Add(newWorker);
            SaveWorkersToFile();
            _logMessages.Add(logMessage);
            SaveLogMessageToFile(logMessage);
            DepartmentWorkersFill();
            ReWriteIndexSettings();
        }

        /// <summary>
        /// Сохранение изменений по работнику
        /// </summary>
        /// <param name="editWorker">Работник по которому идут изменения</param>
        /// <param name="logMessage">Логфайл проведенных изменений</param>
        public void SaveEditWorkerChanges(Worker editWorker, LogMessage logMessage)
        {
            _logMessages.Add(logMessage);
            SaveLogMessageToFile(logMessage);

            for (int i = 0; i < _workers.Count; i++)
            {
                if (_workers[i].ID == editWorker.ID)
                {
                    _workers[i] = editWorker;
                    break;
                }
            }
            SaveWorkersToFile();
            DepartmentWorkersFill();
            ReWriteIndexSettings();
        }
        #endregion

        #region Работа с файловой системой на диске
        private void SaveLogMessageToFile(LogMessage logMessage)
        {
            using (StreamWriter sw = new StreamWriter(LOG_PATH, true))
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendJoin("#",
                              logMessage.LogID,
                              logMessage.WorkerID,
                              logMessage.RecordTime,
                              logMessage.FieldChanged,
                              logMessage.Changer);
                sw.WriteLine(sb.ToString());
            }
        }

        private void SaveWorkersToFile()
        {
            XAttribute companyName = new XAttribute("Name", "Syper Company Ltd.");
            XElement company = new XElement("Workers", companyName);

            foreach (Worker item in _workers)
            {
                company.Add(CreaterWorkerRecord(item));
            }

            company.Save(WORKER_PATH);
        }

        private void SaveDepartmentsToFile()
        {
            XAttribute companyName = new XAttribute("Name", "Syper Company Ltd.");
            XElement company = new XElement("DPstruct", companyName);

            foreach (Department item in _departments)
            {
                company.Add(CreateDepartmentRecord(item));
            }

            company.Save(DP_PATH);
        }

        private XElement CreaterWorkerRecord(Worker workerTosave)
        {
            XAttribute id = new XAttribute("ID", workerTosave.ID);
            XElement worker = new XElement("Worker", id);

            XElement surname = new XElement("Surname", workerTosave.Surname);
            XElement name = new XElement("Name", workerTosave.Name);
            XElement lastname = new XElement("Lastname", workerTosave.Lastname);
            XElement phone = new XElement("Phone", workerTosave.Phone);
            XElement passport = new XElement("Passport", workerTosave.Passport);
            XElement dpID = new XElement("Department", workerTosave.DepartmentID);
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            return worker;
        }

        private XElement CreateDepartmentRecord(Department department)
        {
            XAttribute dpID = new XAttribute("ID", department.DepartmentID);
            XElement dp = new XElement("Department", dpID);
            XElement dpTitle = new XElement("Title", department.DepartmentTitle);
            dp.Add(dpTitle);

            return dp;
        }

        private void ReWriteIndexSettings()
        {
            if (File.Exists(INDEX_PATH))
            {
                File.Delete(INDEX_PATH);
            }

            using (StreamWriter sw = new StreamWriter(INDEX_PATH, true))
            {
                sw.WriteLine(Department.DepartmentIndexId.ToString());
                sw.WriteLine(Worker.WorkerIndexId.ToString());
                sw.WriteLine(LogMessage.LogIndexId.ToString());
            }
        }

        #endregion

        #region Инициализация репозитория
        private void DepartmentWorkersFill()
        {
            
            for (int dpIndex = 0; dpIndex < _departments.Count; dpIndex++)
            {
                _departments[dpIndex].Workers.Clear();
                for (int workerIndex = 0; workerIndex < _workers.Count; workerIndex++)
                {
                    if (_workers[workerIndex].DepartmentID == _departments[dpIndex].DepartmentID)
                    {
                        _departments[dpIndex].Workers.Add(_workers[workerIndex]);
                    }
                }
            }
        }

        /// <summary>
        /// Считывание лог файла
        /// </summary>
        private void ReadLogMessageData()
        {
            using (StreamReader sr = new StreamReader(LOG_PATH))
            {
                string logEntry;
                while ( (logEntry = sr.ReadLine() )!= null)
                {
                    string[] log = logEntry.Split('#');

                    LogMessage logMessage = new LogMessage(Convert.ToInt32(log[0]),
                                                           Convert.ToInt32(log[1]),
                                                           Convert.ToDateTime(log[2]),
                                                           log[3],
                                                           log[4]);
                    _logMessages.Add(logMessage);
                }
            }
        }

        /// <summary>
        /// Считывание работников
        /// </summary>
        private void ReadWorkerData()
        {
            string xml = File.ReadAllText(WORKER_PATH);

            var workersValue = XDocument.Parse(xml)
                                        .Descendants("Workers")
                                        .Descendants("Worker")
                                        .ToList();

            foreach (var item in workersValue)
            {
                _workers.Add(new Worker(int.Parse(item.Attribute("ID").Value),
                                        item.Element("Surname").Value,
                                        item.Element("Name").Value,
                                        item.Element("Lastname").Value,
                                        item.Element("Phone").Value,
                                        item.Element("Passport").Value,
                                        int.Parse(item.Element("Department").Value)));

            }
        }

        /// <summary>
        /// Считывание отделов
        /// </summary>
        private void ReadDepartmentData()
        {
            string xml = File.ReadAllText(DP_PATH);

            var dpValues = XDocument.Parse(xml)
                                    .Descendants("DPstruct")
                                    .Descendants("Department")
                                    .ToList();
            foreach (var item in dpValues)
            {
                _departments.Add(new Department(int.Parse(item.Attribute("ID").Value),
                                                item.Element("Title").Value));
            }
        }

        private void SetDataBaseIndex()
        {
            using (StreamReader sr = new StreamReader(INDEX_PATH))
            {
                string index = sr.ReadLine();
                Department.DepartmentIndexId = Convert.ToInt32(index);

                index = sr.ReadLine();
                Worker.WorkerIndexId = Convert.ToInt32(index);

                index = sr.ReadLine();
                LogMessage.LogIndexId = Convert.ToInt32(index);
            }
        }

        #endregion

    }
}
