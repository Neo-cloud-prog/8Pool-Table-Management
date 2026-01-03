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

namespace _8Pool.Screens.Players
{
    public partial class frmPlayers : Form
    {
        public frmPlayers()
        {
            InitializeComponent();
        }

        private void frmPlayers_Load(object sender, EventArgs e)
        {
            DataTable Players = clsPlayer.GetAllPlayers();

            if (Players.Rows.Count != 0)
                dgbPlayers.DataSource = Players;
            else
                lbMsg.Visible = true;
        }
    }
}
