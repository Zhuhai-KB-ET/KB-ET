using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.Base
{
    public partial class FormSupplier : KB.Module.ChildModule
    {
        IList<KB.Models.DATA0023> list = null;
        public KB.Models.DATA0023 Supplier = null;
        public string SqlWhere = string.Empty;
        public FormSupplier()
        {
            InitializeComponent();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxSupplierCode.Text = "";
        }

        private void textBoxSupplierCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                KB.BLL.DATA0023BLL bll = new KB.BLL.DATA0023BLL(db);
                if (SqlWhere.Length > 0)
                {
                    list = bll.GetEntityByCode(textBoxSupplierCode.Text.Trim(), SqlWhere);
                }
                else
                {
                    list = bll.GetEntityByCode(textBoxSupplierCode.Text.Trim());
                }
                dataGridView1.DataSource = list;
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

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void FormSupplier_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                Supplier = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
