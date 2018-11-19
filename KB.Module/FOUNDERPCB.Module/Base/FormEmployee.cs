using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.Models;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormEmployee : ChildModule
    {
        public DATA0005 Data0005;
        List<DATA0005> data0005List;

        public FormEmployee()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0005BLL bll = new FOUNDERPCB.BLL.DATA0005BLL(db);
                data0005List = (List<FOUNDERPCB.Models.DATA0005>)bll.FindBySql(" empl_code like '%" + textBoxCode.Text.Trim() + "%' or employee_name like '%" + textBoxCode.Text.Trim() + "%'");
                dataGridView1.DataSource = data0005List;
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
            textBoxCode.Text = "";
            BindData();
        }

        private void FormEmployee_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Data0005 = data0005List[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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
