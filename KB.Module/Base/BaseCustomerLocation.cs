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
    public partial class BaseCustomerLocation : ChildModule
    {
        public DATA0012 d12info = new DATA0012();
        public decimal data0010rkey = 0;
        public DBHelper dbhelper = null;
        DATA0012BLL d12bll = null;
        IList<DATA0012> d12list = null;
        public BaseCustomerLocation()
        {
            InitializeComponent();
        }

        private void BaseCustomerLocation_Load(object sender, EventArgs e)
        {
            d12bll = new DATA0012BLL(dbhelper);
            dataGridView1.AutoGenerateColumns = false;
            BindData();
        }
        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            string iswhere = "(1=1) ";
            if (data0010rkey > 0)
            {
                iswhere += " and CUSTOMER_PTR=" + data0010rkey.ToString();
            }
            if (textBox1.Text != "")
            {
                iswhere += " and LOCATION  like '%"+textBox1.Text+"%'";
            }
            d12list = d12bll.FindBySql(iswhere);
            dataGridView1.DataSource = d12list;
        }
        #endregion
        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {            
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d12info = d12list[dataGridView1.CurrentCell.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }
    }
}
