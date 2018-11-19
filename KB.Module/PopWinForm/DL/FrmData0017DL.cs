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
    public partial class FrmData0017DL
    {
        #region 实例化
        FrmData0017 Frm;
        public FrmData0017DL(FrmData0017 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0017BLL bll = new DATA0017BLL(Frm.DBConnection);
                DataTable tb;
                DataTable tb_GridView1;
                DataRow dr;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("制造部件编码");
                tb_GridView1.Columns.Add("制造部件描述");
                tb_GridView1.Columns.Add("PM");
                tb_GridView1.Columns.Add("可用库存");
                tb_GridView1.Columns.Add("寄售库存");

                tb = bll.getDataSet("select top 300 * from data0017 with (nolock) where (" + strWhere + ") and P_M = 'M' order by inv_part_number ");

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = tb.Rows[i]["RKEY"].ToString().Trim();
                    dr[2] = tb.Rows[i]["INV_PART_NUMBER"].ToString().Trim();
                    dr[3] = tb.Rows[i]["INV_PART_DESCRIPTION"].ToString().Trim();
                    dr[4] = tb.Rows[i]["P_M"].ToString().Trim();
                    if (tb.Rows[i]["QUAN_ON_HAND"].ToString().Trim().Length > 0)
                        dr[5] = decimal.Parse(tb.Rows[i]["QUAN_ON_HAND"].ToString().Trim()).ToString("#0.00");
                    else
                        dr[5] = "0.00";
                    if (tb.Rows[i]["CONSIGN_ONHAND_QTY"].ToString().Trim().Length > 0)
                        dr[6] = decimal.Parse(tb.Rows[i]["CONSIGN_ONHAND_QTY"].ToString().Trim()).ToString("#0.00");
                    else
                        dr[6] = "0.00";
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "制造部件编码 ASC";
                tb_GridView1 = tb_GridView1.DefaultView.ToTable();
                for (int i = 0; i < tb_GridView1.Rows.Count; i++)
                    tb_GridView1.Rows[i][1] = (i + 1).ToString("000000");

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 110;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 200;
                Frm.dataGridView1.Columns[3].ReadOnly = true;
                Frm.dataGridView1.Columns[4].Width = 40;
                Frm.dataGridView1.Columns[4].ReadOnly = true;
                Frm.dataGridView1.Columns[5].Width = 90;
                Frm.dataGridView1.Columns[5].ReadOnly = true;
                Frm.dataGridView1.Columns[6].Width = 90;
                Frm.dataGridView1.Columns[6].ReadOnly = true;
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
