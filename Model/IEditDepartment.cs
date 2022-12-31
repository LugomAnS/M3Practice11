using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Добавление/удаление отдела 
    /// </summary>
    public interface IEditDepartment
    {
        public abstract void AddNewDepartment(Department department);

        public abstract void DeleteDepartment(Department department);
    }
}
