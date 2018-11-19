using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.Models;
using KB.BLL;

namespace KB.Module.Base
{
    public partial class FormReplenishmentOrder : ChildModule
    {
        public Decimal Data0023Ptr = 0;
        public Decimal Data0466Ptr = 0;

        public FormReplenishmentOrder()
        {
            InitializeComponent();
        }

        private void FormReplenishmentOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                DATA0466BLL bll = new DATA0466BLL(db);
                DataTable tb = bll.QueryROForBasePage(textBoxCode.Text.Trim(), Data0023Ptr);
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
                KB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex >= 0)
            {
                Data0466Ptr = decimal.Parse(dataGridView1[0, e.RowIndex].Value.ToString());
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
