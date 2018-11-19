using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.DAL;
using FOUNDERPCB.Models;
using FOUNDERPCB.BLL;

namespace FOUNDERPCB.Module.Base
{
    public partial class BaseSalesOrder : ChildModule
    {
        #region 字段  查看传入变量和返回变量
        public int top = 0;// 默认返回前X行 可传入
        public string sqlwhere = "";// 自定义查询条件 可传入
        public string orderby = "";// 排序规则  可传入
        public string SalesOrder = "";// 销售订单号，赋值到查询文本框

        public DataRow dr = null;//返回选择行
        public DATA0060 d60info = null;//返回DATA0060

        private DataTable dt_so = null;//查询用到的内存表
        DBHelper dbhelper = null;
        private DATA0060BLL d60bll = null;
        #endregion
        public BaseSalesOrder()
        {
            InitializeComponent();
        }

        private void BaseSalesOrder_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dbhelper = new DBHelper(this);
            d60bll = new DATA0060BLL(dbhelper);
            top = 500;//返回前500行，可外部调用控制
            txt_SearchStr.Text = SalesOrder;
            BindData();
        }

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            string iswhere = "";
            iswhere = " and DATA0060.SALES_ORDER LIKE '%" + txt_SearchStr.Text.Trim() + "%'";
            if (iswhere.Length > 0)
            {
                iswhere += " and " + sqlwhere;
            }
            try
            {
                dt_so = d60bll.GetSalesOrderList(top, iswhere, orderby);
                dataGridView1.DataSource = dt_so;
            }
            catch (Exception ex)
            {
                FOUNDERPCB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_SearchStr.Text = "";
        }

        private void txt_SearchStr_TextChanged(object sender, EventArgs e)
        {
            if (txt_SearchStr.Text.Length >= 4 || txt_SearchStr.Text.Length < 1)
            {
                SalesOrder = "";
                BindData();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                string strSaleOrder = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                dr = d60bll.GetSalesOrderList(top, "and DATA0060.SALES_ORDER='" + strSaleOrder + "' ", orderby).Rows[0];
                string strRkey = dr["DATA0060RKEY"].ToString();
                //dr = dt_so.Rows[dataGridView1.CurrentCell.RowIndex];
                d60info = d60bll.getDATA0060ByRKEY(decimal.Parse(strRkey));

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }
    }
}
