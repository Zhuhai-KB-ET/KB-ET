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
    public partial class FrmDateIL
    {
        #region 实例化
        DL.FrmDateDL frmDateDL = null;
        FrmDate Frm;
        public FrmDateIL(FrmDate psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion 

        #region FrmDate_Load
        public void FrmDate_Load(object sender, EventArgs e)
        {
            
        }
        #endregion

        #region buttonCancel
        public void buttonCancel_Click(object sender, EventArgs e)
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

        #region buttonOK
        public void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Frm.ReturnValue = Frm.monthCalendar.SelectionRange.Start.Year.ToString("0000") + "-" + Frm.monthCalendar.SelectionRange.Start.Month.ToString("00") + "-" + Frm.monthCalendar.SelectionRange.Start.Day.ToString("00");

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
    }
}
