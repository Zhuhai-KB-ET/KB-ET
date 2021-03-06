﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.Base
{
    public partial class FormWarehouse : ChildModule
    {
        List<KB.Models.DATA0015> data0015List = null;
        public KB.Models.DATA0015 warehouse = null;

        public FormWarehouse()
        {
            InitializeComponent();
        }

        protected void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                KB.BLL.DATA0015BLL data0015BLL = new KB.BLL.DATA0015BLL(db);
                data0015List = (List<KB.Models.DATA0015>)data0015BLL.FindBySql(string.Format("warehouse_code like '%{0}%' or warehouse_name like '%{0}%' ", textBox1.Text.Trim()));
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = data0015List;
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[e.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                warehouse = data0015List[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormWarehouse_Load(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
