﻿using System;
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
    public partial class FrmData0497DL
    {
        #region 实例化
        FrmData0497 Frm;
        public FrmData0497DL(FrmData0497 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0497BLL bll = new DATA0497BLL(Frm.DBConnection);
                IList<DATA0497> IL_DATA0497;
                DataTable tb_GridView1;
                DataRow dr;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("审批流程代码");
                tb_GridView1.Columns.Add("审批流程名称");

                strWhere = "(" + strWhere + ")";
                strWhere += @"
   and Data0497.ACTIVE_FLAG   = 0 
   and Data0497.APPROVAL_TYPE = 1
   and Data0497.APPROVAL_ROUTE_CODE > ''
";

                IL_DATA0497 = bll.FindBySql(strWhere);

                for (int i = 0; i < IL_DATA0497.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = IL_DATA0497[i].RKEY.ToString();
                    dr[2] = IL_DATA0497[i].APPROVAL_ROUTE_CODE.Trim();
                    dr[3] = IL_DATA0497[i].APPROVAL_ROUTE_DESC.Trim();
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "审批流程代码 ASC";
                tb_GridView1 = tb_GridView1.DefaultView.ToTable();
                for (int i = 0; i < tb_GridView1.Rows.Count; i++)
                    tb_GridView1.Rows[i][1] = (i + 1).ToString("0000");

                //dataGridView1.Columns.Clear();
                Frm.dataGridView1.DataSource = tb_GridView1;
                Frm.dataGridView1.Columns[0].Visible = false;
                Frm.dataGridView1.Columns[1].Width = 50;
                Frm.dataGridView1.Columns[1].ReadOnly = true;
                Frm.dataGridView1.Columns[2].Width = 110;
                Frm.dataGridView1.Columns[2].ReadOnly = true;
                Frm.dataGridView1.Columns[3].Width = 230;
                Frm.dataGridView1.Columns[3].ReadOnly = true; 
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
