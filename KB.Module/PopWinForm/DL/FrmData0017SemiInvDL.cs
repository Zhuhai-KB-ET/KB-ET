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
    public partial class FrmData0017SemiInvDL
    {
        #region 实例化
        FrmData0017SemiInv Frm;
        public FrmData0017SemiInvDL(FrmData0017SemiInv psFrm)
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
                string s_SQL;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("制造部件编码");
                tb_GridView1.Columns.Add("制造部件描述");
                tb_GridView1.Columns.Add("UnitBomRKEY");
                tb_GridView1.Columns.Add("UnitBomCODE");
                tb_GridView1.Columns.Add("UnitBomNAME");
                tb_GridView1.Columns.Add("UnitWHRKEY");
                tb_GridView1.Columns.Add("UnitWHCODE");
                tb_GridView1.Columns.Add("UnitWHNAME");

                tb_GridView1.Columns.Add("PM");
                tb_GridView1.Columns.Add("可用库存");
                tb_GridView1.Columns.Add("寄售库存");

                s_SQL = @"
select top 300 *,
       d02Bom.rkey as d02BomRkey,d02Bom.UNIT_CODE as d02BomUNIT_CODE,d02Bom.UNIT_NAME as d02BomUNIT_NAME,
       d02WH.rkey  as d02WHRkey, d02WH.UNIT_CODE  as d02WHUNIT_CODE, d02WH.UNIT_NAME  as d02WHUNIT_NAME
  from data0017 with (nolock)
           left join data0002 d02Bom with (nolock) on d02Bom.rkey = data0017.BOM_UNIT_PTR
           left join data0002 d02WH  with (nolock) on d02WH.rkey  = data0017.STOCK_UNIT_PTR
 where (" + strWhere + @")  
   and (Data0017.TTYPE = 'R' or 
        Data0017.TTYPE = 'S' or 
        Data0017.TTYPE = 'T' or 
        Data0017.TTYPE = 'M' or 
        Data0017.TTYPE = 'P' or 
        Data0017.TTYPE = 'C')
   and Data0017.ACTIVE_FLAG = 'Y'  
 order by inv_part_number 
";
                tb = bll.getDataSet(s_SQL);

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = tb.Rows[i]["RKEY"].ToString().Trim();
                    dr[2] = tb.Rows[i]["INV_PART_NUMBER"].ToString().Trim();
                    dr[3] = tb.Rows[i]["INV_PART_DESCRIPTION"].ToString().Trim();

                    dr[4] = tb.Rows[i]["d02BomRkey"].ToString().Trim();
                    dr[5] = tb.Rows[i]["d02BomUNIT_CODE"].ToString().Trim();
                    dr[6] = tb.Rows[i]["d02BomUNIT_NAME"].ToString().Trim();

                    dr[7] = tb.Rows[i]["d02WHRkey"].ToString().Trim();
                    dr[8] = tb.Rows[i]["d02WHUNIT_CODE"].ToString().Trim();
                    dr[9] = tb.Rows[i]["d02WHUNIT_NAME"].ToString().Trim();

                    dr[10] = tb.Rows[i]["P_M"].ToString().Trim();
                    if (tb.Rows[i]["QUAN_ON_HAND"].ToString().Trim().Length > 0)
                        dr[11] = decimal.Parse(tb.Rows[i]["QUAN_ON_HAND"].ToString().Trim()).ToString("#0.00");
                    else
                        dr[11] = "0.00";
                    if (tb.Rows[i]["CONSIGN_ONHAND_QTY"].ToString().Trim().Length > 0)
                        dr[12] = decimal.Parse(tb.Rows[i]["CONSIGN_ONHAND_QTY"].ToString().Trim()).ToString("#0.00");
                    else
                        dr[12] = "0.00";
                    tb_GridView1.Rows.Add(dr);
                }
                 
                tb_GridView1 = tb_GridView1.DefaultView.ToTable();
                for (int i = 0; i < tb_GridView1.Rows.Count; i++)
                    tb_GridView1.Rows[i][1] = (i + 1).ToString("000000");

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 130;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 270;
                Frm.dataGridView1.Columns[3].ReadOnly = true;

                Frm.dataGridView1.Columns[4].Visible = false;
                Frm.dataGridView1.Columns[5].Visible = false;
                Frm.dataGridView1.Columns[6].Visible = false;
                Frm.dataGridView1.Columns[7].Visible = false;
                Frm.dataGridView1.Columns[8].Visible = false;
                Frm.dataGridView1.Columns[9].Visible = false;

                Frm.dataGridView1.Columns[10].Width = 50;
                Frm.dataGridView1.Columns[10].ReadOnly = true;
                Frm.dataGridView1.Columns[11].Width = 100;
                Frm.dataGridView1.Columns[11].ReadOnly = true; 
                Frm.dataGridView1.Columns[12].Width = 100;
                Frm.dataGridView1.Columns[12].ReadOnly = true;
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
