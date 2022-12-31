using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Удаление сотрудника
    /// </summary>
    public interface IDeleteWorker
    {
        public abstract void DeleteWorker(Worker workerTodelete);
    }
}
