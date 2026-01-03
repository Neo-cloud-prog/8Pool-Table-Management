using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pool.Core
{
    public class clsTable
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public int NumberOfPlayers { set; get; }
        public float RatePerHour { set; get; }

        public clsTable()
        {
            this.ID = -1;
            this.Name = default;
            this.NumberOfPlayers = default;
            this.RatePerHour = default;
            Mode = enMode.AddNew;
        }

        private clsTable(int ID, string Name, int NumberOfPlayers, float RatePerHour)
        {
            this.ID = ID;
            this.Name = Name;
            this.NumberOfPlayers = NumberOfPlayers;
            this.RatePerHour = RatePerHour;
            Mode = enMode.Update;
        }

        private bool _AddNewTable()
        {
            this.ID = clsTableData.AddNewTable(this.Name, this.RatePerHour);
            return (this.ID != -1);
        }

        private bool _UpdateTable()
        {
            return clsTableData.UpdateTable(this.ID, this.Name, this.NumberOfPlayers, this.RatePerHour);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewTable())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdateTable();
            }

            return false;
        }

        public static DataTable GetAllTables()
        {
            return clsTableData.GetAllTables();
        }

        public static clsTable FindByTableName(string TableName)
        {
            int NumberOfPlayers = 0, TableID = 0;
            float RatePerHour = 0f;

            if (clsTableData.GetTableInfoByName(TableName, ref TableID, ref NumberOfPlayers, ref RatePerHour))
                return new clsTable(TableID, TableName, NumberOfPlayers, RatePerHour);
            else
                return null;
        }

        public static bool DeleteTable(int TableID)
        {
            return clsTableData.DeleteTable(TableID);
        }

        public static bool DeleteTable(string TableName)
        {
            return clsTableData.DeleteTable(TableName);
        }

        public static bool IsTableExist(string TableName)
        {
            return clsTableData.IsTableExist(TableName);
        }
    }
}
