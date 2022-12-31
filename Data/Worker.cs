using System;
using System.Web;

namespace Data
{
    /// <summary>
    /// Сотрудник компании
    /// </summary>
    public class Worker
    {
        public static int WorkerIndexId = 0;


        private int _id;
        private string _surname;
        private string _name;
        private string _lastname;
        private string _phone;
        private string _passport;
        private int _departmentID;

        public int ID 
        { 
            get { return _id; }
            set { _id = value; }
        }
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string Phone
        {
            get { return _phone; }
            set 
            {
                _phone = value; 
            }
        }
        public string Passport
        {
            get { return _passport; }
            set { _passport = value; }
        }
        public int DepartmentID
        {
            get { return _departmentID; }
            set { _departmentID = value; }
        }
        
        public Worker (int id,
                       string surname,
                       string name,
                       string lastname,
                       string phone,
                       string passport,
                       int departmentID)
        {
            _id = id;
            _surname = surname;
            _name = name;
            _lastname = lastname;
            _phone = phone;
            _passport = passport;
            _departmentID = departmentID;
        }

        public Worker() { }

        public static int NextID()
        {
            return ++WorkerIndexId;
        }

        /// <summary>
        /// Создание копии сотрудника
        /// </summary>
        /// <param name="workerToCopy">Сотрудник для копирования</param>
        /// <returns>Копия</returns>
        public static Worker Copy(Worker workerToCopy)
        {
            Worker copyWorker = new Worker(workerToCopy.ID,
                                           workerToCopy.Surname,
                                           workerToCopy.Name,
                                           workerToCopy.Lastname,
                                           workerToCopy.Phone,
                                           workerToCopy.Passport,
                                           workerToCopy.DepartmentID
                                           );
            return copyWorker;
        }
    }
}
