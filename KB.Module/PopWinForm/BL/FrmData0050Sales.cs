using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.PopWinForm
{
    /// <summary>
    /// 界面层
    /// </summary>
    public partial class FrmData0050Sales : KB.Module.PopWinFormModule
    {
        #region 参数
        public string is_CustCode = "";
        #endregion

        #region 创建窗口
        IL.FrmData0050SalesIL frmData0050SalesIL = null;
        public FrmData0050Sales(string ps_CustCode)
        {
            is_CustCode = ps_CustCode;
            InitializeComponent();
        } 
        #endregion

        #region FrmData0050Sales_Load
        private void FrmData0050Sales_Load(object sender, EventArgs e)
        {
            frmData0050SalesIL = new KB.Module.PopWinForm.IL.FrmData0050SalesIL(this);

            frmData0050SalesIL.FrmData0050Sales_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_Click(object sender, EventArgs e)
        {
            frmData0050SalesIL.buttonFind_Click(sender, e);
        }
        private void buttonFind_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0050SalesIL.buttonFind_KeyUp(sender, e);
        }
        #endregion

        #region textBoxFind
        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            frmData0050SalesIL.textBoxFind_TextChanged(sender, e);
        }
        #endregion

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            frmData0050SalesIL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0050SalesIL.buttonExit_KeyUp(sender, e);
        }
        #endregion

        #region dataGridView1
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmData0050SalesIL.dataGridView1_MouseDoubleClick(sender, e);
        } 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            frmData0050SalesIL.dataGridView1_SelectionChanged(sender, e);
        } 
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            frmData0050SalesIL.dataGridView1_KeyDown(sender, e);
        } 
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0050SalesIL.dataGridView1_KeyUp(sender, e);
        }
        #endregion
    }
}
