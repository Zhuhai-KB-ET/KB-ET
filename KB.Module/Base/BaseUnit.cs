using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.Models;
using KB.BLL;
using KB.DAL;

namespace KB.Module.Base
{
    public partial class BaseUnit : ChildModule
    {
        public IList<DATA0002> d02list = null;//页面显示用，也可作返回值用
        public DATA0002 d02info = null;//返回值
        public string iswhere = "";//传入查询条件
        
        public BaseUnit()
        {
            InitializeComponent();
        }

        private void BaseUnit_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            BindData();
        }
        protected void BindData()
        {
            DBHelper dbhelper = new DBHelper(0);
            DATA0002BLL bll = new DATA0002BLL(dbhelper);
            string sqlwhere = " (UNIT_CODE like '%" + txt_code.Text + "%' or UNIT_NAME like '%" + txt_code.Text + "%')";
            if (iswhere != "")
            {
                sqlwhere = iswhere + " and " + sqlwhere;
            }
            d02list = bll.FindBySql(sqlwhere);
            dataGridView1.DataSource = d02list;
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            txt_code.Text = "";
            BindData();
        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                d02info = d02list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
