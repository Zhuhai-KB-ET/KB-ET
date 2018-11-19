using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormRejectReason : FOUNDERPCB.Module.ChildModule
    {
        List<FOUNDERPCB.Models.DATA0076> list = null;
        public FOUNDERPCB.Models.DATA0076 data0076 = null;

        public FormRejectReason()
        {
            InitializeComponent();
        }

        private void textBoxRejCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0076BLL bll = new FOUNDERPCB.BLL.DATA0076BLL(db);
                list = (List<FOUNDERPCB.Models.DATA0076>)bll.FindBySql(" code like '%" + textBoxRejCode.Text.Trim() + "%' order by code");
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

        private void FormRejectReason_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxRejCode.Text = "";
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0076 = list[e.RowIndex];
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
