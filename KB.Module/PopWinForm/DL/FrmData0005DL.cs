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
    public partial class FrmData0005DL
    {
        #region 实例化
        FrmData0005 Frm;
        public FrmData0005DL(FrmData0005 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0005BLL bll = new DATA0005BLL(Frm.DBConnection);
                IList<DATA0005> IL_DATA0005;
                DataTable tb_GridView1;
                DataRow dr;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("雇员代码");
                tb_GridView1.Columns.Add("雇员名称");

                IL_DATA0005 = bll.FindBySql("(" + strWhere + ") and ACTIVE_FLAG = 'Y'");

                for (int i = 0; i < IL_DATA0005.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = IL_DATA0005[i].RKEY.ToString();
                    dr[2] = IL_DATA0005[i].EMPL_CODE.Trim();
                    dr[3] = IL_DATA0005[i].EMPLOYEE_NAME.Trim();
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "雇员代码 ASC";
                tb_GridView1 = tb_GridView1.DefaultView.ToTable();
                for (int i = 0; i < tb_GridView1.Rows.Count; i++)
                    tb_GridView1.Rows[i][1] = (i + 1).ToString("0000");

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 80;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 270;
                Frm.dataGridView1.Columns[3].ReadOnly = true; 
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
