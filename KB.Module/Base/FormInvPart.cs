using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using KB.BLL;
using KB.Models;

namespace KB.Module.Base
{
    public partial class FormInvPart : ChildModule
    {
        List<KB.Models.DATA0017> data0017List = null;
        public KB.Models.DATA0017 inventory = null;
        public decimal Data0017Ptr = 0;

        public string where = string.Empty;
        public string orderBy = string.Empty;
        public Int32 topNum = 1000;

        System.Timers.Timer timer;
        String preStr = String.Empty;
        String currStr = String.Empty;

        public FormInvPart()
        {
            InitializeComponent();
        }

        public FormInvPart(string where, string orderBy)
        {
            InitializeComponent();
            this.where = where;
            this.orderBy = orderBy;
        }

        public FormInvPart(string where, string orderBy, Int32 topNum)
        {
            InitializeComponent();
            this.where = where;
            this.orderBy = orderBy;
            this.topNum = topNum;
        }

        protected void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                KB.BLL.DATA0017BLL data0017BLL = new KB.BLL.DATA0017BLL(db);

                string sqlWhere = string.Format(" (inv_part_number like '%{0}%' or inv_part_description like '%{0}%') ", textBox1.Text.Trim());
                if (where.Length > 0)
                {
                    sqlWhere = where + " and " + sqlWhere;
                }
                if (orderBy.Length > 0)
                {
                    sqlWhere = sqlWhere + orderBy;
                }

                data0017List = (List<KB.Models.DATA0017>)data0017BLL.FindBySql(sqlWhere, topNum);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = data0017List;
            }
            catch (Exception ex)
            {
                KB.FUNC.log.RecordInfo(ex);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                db.CloseConnection();
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && dataGridView1.CurrentCell.RowIndex >= 0)
            {
                KB.DAL.DBHelper db = new KB.DAL.DBHelper();
                try
                {
                    Data0017Ptr = decimal.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                    DATA0017BLL bll = new DATA0017BLL(db);

                    inventory = bll.getDATA0017ByRKEYWithNolock(Data0017Ptr);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    KB.FUNC.log.RecordInfo(ex);
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    db.CloseConnection();
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.ClearSelection();
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[e.ColumnIndex];
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            currStr = textBox1.Text.Trim();
        }

        private void FormInvPart_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();

            timer1.Tick += new EventHandler((object o, EventArgs ee) =>
                                            {
                                                try
                                                {
                                                    if (textBox1.Text.Trim() != preStr)
                                                    {
                                                        preStr = textBox1.Text.Trim();
                                                        BindData();
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.ToString());
                                                }
                                            });

            //下面的代码可用,实现的是另外一种计时器
            //timer = new System.Timers.Timer(500);
            //timer.Elapsed += new System.Timers.ElapsedEventHandler((object o, System.Timers.ElapsedEventArgs args) =>
            //                                                        {
            //                                                            try
            //                                                            {
            //                                                                if (currStr != preStr)
            //                                                                {
            //                                                                    if (this.InvokeRequired)
            //                                                                    {
            //                                                                        this.Invoke(new MethodInvoker(delegate() { preStr = textBox1.Text.Trim(); BindData(); }));
            //                                                                    }
            //                                                                    else
            //                                                                    {
            //                                                                        preStr = textBox1.Text.Trim();
            //                                                                        BindData();
            //                                                                    }
            //                                                                }
            //                                                            }
            //                                                            catch (Exception ex)
            //                                                            {
            //                                                                MessageBox.Show(ex.ToString());
            //                                                            }
            //                                                        });
            //timer.AutoReset = true;
            //timer.Start();
        }

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            BindData();
        }


    }
}
