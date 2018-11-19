using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.Models;
using FOUNDERPCB.BLL;

namespace FOUNDERPCB.Module.Base
{
    public partial class BaseFOB : ChildModule
    {
        public IList<DATA0394> list394 = null;//页面显示用，也可作返回值用
        public DATA0394 d394info = null;//返回值
        public BaseFOB()
        {
            InitializeComponent();
        }

        private void BaseFOB_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            d394info=new DATA0394();
            BindData();
        }

        protected void BindData()
        {
            DATA0394BLL bll = new DATA0394BLL(this);
             try
            {
            list394 = bll.FindBySql("FOB like '%" + txt_fob.Text + "%'");
            dataGridView1.DataSource = list394;
            }
             catch (Exception ex)
             {
                 FOUNDERPCB.FUNC.log.RecordInfo(ex);
                 MessageBox.Show(ex.ToString());
             }           
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_fob.Text = "";
            BindData();
        }

        private void txt_fob_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                d394info = list394[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
