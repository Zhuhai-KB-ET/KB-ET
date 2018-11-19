using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.PopWinForm
{
    public partial class FrmHTTP : KB.Module.ChildModule
    {
        #region 创建窗口
        IL.FrmHTTPIL frmHTTPIL = null;
        public FrmHTTP()
        {
            InitializeComponent();
        }
        #endregion

        #region FrmHTTP_Load
        private void FrmHTTP_Load(object sender, EventArgs e)
        {
            frmHTTPIL = new KB.Module.PopWinForm.IL.FrmHTTPIL(this);

            frmHTTPIL.FrmHTTP_Load(sender, e);
        }
        #endregion

        #region buttonOK
        private void buttonOK_Click(object sender, EventArgs e)
        {
            frmHTTPIL.buttonOK_Click(sender, e);
        }
        private void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            frmHTTPIL.buttonOK_KeyDown(sender, e);
        }
        #endregion

        #region buttonCancel
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            frmHTTPIL.buttonCancel_Click(sender, e);
        }
        private void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            frmHTTPIL.buttonCancel_KeyDown(sender, e);
        }
        #endregion 
    }
}
