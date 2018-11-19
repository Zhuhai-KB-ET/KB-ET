namespace FOUNDERPCB.Module.Base
{
    partial class FormRouteStep
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.d34RKEY = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.制程 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部门代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部门名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.权重 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.多重单位 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.工序暂缓 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.d34RKEY,
            this.制程,
            this.部门代码,
            this.部门名称,
            this.权重,
            this.多重单位,
            this.工序暂缓});
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(578, 408);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // d34RKEY
            // 
            this.d34RKEY.DataPropertyName = "DEPT_PTR";
            this.d34RKEY.HeaderText = "d34RKEY";
            this.d34RKEY.Name = "d34RKEY";
            this.d34RKEY.ReadOnly = true;
            this.d34RKEY.Visible = false;
            // 
            // 制程
            // 
            this.制程.DataPropertyName = "STEP_NUMBER";
            this.制程.HeaderText = "制程";
            this.制程.MinimumWidth = 40;
            this.制程.Name = "制程";
            this.制程.ReadOnly = true;
            this.制程.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.制程.Width = 40;
            // 
            // 部门代码
            // 
            this.部门代码.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.部门代码.DataPropertyName = "DEPT_CODE";
            this.部门代码.FillWeight = 130F;
            this.部门代码.HeaderText = "部门代码";
            this.部门代码.MinimumWidth = 100;
            this.部门代码.Name = "部门代码";
            this.部门代码.ReadOnly = true;
            // 
            // 部门名称
            // 
            this.部门名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.部门名称.DataPropertyName = "DEPT_NAME";
            this.部门名称.FillWeight = 130F;
            this.部门名称.HeaderText = "部门名称";
            this.部门名称.MinimumWidth = 100;
            this.部门名称.Name = "部门名称";
            this.部门名称.ReadOnly = true;
            // 
            // 权重
            // 
            this.权重.DataPropertyName = "PERCENTS";
            this.权重.HeaderText = "权重";
            this.权重.MinimumWidth = 80;
            this.权重.Name = "权重";
            this.权重.ReadOnly = true;
            this.权重.Width = 80;
            // 
            // 多重单位
            // 
            this.多重单位.DataPropertyName = "UNIT_FLAG";
            this.多重单位.HeaderText = "多重单位";
            this.多重单位.MinimumWidth = 80;
            this.多重单位.Name = "多重单位";
            this.多重单位.ReadOnly = true;
            this.多重单位.Width = 80;
            // 
            // 工序暂缓
            // 
            this.工序暂缓.DataPropertyName = "STEP_HOLD";
            this.工序暂缓.HeaderText = "工序暂缓";
            this.工序暂缓.MinimumWidth = 80;
            this.工序暂缓.Name = "工序暂缓";
            this.工序暂缓.ReadOnly = true;
            this.工序暂缓.Width = 80;
            // 
            // FormRouteStep
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 432);
            this.Controls.Add(this.dataGridView1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormRouteStep";
            this.Text = "选择流程信息";
            this.Load += new System.EventHandler(this.FormRouteStep_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn d34RKEY;
        private System.Windows.Forms.DataGridViewTextBoxColumn 制程;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部门代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部门名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 权重;
        private System.Windows.Forms.DataGridViewTextBoxColumn 多重单位;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工序暂缓;
    }
}