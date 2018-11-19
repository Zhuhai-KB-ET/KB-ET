using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormShippingMethod : ChildModule
    {
        List<FOUNDERPCB.Models.DATA0370> list = null;
        public FOUNDERPCB.Models.DATA0370 data0370 = null;

        public FormShippingMethod()
        {
            InitializeComponent();
        }

        private void FormShippingMethod_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        protected void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0370BLL bll = new FOUNDERPCB.BLL.DATA0370BLL(db);
                list = (List<FOUNDERPCB.Models.DATA0370>)bll.FindBySql(" CODE like '%" + textBox1.Text.Trim() + "%' and (Data0370.ACTIVE_FLAG = 0 OR Data0370.ACTIVE_FLAG IS NULL)");
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                FOUNDERPCB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0370 = list[e.RowIndex];
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
