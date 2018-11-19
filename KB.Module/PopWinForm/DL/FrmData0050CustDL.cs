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
    public partial class FrmData0050CustDL
    {
        #region 实例化
        FrmData0050Cust Frm;
        public FrmData0050CustDL(FrmData0050Cust psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0050BLL bll = new DATA0050BLL(Frm.DBConnection); 
                DataTable tb_GridView1;
                DataTable tb;
                DataRow dr;
                string s_SQL = "";

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("部件代码");
                tb_GridView1.Columns.Add("部件描述");
                tb_GridView1.Columns.Add("版本");
                tb_GridView1.Columns.Add("客户代码");
                tb_GridView1.Columns.Add("客户名称");

                s_SQL = @"
select data0050.rkey                 as d50rkey, 
       data0050.CUSTOMER_PART_NUMBER as 部件代码,
       isnull(data0050.CUSTOMER_PART_DESC,'')  as 部件描述,
       isnull(data0050.CP_REV,'')    as 版本,
       data0010.CUST_CODE            as 客户代码,
       data0010.CUSTOMER_NAME        as 客户名称
  from data0050 with (nolock),data0010 with (nolock) 
 where data0050.CUSTOMER_PTR        = data0010.rkey
   and data0050.PRODUCTION_PART_PTR = data0050.RKEY  
   AND (" + strWhere + @")
";
                tb = bll.getDataSet(s_SQL);

                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = tb.Rows[i]["d50rkey"].ToString().Trim();
                    dr[2] = tb.Rows[i]["部件代码"].ToString().Trim();
                    dr[3] = tb.Rows[i]["部件描述"].ToString().Trim();
                    dr[4] = tb.Rows[i]["版本"].ToString().Trim();
                    dr[5] = tb.Rows[i]["客户代码"].ToString().Trim();
                    dr[6] = tb.Rows[i]["客户名称"].ToString().Trim();
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "部件代码 ASC";
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
                Frm.dataGridView1.Columns[4].Width = 60;
                Frm.dataGridView1.Columns[4].ReadOnly = true;

                Frm.dataGridView1.Columns[5].Visible = false;
                Frm.dataGridView1.Columns[6].Visible = false; 
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
