using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8pool.Core
{
    public class clsPlayer
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int ID { set; get; }
        public string Name { set; get; }
        public int NumberOfGames { set; get; }
        public DateTime JoinDate { set; get; }

        public clsPlayer()
        {
            this.ID = -1;
            this.Name = default;
            this.NumberOfGames = default;
            this.JoinDate = default;
            Mode = enMode.AddNew;
        }

        private clsPlayer(int ID, string Name, int NumberOfGames, DateTime JoinDate)
        {
            this.ID = ID;
            this.Name = Name;
            this.NumberOfGames = NumberOfGames;
            this.JoinDate = JoinDate;
            Mode = enMode.Update;
        }

        private bool _AddNewPlayer()
        {
            this.ID = clsPlayerData.AddNewPlayer(this.Name);
            return (this.ID != -1);
        }

        private bool _UpdatePlayer()
        {
            return clsPlayerData.UpdatePlayer(this.ID, this.Name, this.NumberOfGames);
        }

        public static clsPlayer FindByPlayerID(int PlayerID)
        {
            string PlayerName = "";
            int NumberOfGames = 0;
            DateTime JoinDate = default;

            if (clsPlayerData.GetPlayerInfoByID(PlayerID, ref PlayerName, ref NumberOfGames, ref JoinDate))
                return new clsPlayer(PlayerID, PlayerName, NumberOfGames, JoinDate);
            else
                return null;
        }

        public static clsPlayer FindByPlayerName(string PlayerName)
        {
            int PlayerID = 0;
            int NumberOfGames = 0;
            DateTime JoinDate = default;

            if (clsPlayerData.GetPlayerInfoByName(PlayerName, ref PlayerID, ref NumberOfGames, ref JoinDate))
                return new clsPlayer(PlayerID, PlayerName, NumberOfGames, JoinDate);
            else
                return null;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPlayer())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePlayer();
            }

            return false;
        }

        public static DataTable GetAllPlayers()
        {
            return clsPlayerData.GetAllPlayers();
        }

        public static bool DeletePlayer(int PlayerID)
        {
            return clsPlayerData.DeletePlayer(PlayerID);
        }

        public static bool IsPlayerExist(int PlayerID)
        {
            return clsPlayerData.IsPlayerExist(PlayerID);
        }

        public static bool IsPlayerExist(string PlayerName)
        {
            return clsPlayerData.IsPlayerExist(PlayerName);
        }
    }
}
