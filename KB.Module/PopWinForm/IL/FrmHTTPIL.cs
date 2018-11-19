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
    public partial class FrmHTTPIL
    {
        #region 实例化
        DL.FrmHTTPDL frmHTTPDL = null;
        FrmHTTP Frm;
        public FrmHTTPIL(FrmHTTP psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion

        #region FrmHTTP_Load
        public void FrmHTTP_Load(object sender, EventArgs e)
        {
            try
            {
                frmHTTPDL = new KB.Module.PopWinForm.DL.FrmHTTPDL(Frm); 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonOK
        public void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Frm.ReturnValue = Frm.textBox1.Text.Trim();
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
                if (e.KeyCode == Keys.Enter)
                    buttonOK_Click(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonCancel
        public void buttonCancel_Click(object sender, EventArgs e)
        {
            Frm.Close();
        }
        public void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    buttonCancel_Click(null, null);
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
