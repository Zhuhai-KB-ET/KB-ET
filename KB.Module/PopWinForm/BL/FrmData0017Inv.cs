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
    public partial class FrmData0017Inv : KB.Module.PopWinFormModule
    {
        #region 创建窗口
        IL.FrmData0017InvIL FrmData0017InvIL = null;
        public FrmData0017Inv()
        {
            InitializeComponent();
        } 
        #endregion

        #region FrmData0017Inv_Load
        private void FrmData0017Inv_Load(object sender, EventArgs e)
        {
            FrmData0017InvIL = new KB.Module.PopWinForm.IL.FrmData0017InvIL(this);

            FrmData0017InvIL.FrmData0017Inv_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_Click(object sender, EventArgs e)
        {
            FrmData0017InvIL.buttonFind_Click(sender, e);
        }
        private void buttonFind_KeyUp(object sender, KeyEventArgs e)
        {
            FrmData0017InvIL.buttonFind_KeyUp(sender, e);
        }
        #endregion

        #region textBoxFind
        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            FrmData0017InvIL.textBoxFind_TextChanged(sender, e);
        }
        #endregion

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            FrmData0017InvIL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            FrmData0017InvIL.buttonExit_KeyUp(sender, e);
        }
        #endregion

        #region dataGridView1
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FrmData0017InvIL.dataGridView1_MouseDoubleClick(sender, e);
        } 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            FrmData0017InvIL.dataGridView1_SelectionChanged(sender, e);
        } 
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            FrmData0017InvIL.dataGridView1_KeyDown(sender, e);
        } 
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            FrmData0017InvIL.dataGridView1_KeyUp(sender, e);
        }
        #endregion
    }
}
