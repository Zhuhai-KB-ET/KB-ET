using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.Base
{
    public partial class BaseCustomer : ChildModule
    {
        public KB.Models.DATA0010 d10info = null;
        public IList<KB.Models.DATA0010> list = null;
        public string CustomerCode = "";
        public BaseCustomer()
        {
            InitializeComponent();
        }

        private void BaseCustomer_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            BindData();
        }
        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            string iswhere = "";
            if (CustomerCode != "")
            {
                lab_Name.Text = "客户代码：";
                txt_SearchStr.Text = CustomerCode;
            }
            if (lab_Name.Text.Contains("代码"))
            {
                iswhere += "CUST_CODE like '" + txt_SearchStr.Text.Trim() + "%'";
            }
            else
            {
                iswhere += "CUSTOMER_NAME like '%" + txt_SearchStr.Text.Trim() + "%'"; ;
            }
            try
            {
                KB.BLL.DATA0010BLL d10bll = new KB.BLL.DATA0010BLL(this);
                list = d10bll.FindBySql(iswhere);
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                KB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_SearchStr.Text = "";
            CustomerCode = "";
        }
        private void txt_SearchStr_TextChanged(object sender, EventArgs e)
        {
            CustomerCode = "";
            BindData();
        }
        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d10info = list[dataGridView1.CurrentCell.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("请选择行数据。");
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            switch (e.ColumnIndex)
            {
                case 0:
                    lab_Name.Text = "客户代码：";
                    break;
                case 1:
                    lab_Name.Text = "客户名称：";
                    break;
                default:
                    lab_Name.Text = "客户代码：";
                    break;
            }
        }

       
    }
}
