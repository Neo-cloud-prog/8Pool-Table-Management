using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8Pool.Screens.Tables.Events
{
    public class clsTableSavedEventArgs
    {
        public clsTableSavedEventArgs(string tableName, float hourlyRate)
        {
            TableName = tableName;
            HourlyRate = hourlyRate;
        }

        public string TableName { get; }
        public float HourlyRate { get; }
    }
}
