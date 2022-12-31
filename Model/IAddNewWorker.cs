using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Добваление сотрудника
    /// </summary>
    internal interface IAddNewWorker
    {
        public abstract void AddNewWorker(Worker newWorker);
    }
}
