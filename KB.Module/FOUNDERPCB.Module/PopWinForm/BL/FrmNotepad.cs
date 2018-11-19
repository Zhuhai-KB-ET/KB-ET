using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.PopWinForm
{
    public partial class FrmNotepad : FOUNDERPCB.Module.ChildModule
    {
        #region 参数
        //data0011RKEY
        public decimal id_rkey = 0;
        //是否能编辑
        public Boolean ib_Edit = true;
        //内容
        public string is_memo = "";
        #endregion

        #region 创建窗口
        IL.FrmNotepadIL frmNotepadIL = null;
        public FrmNotepad()
        {
            InitializeComponent();
        }
        #endregion

        #region FrmNotepad_Load
        private void FrmNotepad_Load(object sender, EventArgs e)
        {
            frmNotepadIL = new FOUNDERPCB.Module.PopWinForm.IL.FrmNotepadIL(this);

            frmNotepadIL.FrmNotepad_Load(sender, e);
        }
        #endregion

        #region buttonFind
        private void buttonFind_MouseClick(object sender, MouseEventArgs e)
        {
            frmNotepadIL.buttonFind_MouseClick(sender, e);
        }
        private void buttonFind_KeyDown(object sender, KeyEventArgs e)
        {
            frmNotepadIL.buttonFind_KeyDown(sender, e);
        }
        #endregion

        #region buttonCancel
        private void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            frmNotepadIL.buttonCancel_MouseClick(sender, e);
        } 
        private void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            frmNotepadIL.buttonCancel_KeyDown(sender, e);
        }
        #endregion

        #region buttonOK
        private void buttonOK_MouseClick(object sender, MouseEventArgs e)
        {
            frmNotepadIL.buttonOK_MouseClick(sender, e);
        }
        private void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            frmNotepadIL.buttonOK_KeyDown(sender, e);
        }
        #endregion

        #region textBox_TextChanged
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            frmNotepadIL.textBox_TextChanged(sender, e);
        }
        private void textBox_KeyUp(object sender, KeyEventArgs e)
        {
            frmNotepadIL.textBox_KeyUp(sender, e);
        }
        #endregion 
    }
}
