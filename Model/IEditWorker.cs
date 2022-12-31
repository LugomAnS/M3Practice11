using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Изменение данных сотрудника
    /// </summary>
    public interface IEditWorker
    {
        public abstract void EditWorker(Worker worker);
    }
}
