using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace _8pool.Core
{
    public class clsGameInfo
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public int PlayerID { get; set; }
        public int TableID { get; set; }
        public TimeSpan TimeConsumed { set; get; }
        public int TotalSeconds { set; get; }
        public decimal TotalFees { set; get; }
        public clsPlayer Player { set; get; }
        public clsTable Table { set; get; }

        public clsGameInfo()
        {
            this.ID = -1;
            this.Player = default;
            this.Table = default;
            this.TimeConsumed = default;
            this.TotalSeconds = default;
            this.TotalFees = default;
            Mode = enMode.AddNew;
        }

        private bool _AddNewGameInfo(string PlayerName)
        {
            this.ID = clsGameInfoData.AddNewGameInfo(this.PlayerID, PlayerName, this.TableID, this.TimeConsumed, this.TotalSeconds, this.TotalFees);
            return (this.ID != -1);
        }

        public bool Save(string PlayerName)
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewGameInfo(PlayerName))
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        public static DataTable GetAllGameInfo()
        {
            return clsGameInfoData.GetAllGameInfo();
        }
    }
}
