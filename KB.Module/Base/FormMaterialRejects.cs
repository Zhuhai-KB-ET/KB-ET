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
    public partial class FormMaterialRejects : ChildModule
    {
        List<DATA0076> data0076List;
        public DATA0076 Data0076;

        public FormMaterialRejects()
        {
            InitializeComponent();
        }

        private void FormMaterialRejects_Load(object sender, EventArgs e)
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
                KB.BLL.DATA0076BLL bll = new KB.BLL.DATA0076BLL(db);
                data0076List = (List<KB.Models.DATA0076>)bll.FindBySql(" CODE like '%" + textBoxCode.Text.Trim() + "%'");
                dataGridView1.DataSource = data0076List;
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

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxCode.Text = "";
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                Data0076 = data0076List[e.RowIndex];
                this.DialogResult = DialogResult.OK;
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
    }
}
