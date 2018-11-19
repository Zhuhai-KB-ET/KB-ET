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
    public partial class FrmData0035DL
    {
        #region 实例化
        FrmData0035 Frm;
        public FrmData0035DL(FrmData0035 psFrm)
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

                s_SQL = @"
select rkey,
       rtrim(PRODUCTION_PARAMETER) as 参数代码
  from data0035 with (nolock) 
 where (1=1)
   AND (" + strWhere + @")
 order by data0035.rkey
";
                tb_GridView1 = bll.getDataSet(s_SQL); 
                 
                tb_GridView1 = tb_GridView1.DefaultView.ToTable(); 

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 270;
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
