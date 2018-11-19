﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using FOUNDERPCB.FUNC;
using FOUNDERPCB.DAL;

namespace FOUNDERPCB.Module.PopWinForm.IL
{
    /// <summary>
    /// 业务中间层
    /// </summary>
    public partial class FrmData0035IL
    {
        #region 实例化
        DL.FrmData0035DL frmData0035DL = null;
        FrmData0035 Frm;
        public FrmData0035IL(FrmData0035 psFrm)
        {
            Frm = psFrm;
            Frm.DBConnection = new DBHelper(psFrm);
        }
        #endregion

        #region FrmData0035_Load
        public void FrmData0035_Load(object sender, EventArgs e)
        {
            try
            {
                frmData0035DL = new FOUNDERPCB.Module.PopWinForm.DL.FrmData0035DL(Frm);

                Frm.textBoxFind.CharacterCasing = CharacterCasing.Upper;
                 
                textBoxFind_TextChanged(null, null);

                Frm.dataGridView1.Select();
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonFind_Click
        public void buttonFind_Click(object sender, EventArgs e)
        {
            try
            {
                Frm.textBoxFind.Text = "";
                Frm.statusStrip1.Items[0].Text = "";
                textBoxFind_TextChanged(null, null);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonFind_KeyUp
        public void buttonFind_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    buttonFind_Click(sender, e);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonExit_Click
        public void buttonExit_Click(object sender, EventArgs e)
        {
            try
            {
                Frm.DialogResult = DialogResult.Cancel; 
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region buttonExit_KeyUp
        public void buttonExit_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                    buttonExit_Click(sender, e);
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region textBoxFind_TextChanged
        public void textBoxFind_TextChanged(object sender, EventArgs e)
        {
            try
            {
                frmData0035DL.BinData(" PRODUCTION_PARAMETER like '%" + Frm.textBoxFind.Text.Trim() + "%' ");
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion 

        #region dataGridView1_SelectionChanged
        public void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (Frm.dataGridView1.Rows.Count > 0)
                    Frm.statusStrip1.Items[1].Text = Frm.dataGridView1.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region dataGridView1_KeyUp
        public void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Back)
                {
                    if (Frm.statusStrip1.Items[0].Text.Trim().Length > 0)
                        Frm.statusStrip1.Items[0].Text = Frm.statusStrip1.Items[0].Text.Trim().Substring(0, Frm.statusStrip1.Items[0].Text.Trim().Length - 1);
                    else
                        Frm.statusStrip1.Items[0].Text = "";

                    frmData0035DL.BinData("PRODUCTION_PARAMETER like '%" + Frm.statusStrip1.Items[0].Text.Trim() + "%'");
                }
                else
                    if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                    {
                        Frm.statusStrip1.Items[0].Text += e.KeyCode.ToString();

                        frmData0035DL.BinData("PRODUCTION_PARAMETER like '%" + Frm.statusStrip1.Items[0].Text.Trim() + "%'");
                    }
                    else
                    {
                        if (e.KeyCode >= Keys.NumPad0 && e.KeyCode <= Keys.NumPad9)
                        {
                            Frm.statusStrip1.Items[0].Text += e.KeyCode.ToString().Substring(6, 1);

                            frmData0035DL.BinData("PRODUCTION_PARAMETER like '%" + Frm.statusStrip1.Items[0].Text.Trim() + "%'");
                        }
                        else
                            if (e.KeyCode >= Keys.D0 && e.KeyCode <= Keys.D9)
                            {
                                Frm.statusStrip1.Items[0].Text += e.KeyCode.ToString().Substring(1, 1);

                                frmData0035DL.BinData("PRODUCTION_PARAMETER like '%" + Frm.statusStrip1.Items[0].Text.Trim() + "%'");
                            }
                    }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region dataGridView1_KeyDown
        public void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                { 
                    e.Handled = true;//这样也行
                    dataGridView1_MouseDoubleClick(null, null);
                }
                else
                    if (e.KeyCode == Keys.Tab)
                    {
                        Frm.buttonExit.Focus();

                        e.Handled = true;//这样也行
                        return;
                    }
            }
            catch (Exception e1)
            {
                log.PrintInfo(e1);
                return;
            }
        }
        #endregion

        #region dataGridView1_MouseDoubleClick
        public void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                Frm.ReturnValue = Frm.dataGridView1.CurrentRow.Cells[0].Value.ToString().Trim() + "|" +
                                  Frm.dataGridView1.CurrentRow.Cells[1].Value.ToString().Trim() + "|";
                Frm.DialogResult = DialogResult.OK;
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
