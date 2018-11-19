using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormProductionResource : ChildModule
    {
        List<FOUNDERPCB.Models.DATA0034> list = null;
        public FOUNDERPCB.Models.DATA0034 data0034 = null;
        /// <summary>
        /// 格式 and + 条件
        /// </summary>
        public string SqlWhere = string.Empty;
        /// <summary>
        /// 当前工厂的信息
        /// </summary>
        DataTable tb = null;
        /// <summary>
        /// 是否显示拓展的信息DATA0034E
        /// </summary>
        public Boolean showExpendedData = false;

        public FormProductionResource()
        {
            InitializeComponent();
        }

        private void FormProductionResource_Load(object sender, EventArgs e)
        {
            tb = FOUNDERPCB.FUNC.GlobalVal.GetFactory(FOUNDERPCB.FUNC.GlobalVal.UserInfo.FactoryID);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0034BLL bll = new FOUNDERPCB.BLL.DATA0034BLL(db);
                if (!showExpendedData)
                {
                    list = (List<FOUNDERPCB.Models.DATA0034>)bll.FindBySql(" DEPT_CODE like '%" + textBoxCode.Text.Trim() + "%'  and (ACTIVE_FLAG = 0 OR ACTIVE_FLAG IS NULL)" + SqlWhere);
                }
                else
                {
                    try
                    {
                        #region 初始化拓展表
                        DataTable temp = bll.getDataSet("select * from sysobjects where name = 'DATA0034E' and xtype = 'U'");
                        if (temp != null & temp.Rows.Count == 0)
                        {
                            string execSql = @"create table DATA0034E
                                            (
	                                            rkey numeric(10,0) identity(1,1) primary key,
	                                            data0034ptr numeric(10,0) not null,
                                            )";
                            db.ExecuteCommand(execSql);
                        }
                        #endregion
                        list = (List<FOUNDERPCB.Models.DATA0034>)bll.FindBySql(" DEPT_CODE like '%" + textBoxCode.Text.Trim() + "%'  and (ACTIVE_FLAG = 0 OR ACTIVE_FLAG IS NULL)"
                                                                                + " and RKEY IN (select data0034ptr from DATA0034E) "
                                                                                + SqlWhere + " order by DEPT_CODE");
                    }
                    catch (Exception error)
                    {
                        throw error;
                    }
                }
                dataGridView1.DataSource = list;
            }
            catch (Exception ex)
            {
                FOUNDERPCB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxCode.Text = "";
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0034 = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
