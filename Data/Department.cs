using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// Отдел в компании
    /// </summary>
    public class Department
    {
        public static int DepartmentIndexId = 0;

        private int _departmentID;
        private string _departmentTitle;
        private ObservableCollection<Worker> _workers;

        public int DepartmentID { get { return _departmentID; } set { _departmentID = value; } }
        public string DepartmentTitle { get { return _departmentTitle; } set { _departmentTitle = value; } }

        public ObservableCollection<Worker> Workers { get { return _workers; } set { _workers = value; } }

        public Department(int id, string title)
        {
            _departmentID = id;
            _departmentTitle = title;
            _workers = new ObservableCollection<Worker>();
        }

        public Department()
        {
            _workers = new ObservableCollection<Worker>();
        }

        public static int NextID()
        {
            return ++DepartmentIndexId;
        }
    }
}
