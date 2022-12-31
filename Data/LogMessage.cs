using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    /// <summary>
    /// История изменения сведений о сотруднике
    /// </summary>
    public struct LogMessage
    {
        public static int LogIndexId = 0;

        private int _logId;
        private int _workerId;
        private DateTime _recordTime;
        private string _fieldChanged;
        private string _changer;

        public int WorkerID { get { return _workerId; } }
        public int LogID { get { return _logId; } }
        public DateTime RecordTime { get { return _recordTime; } }
        public string FieldChanged { get { return _fieldChanged; } }
        public string Changer { get { return _changer; } }

        public LogMessage(int id,
                          int workerId,
                          DateTime timeRecord,
                          string changedField,
                          string changer) 
        {
            _logId = id;
            _workerId = workerId;
            _recordTime = timeRecord;
            _fieldChanged = changedField;
            _changer = changer;
        }

        public string LogText 
        {
            get 
            {
                return $"{_logId} " +
                       $"{_recordTime} " +
                       $"{_fieldChanged} " +
                       $"{_changer}";
            }
        }

        public static int NextLogID()
        {
            return ++LogIndexId;
        }
    }
}
