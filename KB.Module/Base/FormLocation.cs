using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormLocation : FOUNDERPCB.Module.ChildModule
    {
        List<FOUNDERPCB.Models.DATA0016> data0016List = null;
        public FOUNDERPCB.Models.DATA0016 location = null;
        decimal data0017Ptr = 0;

        public FormLocation()
        {
            InitializeComponent();
        }

        public FormLocation(decimal data0017Ptr)
        {
            InitializeComponent();
            this.data0017Ptr = data0017Ptr;
        }

        protected void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0016BLL bll = new FOUNDERPCB.BLL.DATA0016BLL(db);
                if (data0017Ptr > 0)
                {
                    data0016List = bll.GetDefaultLocationByInventory(data0017Ptr);
                }
                else
                {
                    data0016List = (List<FOUNDERPCB.Models.DATA0016>)bll.FindBySql(string.Format(" code like '{0}' or location like '%{0}%'", textBox1.Text.Trim()));
                }
                dataGridView1.DataSource = data0016List;
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                location = data0016List[dataGridView1.CurrentCell.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormLocation_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
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
