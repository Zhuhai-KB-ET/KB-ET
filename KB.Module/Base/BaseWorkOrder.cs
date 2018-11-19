using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.Models;
using KB.BLL;

namespace KB.Module.Base
{
    public partial class BaseWorkOrder : ChildModule
    {
        #region 字段
        public int HasOpType = 0;//状态：0不隐藏，1隐藏自定义查询功能
        public int top = 0;// 默认返回前X行 可传入
        public string SqlWhere = "";//带入的查询条件
        public string orderby = "";// 排序规则  可传入
        public string work_order_number = "";

        public DATA0006 d06info = null;//返回结果，可用        
        public DataTable dt_result = null;//返回结果，可用

        private DATA0006BLL d06bll = null;
        #endregion
        public BaseWorkOrder()
        {
            InitializeComponent();
        }

        private void BaseWorkOrder_Load(object sender, EventArgs e)
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                d06bll = new DATA0006BLL(db);
                dataGridView1.AutoGenerateColumns = false;
                if (HasOpType == 1)
                {
                    txt_SearchStr.Visible = false;
                    btn_Clean.Visible = false;
                }
                else
                {
                    txt_SearchStr.Text = work_order_number;
                }
                top = 200;
                BindData();
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_SearchStr.Text = "";
        }

        private void txt_SearchStr_TextChanged(object sender, EventArgs e)
        {
            //SqlWhere = "";
            BindData();
        }

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            string iswhere = "";
            if (HasOpType == 0)
            {
                iswhere += " and WORK_ORDER_NUMBER like '%" + txt_SearchStr.Text.Trim() + "%'";
            }            
            if (SqlWhere.Length>0)
            {
                iswhere += SqlWhere;
            }            
            dt_result = d06bll.GetWOList(top, iswhere,orderby);
            dataGridView1.DataSource = dt_result.DefaultView;

        }
        #endregion

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d06info = d06bll.getDATA0006ByRKEY(decimal.Parse(dt_result.Rows[dataGridView1.CurrentCell.RowIndex]["Data0006RKEY"].ToString()));
                this.DialogResult = DialogResult.OK;
                //  this.Close();
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }
    }
}
