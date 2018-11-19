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
    public partial class FrmData0469DL
    {
        #region 实例化
        FrmData0469 Frm;
        public FrmData0469DL(FrmData0469 psFrm)
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
                tb_GridView1.Columns.Add("参数代码");
                tb_GridView1.Columns.Add("参数名称");
                tb_GridView1.Columns.Add("PARAMETER_VALUE"); 

                s_SQL = @"
select Data0469.RKEY                   as rkey,
       rtrim(Data0469.PARAMETER_CODE)  as 参数代码,
       rtrim(Data0469.PARAMETER_DESC)  as 参数名称,
       rtrim(Data0469.PARAMETER_VALUE) as PARAMETER_VALUE
  from Data0469 with (nolock) 
 where (Data0469.ACTIVE_FLAG = 0 OR Data0469.ACTIVE_FLAG IS NULL)
   AND (" + strWhere + @")
 order by Data0469.PARAMETER_CODE
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
                Frm.dataGridView1.Columns[3].Visible = false;
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
