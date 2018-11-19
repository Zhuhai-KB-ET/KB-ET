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
    public partial class FrmData0034DL
    {
        #region 实例化
        FrmData0034 Frm;
        public FrmData0034DL(FrmData0034 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0034BLL bll = new DATA0034BLL(Frm.DBConnection);
                string s_SQL;
                DataTable tb_GridView1; 

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey"); 
                tb_GridView1.Columns.Add("生产资源代码");
                tb_GridView1.Columns.Add("生产资源名称"); 

                s_SQL = @"
select data0034.rkey,
       data0034.DEPT_CODE as 生产资源代码,
       data0034.DEPT_NAME as 生产资源名称 
  from data0034 with (nolock)
 where (Data0034.ACTIVE_FLAG = 0 OR Data0034.ACTIVE_FLAG IS NULL)
   AND (" + strWhere + @") 
 order by data0034.DEPT_CODE
";
                tb_GridView1 = bll.getDataSet(s_SQL); 
                 
                tb_GridView1 = tb_GridView1.DefaultView.ToTable(); 

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 150;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 180;
                Frm.dataGridView1.Columns[2].ReadOnly = true;  
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
