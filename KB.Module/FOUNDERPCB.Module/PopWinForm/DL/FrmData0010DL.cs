﻿using System;
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
    public partial class FrmData0010DL
    {
        #region 实例化
        FrmData0010 Frm;
        public FrmData0010DL(FrmData0010 psFrm)
        {
            Frm = psFrm; 
        }
        #endregion 

        #region BinData
        public void BinData(string strWhere)
        {
            try
            { 
                DATA0010BLL bll = new DATA0010BLL(Frm.DBConnection);
                IList<DATA0010> IL_DATA0010;
                DataTable tb_GridView1;
                DataRow dr;

                tb_GridView1 = new DataTable();
                tb_GridView1.Columns.Add("rkey");
                tb_GridView1.Columns.Add("序");
                tb_GridView1.Columns.Add("客户代码");
                tb_GridView1.Columns.Add("客户名称");

                IL_DATA0010 = bll.FindBySql("(" + strWhere + ")");

                for (int i = 0; i < IL_DATA0010.Count; i++)
                {
                    dr = tb_GridView1.NewRow();
                    dr[0] = IL_DATA0010[i].RKEY.ToString();
                    dr[2] = IL_DATA0010[i].CUST_CODE.Trim();
                    dr[3] = IL_DATA0010[i].CUSTOMER_NAME.Trim();
                    tb_GridView1.Rows.Add(dr);
                }

                tb_GridView1.DefaultView.Sort = "客户代码 ASC";
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
