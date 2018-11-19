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
    public partial class FrmData0036DL
    {
        #region 实例化
        FrmData0036 Frm;
        public FrmData0036DL(FrmData0036 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0035BLL bll = new DATA0035BLL(Frm.DBConnection);
                string s_SQL;
                DataTable tb_GridView1; 

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("指令代码");
                tb_GridView1.Columns.Add("指令1");
                tb_GridView1.Columns.Add("指令2");
                tb_GridView1.Columns.Add("指令3");
                tb_GridView1.Columns.Add("指令4");

                s_SQL = @"
select  Data0036.RKEY              as rkey,
        Data0036.INST_CODE         as 指令代码,
        Data0036.PROD_ROUT_INST_1  as 指令1,
        Data0036.PROD_ROUT_INST_2  as 指令2,
        Data0036.PROD_ROUT_INST_3  as 指令3,
        Data0036.PROD_ROUT_INST_4  as 指令4
  from data0036 with (nolock) 
 where (1=1)
   AND (" + strWhere + @")
 order by Data0036.INST_CODE
";
                tb_GridView1 = bll.getDataSet(s_SQL); 
                 
                tb_GridView1 = tb_GridView1.DefaultView.ToTable(); 

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 100;
                Frm.dataGridView1.Columns[1].ReadOnly = true;

                Frm.dataGridView1.Columns[2].Width = 200;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 200;
                Frm.dataGridView1.Columns[3].ReadOnly = true;
                Frm.dataGridView1.Columns[4].Width = 200;
                Frm.dataGridView1.Columns[4].ReadOnly = true;
                Frm.dataGridView1.Columns[5].Width = 200;
                Frm.dataGridView1.Columns[5].ReadOnly = true; 
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
