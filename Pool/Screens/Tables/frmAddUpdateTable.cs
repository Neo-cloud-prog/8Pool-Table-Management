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
using _8Pool.Screens.Tables.Events;

namespace _8Pool.Screens.Tables
{
    public partial class frmAddUpdateTable : Form
    {
        public event EventHandler<clsTableSavedEventArgs> TableSaved;

        enum enMode { Add = 0, Update = 1 }

        enMode _Mode;

        clsTable _Table = new clsTable();

        public frmAddUpdateTable()
        {
            InitializeComponent();
            _Mode = enMode.Add;
        }

        public frmAddUpdateTable(string TableName)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _Table = clsTable.FindByTableName(TableName);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrEmpty(txtTableTitle.Text))
            {
                errorProvider.SetError(txtTableTitle, "Required");
                return false;
            }

            if (clsTable.IsTableExist(txtTableTitle.Text))
            {
                errorProvider.SetError(txtTableTitle, "This name is aleady exist");
                return false;
            }
            errorProvider.SetError(txtTableTitle, null);
            errorProvider.Clear();
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (ValidateForm())
            {
                _Table.Name = txtTableTitle.Text;
                _Table.RatePerHour = Convert.ToSingle(nuHourlyRate.Value);

                if (_Table.Save())
                {
                    MessageBox.Show("Table saved");
                    TableSaved?.Invoke(sender, new clsTableSavedEventArgs(_Table.Name, _Table.RatePerHour));
                }
                else
                {
                    MessageBox.Show("Failed to save table");
                }
            }
        }

        private void frmAddUpdateTable_Load(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                txtTableTitle.Text = _Table.Name;
                nuHourlyRate.Value = Convert.ToDecimal(_Table.RatePerHour);
            }
        }
    }
}
