using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace KB.Module.Windows.Forms
{
    /// <summary>
    /// ��չ�� DataGridView
    /// </summary>
    public class DataGridViewEx : DataGridView
    {
        bool showRowHeaderNumbers;

        /// <summary>
        /// �Ƿ���ʾ�к�
        /// </summary>
        [Description("�Ƿ���ʾ�к�"), DefaultValue(true)]
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
                //�޸���Ͽ����ʽ
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
        /// �������뿪ʱ����Ҫ���������ֵ���뵽��Ͽ�� Items �б���
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
                //    //һ��Ҫ���������ֵ���뵽��Ͽ��ֵ�б���
                //    //������һ������Ԫ��ֵ��ʱ��ᱨ����Ϊֵ������Ͽ��ֵ�б��У�
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
