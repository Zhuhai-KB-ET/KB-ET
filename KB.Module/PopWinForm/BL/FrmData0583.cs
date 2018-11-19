using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.PopWinForm
{
    public partial class FrmData0583 : KB.Module.ChildModule
    {
        #region 参数
        //data0583.SOURCE_PTR
        public decimal id_rkey = 0;
        //data0583.SOURCE_TYPE
        public decimal id_TYPE = 0;
        //是否能编辑
        public Boolean ib_Edit = true;
        #endregion

        #region 创建窗口
        IL.FrmData0583IL frmData0583IL = null;
        public FrmData0583()
        {
            InitializeComponent();
        }
        #endregion

        #region FrmData0583_Load
        private void FrmData0583_Load(object sender, EventArgs e)
        {
            frmData0583IL = new KB.Module.PopWinForm.IL.FrmData0583IL(this);

            frmData0583IL.FrmData0583_Load(sender, e);
        }
        #endregion
         
        #region buttonCancel
        private void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            frmData0583IL.buttonCancel_MouseClick(sender, e);
        } 
        private void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            frmData0583IL.buttonCancel_KeyDown(sender, e);
        }
        #endregion

        #region buttonOK
        private void buttonOK_MouseClick(object sender, MouseEventArgs e)
        {
            frmData0583IL.buttonOK_MouseClick(sender, e);
        }
        private void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            frmData0583IL.buttonOK_KeyDown(sender, e);
        }
        #endregion 
    }
}
