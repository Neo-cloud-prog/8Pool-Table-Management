using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8pool.Core;
using _8Pool.Screens.GamesInfo;
using _8Pool.Screens.Players;
using _8Pool.Screens.Tables;
using _8Pool.UserControls.Helpers;

namespace _8Pool.Screens
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void _LoadAllTables()
        {
            flpTables.Controls.Clear();
            DataTable Tables = clsTable.GetAllTables();
            foreach (DataRow Table in Tables.Rows)
            {
                PoolTable poolTable = new PoolTable();
                poolTable.TableTitle = (string)Table["TableName"];
                poolTable.HourlyRate = Convert.ToSingle(Table["RatePerHour"]);
                poolTable.OnTableComplete += poolTable_OnTableComplete;
                poolTable.OnTableDeleted += poolTable_OnTableDeleted;
                flpTables.Controls.Add(poolTable);
            }
        }

        private void _LoadSidebar()
        {
            ucSidebar.Items = new List<ucSidebarButton>
            {
                new ucSidebarButton ((s, args) =>
                {
                    frmAddUpdateTable AddTableForm = new frmAddUpdateTable();
                    AddTableForm.TableSaved += (sender, e) =>
                    {
                        PoolTable poolTable = new PoolTable
                        {
                            TableTitle = e.TableName,
                            HourlyRate = e.HourlyRate,
                        };
                        poolTable.OnTableComplete += poolTable_OnTableComplete;
                        poolTable.OnTableDeleted += poolTable_OnTableDeleted;
                        flpTables.Controls.Add(poolTable);
                    };
                    AddTableForm.ShowDialog();
                }) { ButtonText = "Add Table"},

                new ucSidebarButton ((s, args) =>
                {
                    new frmPlayers().ShowDialog();
                }) { ButtonText = "Players"},

                new ucSidebarButton ((s, args) =>
                {
                    new frmGamesInfoList().ShowDialog();
                }) { ButtonText = "Games"},

                new ucSidebarButton ((s, args) =>
                {
                    MessageBox.Show("Not implemented yet");
                }) { ButtonText = "Settings"}
            };
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            _LoadAllTables();
            _LoadSidebar();
        }

        private void poolTable_OnTableComplete(object sender, PoolTable.TableCompletedEventArgs e)
        {   
            clsGameInfo GameInfo = new clsGameInfo();
            GameInfo.TableID = clsTable.FindByTableName(e.TableName).ID;
            clsPlayer Player = clsPlayer.FindByPlayerName(e.PlayerName);
            GameInfo.PlayerID = Player is null ? -1 : Player.ID;
            GameInfo.TimeConsumed = TimeSpan.FromSeconds(e.TimeInSeconds);
            GameInfo.TotalSeconds = e.TimeInSeconds;
            GameInfo.TotalFees = Convert.ToDecimal(e.TotalFees);

            if (!GameInfo.Save(e.PlayerName))
            {
                MessageBox.Show("Save faild");
            }
        }

        private void poolTable_OnTableDeleted(object sender, EventArgs e)
        {
            PoolTable poolTable = (PoolTable)sender;
            flpTables.Controls.Remove(poolTable);
        }
    }
}
