using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace FOUNDERPCB.Module.Windows.Forms
{
    /// <summary>
    /// 扩展的 DataGridView
    /// </summary>
    public class DataGridViewEx : DataGridView
    {
        bool showRowHeaderNumbers;

        /// <summary>
        /// 是否显示行号
        /// </summary>
        [Description("是否显示行号"), DefaultValue(true)]
        public bool ShowRowHeaderNumbers
        {
            get { return showRowHeaderNumbers; }
            set 
            {
                if (showRowHeaderNumbers != value)
                    Invalidate();
                showRowHeaderNumbers = value; 
            }
        }

        public DataGridViewEx()
        {
            showRowHeaderNumbers = true;
            RowPostPaint += new DataGridViewRowPostPaintEventHandler(DataGridViewEx_RowPostPaint);
        }
         
        protected override void OnEditingControlShowing(DataGridViewEditingControlShowingEventArgs e)
        {
            if (CurrentCell != null && CurrentCell.OwningColumn is DataGridViewComboBoxColumnEx)
            {
                DataGridViewComboBoxColumnEx col = CurrentCell.OwningColumn as DataGridViewComboBoxColumnEx;
                //修改组合框的样式
                if (col.DropDownStyle != ComboBoxStyle.DropDownList)
                {
                    ComboBox combo = e.Control as ComboBox;
                    combo.DropDownStyle = col.DropDownStyle;
                    combo.Leave += new EventHandler(combo_Leave);
                    combo.Leave += new EventHandler(AddValueCombo); 
                }
            }
            base.OnEditingControlShowing(e);
        }

        /// <summary>
        /// 当焦点离开时，需要将新输入的值加入到组合框的 Items 列表中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void combo_Leave(object sender, EventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;
                combo.Leave -= new EventHandler(combo_Leave); 

                Boolean b_find = false;
                for (int i = 0; i < combo.Items.Count; i++)
                    if (combo.Items[i].ToString() == combo.Text) b_find = true;


                if (!b_find && combo.Text.Length > 0)
                    ((DataGridViewComboBoxCell)CurrentCell).Items.Add(combo.Text);
                 

                CurrentCell.Value = combo.Text; 
                combo.Leave += new EventHandler(AddValueCombo);

                //if (CurrentCell != null && CurrentCell.OwningColumn is DataGridViewComboBoxColumnEx)
                //{
                //    DataGridViewComboBoxColumnEx col = CurrentCell.OwningColumn as DataGridViewComboBoxColumnEx;
                //    //一定要将新输入的值加入到组合框的值列表中
                //    //否则下一步给单元格赋值的时候会报错（因为值不在组合框的值列表中）
                //    //col.Items.Add(combo.Text);
                //    //CurrentCell.Value = combo.Text;
                //}
            }
            catch
            { }
        }

        void AddValueCombo(object sender, EventArgs e)
        {
            try
            {
                ComboBox combo = sender as ComboBox;
                combo.Leave -= new EventHandler(AddValueCombo);
                CurrentCell.Value = combo.Text;
            }
            catch
            { }
        }

        void DataGridViewEx_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (false && showRowHeaderNumbers)
            {
                string title = (e.RowIndex + 1).ToString();
                Brush bru = Brushes.Black;
                e.Graphics.DrawString(title, DefaultCellStyle.Font,
                    bru, e.RowBounds.Location.X + RowHeadersWidth / 2 - 4, e.RowBounds.Location.Y + 4);
            }
        }

        private void dataGridViewPara_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
