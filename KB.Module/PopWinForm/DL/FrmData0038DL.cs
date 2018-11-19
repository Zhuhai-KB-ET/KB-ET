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
    public partial class FrmData0038DL
    {
        #region 实例化
        FrmData0038 Frm;
        public FrmData0038DL(FrmData0038 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0038BLL bll = new DATA0038BLL(Frm.DBConnection);
                string s_SQL;
                DataTable tb_GridView1; 

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("制程");
                tb_GridView1.Columns.Add("部门代码");
                tb_GridView1.Columns.Add("部门名称");
                tb_GridView1.Columns.Add("权重");
                tb_GridView1.Columns.Add("多重单位");
                tb_GridView1.Columns.Add("事务处理");

                s_SQL = @"
select data0038.rkey,
       data0038.STEP_NUMBER as 制程,      
       data0034.DEPT_CODE as 部门代码,
       data0034.DEPT_NAME as 部门名称,
       cast(data0038.PERCENT_COMPLETE as numeric(14,2)) as 权重,
       case when data0038.UNIT_FLAG = 'Y' then '是' else '否' end as 多重单位,
       '否' as 事务处理       
  from data0038 with (nolock)
           left join data0034 with (nolock) on data0034.rkey = data0038.DEPT_PTR
 where data0038.TTYPE       = " + Frm.ReceiveValue.Trim().Split('|')[1] + @" 
   AND data0038.STEP_NUMBER > 0
   AND (" + strWhere + @")
   AND DATA0038.SOURCE_PTR = " + Frm.ReceiveValue.Trim().Split('|')[0] + @"
 order by data0038.STEP_NUMBER
";
                tb_GridView1 = bll.getDataSet(s_SQL); 
                 
                tb_GridView1 = tb_GridView1.DefaultView.ToTable(); 

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 80;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 270;
                Frm.dataGridView1.Columns[3].ReadOnly = true;

                Frm.dataGridView1.Columns[4].HeaderText += "%";
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
