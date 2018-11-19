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
    public partial class FormMirForMaintenanceOrder : ChildModule
    {
        public DATA0172 Data0172;
        public DATA0395 Data0395;

        public FormMirForMaintenanceOrder()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                KB.BLL.DATA0395BLL bll = new KB.BLL.DATA0395BLL(db);
                var tb = bll.QueryMirForMaintenanceOrder(textBoxCode.Text.Trim());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = tb;
            }
            catch (Exception ex)
            {
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

        private void FormMirForMaintenanceOrder_Load(object sender, EventArgs e)
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                KB.DAL.DBHelper db = new KB.DAL.DBHelper();
                try
                {
                    KB.BLL.DATA0172BLL data0172BLL = new KB.BLL.DATA0172BLL(db);
                    KB.BLL.DATA0395BLL data0395BLL = new KB.BLL.DATA0395BLL(db);
                    Data0172 = data0172BLL.getDATA0172ByRECORD_KEY_MO(decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                    Data0395 = data0395BLL.getDATA0395ByRKEY(decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString()));

                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }
    }
}
