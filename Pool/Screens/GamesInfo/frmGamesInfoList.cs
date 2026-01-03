using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using _8pool.Core;

namespace _8Pool.Screens.GamesInfo
{
    public partial class frmGamesInfoList : Form
    {
        public frmGamesInfoList()
        {
            InitializeComponent();
        }

        private void frmGamesInfoList_Load(object sender, EventArgs e)
        {
            DataTable GamesInfo = clsGameInfo.GetAllGameInfo();
            if (GamesInfo.Rows.Count != 0)
                dgvGamesInfo.DataSource = GamesInfo;
            else
                lbMsg.Visible = true;
        }
    }
}
