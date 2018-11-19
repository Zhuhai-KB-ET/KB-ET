using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.Models;

namespace KB.Module.Base
{
    public partial class FormProductionParameter : ChildModule
    {
        public DATA0035 D35;
        public FormProductionParameter()
        {
            InitializeComponent();
        }

        private void FormProductionParameter_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            KB.BLL.DATA0035BLL bll = new KB.BLL.DATA0035BLL(db);
            var data = bll.GetModelList(" PRODUCTION_PARAMETER like '%" + txtName.Text.Trim() + "%'");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                D35 = new DATA0035
                {
                    RKEY = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells[0].Value),
                    PRODUCTION_PARAMETER = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()
                };
                this.DialogResult = DialogResult.OK;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
