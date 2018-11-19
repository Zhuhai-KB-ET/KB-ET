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
    public partial class FrmData0193DL
    {
        #region 实例化
        FrmData0193 Frm;
        public FrmData0193DL(FrmData0193 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0193BLL bll = new DATA0193BLL(Frm.DBConnection); 
                IList<DATA0193> IL_DATA0193; 
                DataTable tb_GridView1;
                DataTable tb_temp;
                DataRow dr;
                string s_SQL = "";

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("代码");
                tb_GridView1.Columns.Add("名称");
                tb_GridView1.Columns.Add("内容");

                IL_DATA0193 = bll.FindBySql(strWhere);

                for (int i = 0; i < IL_DATA0193.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = IL_DATA0193[i].RECORD_KEY.ToString();
                    dr[2] = IL_DATA0193[i].CODE.Trim();
                    dr[3] = IL_DATA0193[i].DESCRIPTION.Trim(); 
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "代码 ASC";
                tb_GridView1 = tb_GridView1.DefaultView.ToTable();
                for (int i = 0; i < tb_GridView1.Rows.Count; i++)
                {
                    tb_GridView1.Rows[i][1] = (i + 1).ToString("0000");

                    s_SQL = @"
select *
  from data0194 with (nolock)
 where HEADER_POINTER = " + tb_GridView1.Rows[i][0].ToString() + @"
 order by SEQUENCE_NUMBER
";
                    tb_temp = bll.getDataSet(s_SQL);
                    tb_GridView1.Rows[i][4] = "";
                    for (int j = 0; j < tb_temp.Rows.Count; j++)
                    {
                        tb_GridView1.Rows[i][4] += "\r\n" + tb_temp.Rows[j]["TEXT_LINE"].ToString();
                    }
                }

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 80;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 170;
                Frm.dataGridView1.Columns[3].ReadOnly = true;
                Frm.dataGridView1.Columns[4].Width = 100;
                Frm.dataGridView1.Columns[4].ReadOnly = true;
                Frm.dataGridView1.Columns[4].Visible = false;
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
