using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;
using KB.Models;
using KB.BLL;

namespace KB.Module.PopWinForm.DL
{
    /// <summary>
    /// 数据层
    /// </summary>
    public partial class FrmNotepadDL
    {
        #region 实例化
        FrmNotepad Frm;
        public FrmNotepadDL(FrmNotepad psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            {
                DATA0011 info = new DATA0011();
                DATA0011BLL bll = new DATA0011BLL(Frm.DBConnection);

                info = bll.getDATA0011ByRKEY(Frm.id_rkey);
                if (info.RKEY > 0)
                    Frm.textBox.Text = info.NOTE_PAD_LINE_1.Trim() + info.NOTE_PAD_LINE_2.Trim() + info.NOTE_PAD_LINE_3.Trim() + info.NOTE_PAD_LINE_4.Trim();
                else
                    Frm.textBox.Text = "";

                if (Frm.is_memo.Trim().Length > 0)
                    Frm.textBox.Text = Frm.is_memo.Trim();

                if (!Frm.ib_Edit)
                {
                    Frm.textBox.ReadOnly = true;
                    Frm.buttonFind.Visible = false;
                }
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
