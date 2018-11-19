using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KB.Module.Base
{
    public partial class FormNotePadLibrary : ChildModule
    {
        List<KB.Models.DATA0013> data0013List = null;
        public KB.Models.DATA0013 data0013 = null;

        public FormNotePadLibrary()
        {
            InitializeComponent();
        }

        private void BindData()
        {
            KB.DAL.DBHelper db = new KB.DAL.DBHelper();
            try
            {
                KB.BLL.DATA0013BLL bll = new KB.BLL.DATA0013BLL(db);
                data0013List = (List<KB.Models.DATA0013>)bll.FindBySql(" NP_CODE like '%" + textBox1.Text.Trim() + "%'");
                var list = new List<D13Item>();
                foreach (var d13 in data0013List)
                {
                    var item = new D13Item();
                    item.rkey = d13.RKEY;
                    item.NP_CODE = d13.NP_CODE;
                    item.NOTE_PAD_LINE = (string.IsNullOrEmpty(d13.NOTE_PAD_LINE_1) ? "" : d13.NOTE_PAD_LINE_1.Trim())
                                        + (string.IsNullOrEmpty(d13.NOTE_PAD_LINE_2) ? "" : d13.NOTE_PAD_LINE_2.Trim())
                                        + (string.IsNullOrEmpty(d13.NOTE_PAD_LINE_3) ? "" : d13.NOTE_PAD_LINE_3.Trim())
                                        + (string.IsNullOrEmpty(d13.NOTE_PAD_LINE_4) ? "" : d13.NOTE_PAD_LINE_4.Trim());

                    list.Add(item);
                }
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;
                for (int i = 0; i < list.Count; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = list[i].NP_CODE;
                    dataGridView1.Rows[i].Cells[1].Value = list[i].NOTE_PAD_LINE;
                }
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

        private void buttonClean_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            BindData();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentCell != null && e.RowIndex >= 0)
            {
                data0013 = data0013List[e.RowIndex];
                this.DialogResult = DialogResult.OK;
            }
        }

        private void FormNotePadLibrary_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.RowHeadersVisible = false;

            BindData();
        }
    }
    public class D13Item
    {
        public decimal rkey;
        public string NP_CODE;
        public string NOTE_PAD_LINE;
        public D13Item()
        { 
        
        }
    }
}
