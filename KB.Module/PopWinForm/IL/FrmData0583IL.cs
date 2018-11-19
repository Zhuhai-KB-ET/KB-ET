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
    public partial class FrmData0583IL
    {
        #region 实例化
        DL.FrmData0583DL frmData0583DL = null;
        FrmData0583 Frm;
        public FrmData0583IL(FrmData0583 psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion

        #region FrmData0583_Load
        public void FrmData0583_Load(object sender, EventArgs e)
        {
            try
            {
                frmData0583DL = new KB.Module.PopWinForm.DL.FrmData0583DL(Frm);

                frmData0583DL.BinData("1=1");
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion
 
        #region buttonCancel
        public void buttonCancel_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                Frm.ReturnValue = "";
                Frm.DialogResult = DialogResult.Cancel; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        public void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) buttonCancel_MouseClick(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonOK
        public void buttonOK_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {    
                Frm.ReturnValue = Frm.textBoxRecord.Text.Trim();
                Frm.DialogResult = DialogResult.OK; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        public void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter) buttonOK_MouseClick(null, null);
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
