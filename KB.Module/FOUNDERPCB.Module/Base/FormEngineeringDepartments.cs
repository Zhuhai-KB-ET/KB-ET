using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormEngineeringDepartments : ChildModule
    {
        List<FOUNDERPCB.Models.DATA0029> list = null;
        public FOUNDERPCB.Models.DATA0029 data0029 = null;
        /// <summary>
        /// 当前工厂的信息
        /// </summary>
        DataTable tb = null;
        /// <summary>
        /// 是否显示拓展的信息DATA0029E
        /// </summary>
        public Boolean showExpendedData = false;

        public FormEngineeringDepartments()
        {
            InitializeComponent();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxCode.Text = "";
            BindData();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                FOUNDERPCB.BLL.DATA0029BLL bll = new FOUNDERPCB.BLL.DATA0029BLL(db);
                if (!showExpendedData)
                {
                    list = (List<FOUNDERPCB.Models.DATA0029>)bll.FindBySql(" ENGG_DEPT_CODE like '%" + textBoxCode.Text.Trim() + "%'");
                }
                else
                {
                    try
                    {
                        #region 初始化拓展表
                        DataTable temp = bll.getDataSet("select * from sysobjects where name = 'DATA0029E' and xtype = 'U'");
                        if (temp != null & temp.Rows.Count == 0)
                        {
                            string execSql = @"create table DATA0029E
                                            (
	                                            rkey numeric(10,0) identity(1,1) primary key,
	                                            data0029ptr numeric(10,0) not null,
                                            )";
                            db.ExecuteCommand(execSql);
                        }
                        #endregion
                    }
                    catch (Exception error)
                    {
                        throw error;
                    }
                    list = (List<FOUNDERPCB.Models.DATA0029>)bll.FindBySql(" ENGG_DEPT_CODE like '%" + textBoxCode.Text.Trim() + "%'"
                                                                            + " AND RKEY IN (select data0029ptr from data0029E) ORDER BY ENGG_DEPT_CODE");
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

        private void FormEngineeringDepartments_Load(object sender, EventArgs e)
        {
            tb = FOUNDERPCB.FUNC.GlobalVal.GetFactory(FOUNDERPCB.FUNC.GlobalVal.UserInfo.FactoryID);

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void textBoxCode_TextChanged(object sender, EventArgs e)
        {
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0029 = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
