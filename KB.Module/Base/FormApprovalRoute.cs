using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormApprovalRoute : ChildModule
    {
        List<FOUNDERPCB.Models.DATA0497> list = null;
        public FOUNDERPCB.Models.DATA0497 data0497 = null;

        decimal type = -1;

        public FormApprovalRoute()
        {
            InitializeComponent();
        }

        public FormApprovalRoute(decimal type)
        {
            InitializeComponent();
            this.type = type;
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0497BLL bll = new FOUNDERPCB.BLL.DATA0497BLL(db);
                if (type == -1)
                {
                    list = (List<FOUNDERPCB.Models.DATA0497>)bll.FindBySql(" ACTIVE_FLAG=0 AND APPROVAL_ROUTE_CODE like '%" + textBox1.Text.Trim() + "%'");
                }
                else
                {
                    list = (List<FOUNDERPCB.Models.DATA0497>)bll.FindBySql(" ACTIVE_FLAG=0 AND APPROVAL_ROUTE_CODE like '%" + textBox1.Text.Trim() + "%' and APPROVAL_TYPE =" + type.ToString());
                }
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
            textBox1.Text = "";
            BindData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void FormApprovalRoute_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0497 = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
