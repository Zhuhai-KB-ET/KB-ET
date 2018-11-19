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
    public partial class FrmData0017_WH : KB.Module.PopWinFormModule
    {
        public decimal id_rkey = 0;

        #region 创建窗口
        IL.FrmData0017_WHIL FrmData0017_WHIL = null;
        public FrmData0017_WH()
        {
            InitializeComponent();
        } 
        #endregion

        #region FrmData0017_WH_Load
        private void FrmData0017_WH_Load(object sender, EventArgs e)
        {
            FrmData0017_WHIL = new KB.Module.PopWinForm.IL.FrmData0017_WHIL(this);

            FrmData0017_WHIL.FrmData0017_WH_Load(sender, e);
        }
        #endregion 

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            FrmData0017_WHIL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            FrmData0017_WHIL.buttonExit_KeyUp(sender, e);
        }
        #endregion 
    }
}
