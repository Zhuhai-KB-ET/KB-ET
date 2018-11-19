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
    public partial class FrmData0034 : KB.Module.PopWinFormModule
    {
        #region 创建窗口
        IL.FrmData0034IL frmData0034IL = null;
        public FrmData0034()
        {
            InitializeComponent();
        } 
        #endregion

        #region FrmData0034_Load
        private void FrmData0034_Load(object sender, EventArgs e)
        {
            frmData0034IL = new KB.Module.PopWinForm.IL.FrmData0034IL(this);

            frmData0034IL.FrmData0034_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_Click(object sender, EventArgs e)
        {
            frmData0034IL.buttonFind_Click(sender, e);
        }
        private void buttonFind_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0034IL.buttonFind_KeyUp(sender, e);
        }
        #endregion

        #region textBoxFind
        private void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            frmData0034IL.textBoxFind_TextChanged(sender, e);
        }
        #endregion

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            frmData0034IL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0034IL.buttonExit_KeyUp(sender, e);
        }
        #endregion

        #region dataGridView1
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            frmData0034IL.dataGridView1_MouseDoubleClick(sender, e);
        } 
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            frmData0034IL.dataGridView1_SelectionChanged(sender, e);
        } 
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            frmData0034IL.dataGridView1_KeyDown(sender, e);
        } 
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            frmData0034IL.dataGridView1_KeyUp(sender, e);
        }
        #endregion
    }
}
