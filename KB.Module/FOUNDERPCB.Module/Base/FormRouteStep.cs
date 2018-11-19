using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.BLL;
using FOUNDERPCB.Models;
using FOUNDERPCB.DAL;


namespace FOUNDERPCB.Module.Base
{
    public partial class FormRouteStep : Form
    {
        public decimal d06Rkey = 0;//接收条件
        public Form frm = null;

        public decimal d34Rkey = 0;//返回结果
        public string d34Name = string.Empty;//返回结果2
        public decimal d34Step;//返回结果3

        public FormRouteStep()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载流程列表
        /// </summary>
        /// <param name="TTYPE"></param>
        /// <param name="SOURCE_PTR"></param>
        private void BindData(decimal SOURCE_PTR)
        {
            DBHelper dbhelper = new DBHelper(frm);
            DATA0038BLL d38bll = new DATA0038BLL(dbhelper);

            DataTable dt_38list = d38bll.GetRouteList(2, SOURCE_PTR);
            

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = dt_38list;
        }

        private void FormRouteStep_Load(object sender, EventArgs e)
        {
            BindData(d06Rkey);
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d34Rkey = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[0].Value);
                d34Name = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                d34Step = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }
    }
}