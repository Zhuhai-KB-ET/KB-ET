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
    public partial class FrmData0017_WHDL
    {
        #region 实例化
        FrmData0017_WH Frm;
        public FrmData0017_WHDL(FrmData0017_WH psFrm)
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
                DATA0002BLL bllD02 = new DATA0002BLL(Frm.DBConnection);
                DATA0002 infoD02 = new DATA0002();
                DataTable tb,tb2;
                DataTable tb_GridView1, tb_GridView2;
                DataRow dr;
                string s_SQL;

                tb_GridView1 = new DataTable(); 
                tb_GridView1.Columns.Add("名称");
                tb_GridView1.Columns.Add("库存");

                tb_GridView2 = new DataTable();
                tb_GridView2.Columns.Add("名称");
                tb_GridView2.Columns.Add("库存");
                
                tb = bll.getDataSet("select * from data0017 with (nolock) where rkey = " + Frm.id_rkey.ToString());
                infoD02 = bllD02.getDATA0002ByRKEY(decimal.Parse(tb.Rows[0]["STOCK_UNIT_PTR"].ToString().Trim()));

                Frm.textBoxInv_Part_Number.Text = tb.Rows[0]["inv_part_number"].ToString().Trim();
                Frm.labelInv_Part_Desc.Text = tb.Rows[0]["INV_PART_DESCRIPTION"].ToString().Trim();
                Frm.labelInv_Unit.Text = infoD02.UNIT_NAME.Trim();

                s_SQL = @"
SELECT isnull((SUM(D467.QUAN_ORD) - SUM(D467.QUAN_RECD) + SUM(D467.QUAN_RETN) + SUM(D467.QUAN_IN_INSP)),0) AS ROQTY 
  FROM  DATA0467 D467 WITH (NOLOCK) , DATA0466 D466  WITH (NOLOCK) 
 WHERE D467.RO_PTR = D466.RKEY
   AND D467.INVT_PTR = " + Frm.id_rkey.ToString() + @"
   AND (D467.QUAN_ORD) - (D467.QUAN_RECD) + (D467.QUAN_RETN) + (D467.QUAN_IN_INSP) > 0.0 
   AND D466.STATUS = 1 
";
                tb2 = bll.getDataSet(s_SQL);

                Frm.groupBox1.Text = "仓库总库存：" + decimal.Parse(tb.Rows[0]["QUAN_ON_HAND"].ToString()).ToString("#0.00");
                Frm.groupBox2.Text = "寄售仓总库存：" + decimal.Parse(tb.Rows[0]["CONSIGN_ONHAND_QTY"].ToString()).ToString("#0.00");

                #region 仓库
                dr = tb_GridView1.NewRow();
                dr[0] = "在途数量";
                dr[1] = decimal.Parse( tb.Rows[0]["QUAN_IN_TRANSIT"].ToString().Trim()).ToString("#0.00"); 
                tb_GridView1.Rows.Add(dr);

                dr = tb_GridView1.NewRow();
                dr[0] = "在检数量";
                dr[1] = decimal.Parse(tb.Rows[0]["QUAN_IN_INSP"].ToString().Trim()).ToString("#0.00");
                tb_GridView1.Rows.Add(dr);

                dr = tb_GridView1.NewRow();
                dr[0] = "待入库数量";
                dr[1] = decimal.Parse(tb.Rows[0]["QUAN_BACKLOG"].ToString().Trim()).ToString("#0.00");
                tb_GridView1.Rows.Add(dr);

                dr = tb_GridView1.NewRow();
                dr[0] = "可用库存";
                dr[1] = (decimal.Parse(tb.Rows[0]["QUAN_ON_HAND"].ToString().Trim()) - decimal.Parse(tb.Rows[0]["QUAN_ALLOCATED"].ToString().Trim())).ToString("#0.00");
                tb_GridView1.Rows.Add(dr);

                dr = tb_GridView1.NewRow();
                dr[0] = "已分配库存";
                dr[1] = decimal.Parse(tb.Rows[0]["QUAN_ALLOCATED"].ToString().Trim()).ToString("#0.00");
                tb_GridView1.Rows.Add(dr);
                #endregion

                #region 寄售
                dr = tb_GridView2.NewRow();
                dr[0] = "待检数量";
                dr[1] = decimal.Parse(tb.Rows[0]["CONSIGN_QTY_IN_INSP"].ToString().Trim()).ToString("#0.00");
                tb_GridView2.Rows.Add(dr);

                dr = tb_GridView2.NewRow();
                dr[0] = "开立RO数量";
                if (tb2.Rows.Count > 0)
                    dr[1] = decimal.Parse(tb2.Rows[0]["ROQTY"].ToString().Trim()).ToString("#0.00");
                else
                    dr[1] = "0";
                tb_GridView2.Rows.Add(dr);
                #endregion
                 
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Width = 150;
                Frm.dataGridView1.Columns[0].ReadOnly = true;
                Frm.dataGridView1.Columns[1].Width = 150;
                Frm.dataGridView1.Columns[1].ReadOnly = true;

                Frm.dataGridView2.DataSource = tb_GridView2;
                Frm.dataGridView2.Columns[0].Width = 150;
                Frm.dataGridView2.Columns[0].ReadOnly = true;
                Frm.dataGridView2.Columns[1].Width = 150;
                Frm.dataGridView2.Columns[1].ReadOnly = true; 
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
