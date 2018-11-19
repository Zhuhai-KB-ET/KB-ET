using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.PopWinForm
{
    /// <summary>
    /// 界面层
    /// </summary>
    public partial class FrmData0017_WH2 : FOUNDERPCB.Module.PopWinFormModule
    {
        public decimal id_rkey = 0;

        #region 创建窗口
        IL.FrmData0017_WH2IL FrmData0017_WH2IL = null;
        public FrmData0017_WH2()
        {
            InitializeComponent();
        } 
        #endregion

        #region FrmData0017_WH2_Load
        private void FrmData0017_WH2_Load(object sender, EventArgs e)
        {
            FrmData0017_WH2IL = new FOUNDERPCB.Module.PopWinForm.IL.FrmData0017_WH2IL(this);

            FrmData0017_WH2IL.FrmData0017_WH2_Load(sender, e);
        }
        #endregion 

        #region buttonExit
        private void buttonExit_Click(object sender, EventArgs e)
        {
            FrmData0017_WH2IL.buttonExit_Click(sender, e);
        }
        private void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            FrmData0017_WH2IL.buttonExit_KeyUp(sender, e);
        }
        #endregion 
    }
}
