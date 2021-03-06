﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormEquipment : ChildModule
    {
        List<FOUNDERPCB.Models.DATA0161> list = null;
        public FOUNDERPCB.Models.DATA0161 data0161 = null;

        public FormEquipment()
        {
            InitializeComponent();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxCode.Text = "";
            BindData();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0161BLL bll = new FOUNDERPCB.BLL.DATA0161BLL(db);
                list = (List<FOUNDERPCB.Models.DATA0161>)bll.FindBySql(" EQUIPMENT_NAME like '%" + textBoxCode.Text.Trim() + "%'");
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

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                data0161 = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormEquipment_Load(object sender, EventArgs e)
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
