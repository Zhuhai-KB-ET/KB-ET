using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.BLL;
using FOUNDERPCB.Models;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormProductionReject : FOUNDERPCB.Module.ChildModule
    {
        /// <summary>
        /// 报废/退回的类型 R:报废.D:退回
        /// </summary>
        public string RejectType;
        public DATA0039 Data0039;
        private List<DATA0039> list;

        public FormProductionReject()
        {
            InitializeComponent();
        }

        private void FormProductionReject_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = null;
            try
            {
                db = new FOUNDERPCB.DAL.DBHelper();
                FOUNDERPCB.BLL.DATA0039BLL bll = new FOUNDERPCB.BLL.DATA0039BLL(db);
                string sqlWhere = " REJECT_DEFECT_FLAG = '{0}' and (REJ_CODE like '%{1}%' or REJECT_DESCRIPTION like '%{1}%')";
                list = (List<DATA0039>)bll.FindBySql(string.Format(sqlWhere, RejectType, txtUserInput.Text.Trim()));
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

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                Data0039 = list[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            BindData();
        }
    }
}
