using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormParameter : Form
    {
        /// <summary>
        /// DATA0038中的Parameter_N,工厂不同N也不同
        /// </summary>
        public string ColumnName;
        
        /// <summary>
        /// 返回值,已经做Trim()
        /// </summary>
        public string Parameter = string.Empty;

        private DataTable tb;//存储DATA0038中的Parameter

        private void FormParameter_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            FOUNDERPCB.DAL.DBHelper db = null;
            try
            {
                db = new FOUNDERPCB.DAL.DBHelper();
                tb = db.GetDataSet(string.Format("select distinct {0} as parameter from data0038 where {0} is not null order by {0}", ColumnName));
                for (int i = tb.Rows.Count - 1; i >= 0; i--)//删除空行
                {
                    if (tb.Rows[i][0].ToString().Trim().Length == 0)
                    {
                        tb.Rows.RemoveAt(i);
                    }
                }
                BindData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (db != null)
                {
                    db.CloseConnection();
                }
            }
        }

        public FormParameter(string columnName)
        {
            InitializeComponent();
            ColumnName = columnName;
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Parameter = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            DataRow[] rows = tb.Select(" parameter like '%" + txtValue.Text.Trim() + "%'");
            DataTable temp = tb.Clone();
            for (int i = 0; i < rows.Length; i++)
            {
                temp.Rows.Add(rows[i].ItemArray);
            }
            dataGridView1.DataSource = temp;
        }
    }
}
