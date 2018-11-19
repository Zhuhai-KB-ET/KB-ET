using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using FOUNDERPCB.FUNC;
using FOUNDERPCB.DAL;
using FOUNDERPCB.Models;
using FOUNDERPCB.BLL;

namespace FOUNDERPCB.Module.PopWinForm.DL
{
    /// <summary>
    /// 数据层
    /// </summary>
    public partial class FrmData0583DL
    {
        #region 实例化
        FrmData0583 Frm;
        public FrmData0583DL(FrmData0583 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            {
                IList<DATA0583> info = new List<DATA0583>();
                DATA0011 infoD11 = new DATA0011();
                DATA0583BLL bll = new DATA0583BLL(Frm.DBConnection);
                DATA0011BLL bllD11 = new DATA0011BLL(Frm.DBConnection);
                string s_temp;

                info = bll.FindBySql("SOURCE_PTR = " + Frm.id_rkey.ToString() + " and SOURCE_TYPE = " + Frm.id_TYPE.ToString());
                for (int i=0;i<info.Count;i++)
                {
                    s_temp = "";
                    if (info[i].ACTION == 1) s_temp = "原值暂缓";
                    if (info[i].ACTION == 2) s_temp = "原值激活";                    
                    infoD11 = bllD11.getDATA0011ByRKEY(info[i].NOTEPAD_PTR);
                    Frm.textBox.Text = "日期：" + info[i].TDATE.ToShortDateString() + "   " + s_temp + "\r\n" + 
                                       infoD11.NOTE_PAD_LINE_1.Trim() + infoD11.NOTE_PAD_LINE_2.Trim() + infoD11.NOTE_PAD_LINE_3.Trim() + infoD11.NOTE_PAD_LINE_4.Trim() + "\r\n\r\n";
                }
                if (info.Count <= 0)
                    Frm.textBox.Text = "没有暂缓历史记录！";

                if (!Frm.ib_Edit)
                {
                    Frm.textBox.ReadOnly = true;
                    Frm.textBoxRecord.ReadOnly = true;
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
