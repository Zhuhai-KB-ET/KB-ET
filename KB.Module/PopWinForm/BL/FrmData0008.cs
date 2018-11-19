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
    public partial class FrmData0008 : KB.Module.PopWinFormModule
    {
        #region 创建窗口
        IL.FrmData0008IL frmData0008IL = null;
        public FrmData0008()
        {
            InitializeComponent();
        } 
        #endregion

        #region FrmData0008_Load
        private void FrmData0008_Load(object sender, EventArgs e)
        {
            frmData0008IL = new KB.Module.PopWinForm.IL.FrmData0008IL(this);

            frmData0008IL.FrmData0008_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_Click(object sender, EventArgs e)
        {
            frmData0008IL.buttonFind_Click(sender, e);
        }
        private void buttonFind_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0008IL.buttonFind_KeyUp(sender, e);
        }
        #endregion

        #region textBoxFind
        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            frmData0008IL.textBoxFind_TextChanged(sender, e);
        }
        #endregion

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            frmData0008IL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0008IL.buttonExit_KeyUp(sender, e);
        }
        #endregion

        #region dataGridView1
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmData0008IL.dataGridView1_MouseDoubleClick(sender, e);
        } 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            frmData0008IL.dataGridView1_SelectionChanged(sender, e);
        } 
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            frmData0008IL.dataGridView1_KeyDown(sender, e);
        } 
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0008IL.dataGridView1_KeyUp(sender, e);
        }
        #endregion
    }
}
