using System;
using System.IO;
using System.Text;
using System.Windows.Controls;
using System.Xml.Linq;

namespace InitDB
{
    /// <summary>
    /// Служит первичным наполнением базы данных
    /// </summary>
    public class DataBase
    {
        const string DP_PATH = "DepartmentDB.xml";
        const string WORKER_PATH = "WorkerDB.xml";
        const string LOG_PATH = "LogDB.txt";
        const string INDEX_PATH = "Properties.txt";

        /// <summary>
        /// Создание БД
        /// </summary>
        public static void CreateDB()
        {
            if (!File.Exists(DP_PATH))
            {
                CreateDepartmentFile();
            }
            if (!File.Exists(WORKER_PATH))
            {
                CreateWorkersDB();
            }
            if (!File.Exists(LOG_PATH))
            {
                CreateLogDB();
            }
            if (!File.Exists(INDEX_PATH))
            {
                WriteIndexSettings();
            }
            
        }

        /// <summary>
        /// Создание лог файла
        /// </summary>
        private static void CreateLogDB()
        {
            using (StreamWriter sw = new StreamWriter(LOG_PATH,true))
            {
                for (int i = 1; i < 9; i++)
                {
                    sw.WriteLine(CreateLogEntry(i).ToString());
                }
            }

            
        }

        private static StringBuilder CreateLogEntry(int number)
        {
            StringBuilder logEntry = new StringBuilder();

            return logEntry.AppendJoin('#',
                                       number,
                                       number,
                                       DateTime.Now,
                                       "Создание новой записи",
                                       "Admin");
        }

        /// <summary>
        /// Создание списка сотрудников
        /// </summary>
        private static void CreateWorkersDB()
        {
            XAttribute companyName = new XAttribute("Name", "Syper Company Ltd.");
            XElement company = new XElement("Workers", companyName);

            #region Руководство
            XAttribute id = new XAttribute("ID", "1");
            XElement worker = new XElement("Worker", id);

            XElement surname = new XElement("Surname", "Иванов");
            XElement name = new XElement("Name","Иван");
            XElement lastname = new XElement("Lastname", "Иванович");
            XElement phone = new XElement("Phone", "123-45-56");
            XElement passport = new XElement("Passport", "0000 111111");
            XElement dpID = new XElement("Department", "1");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);
            #endregion

            #region Кадры
            id = new XAttribute("ID", "2");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Иванов");
            name = new XElement("Name", "Иван");
            lastname = new XElement("Lastname", "Сидорович");
            phone = new XElement("Phone", "123-45-56");
            passport = new XElement("Passport", "1111 999999");
            dpID = new XElement("Department", "2");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);

            id = new XAttribute("ID", "3");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Иванов");
            name = new XElement("Name", "Иван");
            lastname = new XElement("Lastname", "Петрович");
            phone = new XElement("Phone", "123-45-56");
            passport = new XElement("Passport", "1111 888888");
            dpID = new XElement("Department", "2");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);
            #endregion

            #region Бухгалтерия

            id = new XAttribute("ID", "4");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Сидорова");
            name = new XElement("Name", "Галина");
            lastname = new XElement("Lastname", "Сидоровна");
            phone = new XElement("Phone", "555-55-55");
            passport = new XElement("Passport", "2222 777777");
            dpID = new XElement("Department", "3");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);

            id = new XAttribute("ID", "5");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Сидорова");
            name = new XElement("Name", "Брунгильда");
            lastname = new XElement("Lastname", "Брунгильдовна");
            phone = new XElement("Phone", "444-11-55");
            passport = new XElement("Passport", "2222 666666");
            dpID = new XElement("Department", "3");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);

            #endregion

            #region ИТ
            id = new XAttribute("ID", "6");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Шариков");
            name = new XElement("Name", "Шарик");
            lastname = new XElement("Lastname", "Шарикович");
            phone = new XElement("Phone", "222-33-44");
            passport = new XElement("Passport", "3333 987654");
            dpID = new XElement("Department", "4");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);

            id = new XAttribute("ID", "7");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Круглов");
            name = new XElement("Name", "Кругляк");
            lastname = new XElement("Lastname", "Круглович");
            phone = new XElement("Phone", "333-99-01");
            passport = new XElement("Passport", "3333 643125");
            dpID = new XElement("Department", "4");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);

            id = new XAttribute("ID", "8");
            worker = new XElement("Worker", id);

            surname = new XElement("Surname", "Торов");
            name = new XElement("Name", "Тор");
            lastname = new XElement("Lastname", "Одинсон");
            phone = new XElement("Phone", "999-99-99");
            passport = new XElement("Passport", "3333 918273");
            dpID = new XElement("Department", "4");
            worker.Add(surname);
            worker.Add(name);
            worker.Add(lastname);
            worker.Add(phone);
            worker.Add(passport);
            worker.Add(dpID);

            company.Add(worker);
            #endregion

            company.Save(WORKER_PATH);
        }

        /// <summary>
        /// Создание бд отделов
        /// </summary>
        private static void CreateDepartmentFile()
        {
            XAttribute companyName = new XAttribute("Name", "Syper Company Ltd.");
            XElement company = new XElement("DPstruct", companyName);

            XAttribute dpID = new XAttribute("ID", "1");
            XElement dp = new XElement("Department", dpID);
            XElement dpTitle = new XElement("Title", "Руководство");
            dp.Add(dpTitle);
            company.Add(dp);

            dpID = new XAttribute("ID", "2");
            dp = new XElement("Department", dpID);
            dpTitle = new XElement("Title", "Отдел кадров");
            dp.Add(dpTitle);
            company.Add(dp);

            dpID = new XAttribute("ID", "3");
            dp = new XElement("Department", dpID);
            dpTitle = new XElement("Title", "Бухгалтерия");
            dp.Add(dpTitle);
            company.Add(dp);

            dpID = new XAttribute("ID", "4");
            dp = new XElement("Department", dpID);
            dpTitle = new XElement("Title", "Отдел ИТ");
            dp.Add(dpTitle);
            company.Add(dp);

            company.Save(DP_PATH);
        }

        /// <summary>
        /// Настройка индексов
        /// </summary>
        private static void WriteIndexSettings()
        {
            using (StreamWriter sw = new StreamWriter(INDEX_PATH, true))
            {
                sw.WriteLine(4);
                sw.WriteLine(8);
                sw.WriteLine(8);
            }
        }

    }
}
