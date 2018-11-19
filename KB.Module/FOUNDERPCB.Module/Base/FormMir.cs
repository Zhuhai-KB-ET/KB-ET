using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FOUNDERPCB.Models;
using FOUNDERPCB.BLL;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormMir : ChildModule
    {
        public DATA0555 Data0555;

        String preStr = String.Empty;
        String currStr = String.Empty;

        public FormMir()
        {
            InitializeComponent();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBoxMirNo.Text = "";
            BindData();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.CurrentCell = dataGridView1[e.ColumnIndex, e.RowIndex];
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
                DATA0555BLL bll = new DATA0555BLL(db);

                Data0555 = bll.getDATA0555ByRKEY(decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString()));
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormMir_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();

            timer1.Tick += new EventHandler(
                (object o, EventArgs ee) =>
                {
                    try
                    {
                        if (currStr != preStr)
                        {
                            preStr = currStr;
                            BindData();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                });
        }

        private void BindData()
        {
            FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
            try
            {
                DATA0555BLL bll = new DATA0555BLL(db);
                dataGridView1.DataSource = bll.GetMirList("1", "2", textBoxMirNo.Text.Trim());
            }
            catch (Exception ex)
            {
                FOUNDERPCB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.CloseConnection();
                textBoxMirNo.Focus();
            }
        }

        private void textBoxMirNo_TextChanged(object sender, EventArgs e)
        {
            //BindData();
            currStr = textBoxMirNo.Text.Trim();
        }

        private void FormMir_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Down)
            //{
            //    if (dataGridView1.Rows.Count > 0)
            //    {
            //        if (dataGridView1.CurrentCell != null & dataGridView1.CurrentCell.RowIndex >= 0)
            //        {
            //            var index = dataGridView1.CurrentCell.RowIndex;
            //            index = Math.Min(index + 1, dataGridView1.Rows.Count - 1);

            //            dataGridView1.ClearSelection();
            //            dataGridView1.CurrentCell = dataGridView1[1, index];
            //            dataGridView1.Rows[index].Selected = true;
            //        }
            //    }
            //}
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //{
            //    if (dataGridView1.Rows.Count > 0)
            //    {
            //        if (dataGridView1.CurrentCell != null & dataGridView1.CurrentCell.RowIndex >= 0)
            //        {
            //            var index = dataGridView1.CurrentCell.RowIndex;
            //            index = Math.Max(index - 1, 0);

            //            dataGridView1.ClearSelection();
            //            dataGridView1.CurrentCell = dataGridView1[1, index];
            //            dataGridView1.Rows[index].Selected = true;
            //        }
            //    }
            //}
            if (e.KeyCode == Keys.Enter)
            {
                if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    FOUNDERPCB.DAL.DBHelper db = new FOUNDERPCB.DAL.DBHelper();
                    DATA0555BLL bll = new DATA0555BLL(db);

                    Data0555 = bll.getDATA0555ByRKEY(decimal.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void textBoxMirNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentCell != null & dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    if (e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)
                    {
                        dataGridView1.Focus();
                        int index = dataGridView1.CurrentCell.RowIndex;
                        if (e.KeyCode == Keys.Down)
                        {
                            index = Math.Min(index + 1, dataGridView1.Rows.Count - 1);
                        }
                        else if (e.KeyCode == Keys.Up)
                        {
                            index = Math.Max(index - 1, 0);
                        }
                        dataGridView1.ClearSelection();
                        dataGridView1.CurrentCell = dataGridView1[dataGridView1.CurrentCell.ColumnIndex, index];
                        dataGridView1.Rows[index].Selected = true;
                    }
                }

            }
        }

    }
}
