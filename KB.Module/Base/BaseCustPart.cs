using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.Base
{
    public partial class BaseCustPart : ChildModule
    {
        #region 字段
        public KB.Models.DATA0050 d50info = null;
        public IList<KB.Models.DATA0050> list=null;
        public string PartNumber = "";
        public decimal Data0010Rkey = 0;
        public string SqlWhere = "";
        public int OpType = 0;//0查询生产部件，1查询销售部件
        public bool boolQtyOnHand = false;
        #endregion
        public BaseCustPart()
        {
            InitializeComponent();
        }
        private void BaseCustPart_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            if (OpType == 1)
            {
                this.Text = "销售部件搜索";
            }
            BindData();
        }
        private void btn_Clean_Click(object sender, EventArgs e)
        {
            txt_SearchStr.Text = "";
            PartNumber = "";
            Data0010Rkey = 0;
        }

        private void txt_SearchStr_TextChanged(object sender, EventArgs e)
        {
            PartNumber = "";
            Data0010Rkey = 0;
            if (txt_SearchStr.Text.Length >= 4)
            {
                BindData();
            }
            if (txt_SearchStr.Text.Length == 0)
            {
                BindData();
            }
        }

        #region 加载数据
        /// <summary>
        /// 加载数据
        /// </summary>
        private void BindData()
        {
            string iswhere = "ACTIVE_FLAG = 'Y'";
            if (OpType == 0)
            {
                iswhere += " and  (RKEY = PRODUCTION_PART_PTR) ";
            }
            else
            {
                iswhere += " and  (RKEY != PRODUCTION_PART_PTR) ";
            }
            //加入库存过滤
            if (boolQtyOnHand)
            {
                iswhere += " and  (QTY_ON_HAND>0) ";
            }

            if (SqlWhere != "")
            {
                iswhere += SqlWhere;
            }
            else
            {
                if (PartNumber != "")
                {
                    lab_Name.Text = "部件号码：";
                    txt_SearchStr.Text = PartNumber;
                }
                if (Data0010Rkey > 0)
                {
                    iswhere += " and CUSTOMER_PTR=" + Data0010Rkey.ToString();
                }
                if (lab_Name.Text.Contains("号码"))
                {
                    iswhere += " and CUSTOMER_PART_NUMBER like '" + txt_SearchStr.Text.Trim() + "%'";
                }
                else
                {
                    iswhere += " and CUSTOMER_PART_DESC like '" + txt_SearchStr.Text.Trim() + "%'";
                }
            }
            try
            {
                KB.DAL.DBHelper db = new KB.DAL.DBHelper();
                KB.BLL.DATA0050BLL d50bll = new KB.BLL.DATA0050BLL(db);
                list = d50bll.FindBySql(iswhere);
                if (list.Count < 1)
                {
                    if (PartNumber != "")
                    {
                        MessageBox.Show("没有找到任何数据。");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                dataGridView1.DataSource = list;
            }
            catch (Exception ee)
            {
                KB.FUNC.log.RecordInfo(ee);
                MessageBox.Show(ee.Message);
            }
           
        }
        #endregion

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d50info = list[dataGridView1.CurrentCell.RowIndex];
                this.DialogResult = DialogResult.OK;
              //  this.Close();
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
                    lab_Name.Text = "部件代码：";
                    break;
                case 1:
                    lab_Name.Text = "部件描述：";
                    break;
                default:
                    lab_Name.Text = "部件代码：";
                    break;
            }
            
        }      
    }
}
