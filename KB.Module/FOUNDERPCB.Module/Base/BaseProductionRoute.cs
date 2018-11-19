using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class BaseProductionRoute : ChildModule
    {
        #region 字段
        public FOUNDERPCB.Models.DATA0037 d37info = null;//返回结果集
        public IList<FOUNDERPCB.Models.DATA0037> list = null;
        public string PROD_ROUTE_CODE = "";//流程代码 ，传入值
        #endregion
        public BaseProductionRoute()
        {
            InitializeComponent();
        }

        private void BaseProductionRoute_Load(object sender, EventArgs e)
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
            if (PROD_ROUTE_CODE != "")
            {
                lab_name.Text = "流程代码：";
                txt_SearchStr.Text = PROD_ROUTE_CODE.Trim();
            }
            if (lab_name.Text.Contains("代码"))
            {
                iswhere += "PROD_ROUTE_CODE like '" + txt_SearchStr.Text.Trim() + "%'";
            }
            else
            {
                iswhere += "PROD_ROUTE_CODE_NAME like '%" + txt_SearchStr.Text.Trim() + "%'"; ;
            }
            iswhere += " and ACTIVE_FLAG !=0 ";
            try
            {
                FOUNDERPCB.BLL.DATA0037BLL d37bll = new FOUNDERPCB.BLL.DATA0037BLL(this);
                list = d37bll.FindBySql(iswhere);
                dataGridView1.DataSource = list;
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
            PROD_ROUTE_CODE = "";
        }

        private void txt_SearchStr_TextChanged(object sender, EventArgs e)
        {
            PROD_ROUTE_CODE = "";
            BindData();
        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                d37info = list[dataGridView1.CurrentCell.RowIndex];
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
                    lab_name.Text = "流程代码：";
                    break;
                case 1:
                    lab_name.Text = "流程名称：";
                    break;
                default:
                    lab_name.Text = "流程代码：";
                    break;
            }
        }
    }
}
