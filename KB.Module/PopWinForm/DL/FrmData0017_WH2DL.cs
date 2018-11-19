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
    public partial class FrmData0017_WH2DL
    {
        #region 实例化
        FrmData0017_WH2 Frm;
        public FrmData0017_WH2DL(FrmData0017_WH2 psFrm)
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
                DataTable tb_GridView1;
                DataRow dr;
                string s_SQL;

                tb_GridView1 = new DataTable(); 
                tb_GridView1.Columns.Add("地点");
                tb_GridView1.Columns.Add("可用库存");
                tb_GridView1.Columns.Add("已分配库存");


                tb = bll.getDataSet("select * from data0017 with (nolock) where rkey = " + Frm.id_rkey.ToString());
                infoD02 = bllD02.getDATA0002ByRKEY(decimal.Parse(tb.Rows[0]["STOCK_UNIT_PTR"].ToString().Trim()));

                Frm.textBoxInv_Part_Number.Text = tb.Rows[0]["inv_part_number"].ToString().Trim();
                Frm.labelInv_Part_Desc.Text = tb.Rows[0]["INV_PART_DESCRIPTION"].ToString().Trim();
                Frm.labelInv_Unit.Text = infoD02.UNIT_NAME.Trim();
                 
                s_SQL = @"
select data0016.CODE,
       data0016.LOCATION,
       data0019.QUAN_ON_HAND,
       data0019.QUAN_ALLOCATED 
  from DATA0019 with (nolock),DATA0017 with (nolock),DATA0018 with (nolock),data0016 with (nolock)
 where data0019.INVENTORY_PTR = data0017.RKEY
   and data0019.INV_WHOUSE_PTR = data0018.RKEY
   and data0019.LOCATION_PTR = data0016.RKEY 
   and data0017.rkey = " + Frm.id_rkey.ToString() + @"
  order by data0016.CODE
";
                tb = bll.getDataSet(s_SQL); 

                s_SQL = @"
SELECT (SUM(D467.QUAN_ORD) - SUM(D467.QUAN_RECD) + SUM(D467.QUAN_RETN) + SUM(D467.QUAN_IN_INSP)) AS ROQTY 
  FROM  DATA0467 D467 WITH (NOLOCK) , DATA0466 D466  WITH (NOLOCK) 
 WHERE D467.RO_PTR = D466.RKEY
   AND D467.INVT_PTR = " + Frm.id_rkey.ToString() + @"
   AND (D467.QUAN_ORD) - (D467.QUAN_RECD) + (D467.QUAN_RETN) + (D467.QUAN_IN_INSP) > 0.0 
   AND D466.STATUS = 1 
";
                tb2 = bll.getDataSet(s_SQL);

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = tb.Rows[i]["LOCATION"].ToString().Trim();
                    dr[1] = decimal.Parse(tb.Rows[0]["QUAN_ON_HAND"].ToString().Trim()).ToString("#0.00");
                    dr[2] = decimal.Parse(tb.Rows[0]["QUAN_ALLOCATED"].ToString().Trim()).ToString("#0.00");
                    tb_GridView1.Rows.Add(dr);
                }
                 
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Width = 150;
                Frm.dataGridView1.Columns[0].ReadOnly = true;
                Frm.dataGridView1.Columns[1].Width = 150;
                Frm.dataGridView1.Columns[1].ReadOnly = true; 
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
