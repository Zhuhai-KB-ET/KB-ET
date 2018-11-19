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
    public partial class FrmData0015DL
    {
        #region 实例化
        FrmData0015 Frm;
        public FrmData0015DL(FrmData0015 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0015BLL bll = new DATA0015BLL(Frm.DBConnection);
                IList<DATA0015> IL_DATA0015;
                DataTable tb_GridView1;
                DataRow dr;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("仓库代码");
                tb_GridView1.Columns.Add("仓库名称");

                strWhere = "(" + strWhere + ")";
                strWhere += @"
 and ( (DATA0015.WAREHOUSE_TYPE = 0) OR (DATA0015.WAREHOUSE_TYPE = 1)) 
 and   (Data0015.ACTIVE_FLAG    = 0  OR  Data0015.ACTIVE_FLAG IS NULL) 
"; 

                IL_DATA0015 = bll.FindBySql(strWhere);

                for (int i = 0; i < IL_DATA0015.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = IL_DATA0015[i].RKEY.ToString();
                    dr[2] = IL_DATA0015[i].WAREHOUSE_CODE.Trim();
                    dr[3] = IL_DATA0015[i].WAREHOUSE_NAME.Trim();
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "仓库代码 ASC";
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
