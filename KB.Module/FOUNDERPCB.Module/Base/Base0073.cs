using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.BLL;
using FOUNDERPCB.DAL;
using FOUNDERPCB.Models;

namespace FOUNDERPCB.Module.Base
{
    public partial class Base0073 : Form
    {
        public DBHelper dbhelper = null;

        //返回值
        public decimal ReturnRkey05;
        public decimal ReturnRkey73;
        public string FullName;

        public Base0073()
        {
            InitializeComponent();
        }

        private void bindData()
        {
            
            DATA0073BLL d73 = new DATA0073BLL(dbhelper);
            string sqlwhere = string.Empty;
            if (!string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                sqlwhere = string.Format(" user_login_name like '%{0}%' or user_full_name like '%{0}%' ",textBox1.Text.Trim());
            }

            dataGridView1.AutoGenerateColumns = false;
            IList<DATA0073> data73 = d73.FindBySql(sqlwhere);

            for (int i = 0; i < data73.Count; i++)
            {
                data73[i].GROUP_PTR = i + 1;
            }
            dataGridView1.DataSource = data73;

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bindData();
        }

        private void Base0073_Load(object sender, EventArgs e)
        {
            bindData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                ReturnRkey05 = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[2].Value);
                ReturnRkey73 = Convert.ToDecimal(dataGridView1.CurrentRow.Cells[1].Value);
                FullName = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }
    }
}
