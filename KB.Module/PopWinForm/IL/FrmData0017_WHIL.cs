using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;

namespace KB.Module.PopWinForm.IL
{
    /// <summary>
    /// 业务中间层
    /// </summary>
    public partial class FrmData0017_WHIL
    {
        #region 实例化
        DL.FrmData0017_WHDL FrmData0017_WHDL = null;
        FrmData0017_WH Frm;
        public FrmData0017_WHIL(FrmData0017_WH psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion

        #region FrmData0017_WH_Load
        public void FrmData0017_WH_Load(object sender, EventArgs e)
        {
            try
            {
                FrmData0017_WHDL = new KB.Module.PopWinForm.DL.FrmData0017_WHDL(Frm);

                Frm.textBoxFind.CharacterCasing = CharacterCasing.Upper;

                FrmData0017_WHDL.BinData("1=1");

                Frm.dataGridView1.Select();
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion
         
        #region buttonExit_Click
        public void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                Frm.DialogResult = DialogResult.Cancel; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonExit_KeyUp
        public void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    buttonExit_Click(sender, e);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion 
    }
}
