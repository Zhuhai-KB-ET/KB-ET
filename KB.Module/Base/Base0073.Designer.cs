namespace FOUNDERPCB.Module.Base
{
    partial class Base0073
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
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RKEY73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rkey05 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.用户名 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.RKEY73,
            this.Rkey05,
            this.用户代码,
            this.用户名});
            this.dataGridView1.Location = new System.Drawing.Point(12, 31);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(370, 363);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // 编号
            // 
            this.编号.DataPropertyName = "GROUP_PTR";
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            this.编号.ReadOnly = true;
            this.编号.Width = 70;
            // 
            // RKEY73
            // 
            this.RKEY73.DataPropertyName = "RKEY";
            this.RKEY73.HeaderText = "RKEY73";
            this.RKEY73.Name = "RKEY73";
            this.RKEY73.ReadOnly = true;
            this.RKEY73.Visible = false;
            // 
            // Rkey05
            // 
            this.Rkey05.DataPropertyName = "EMPLOYEE_PTR";
            this.Rkey05.HeaderText = "Rkey05";
            this.Rkey05.Name = "Rkey05";
            this.Rkey05.ReadOnly = true;
            this.Rkey05.Visible = false;
            // 
            // 用户代码
            // 
            this.用户代码.DataPropertyName = "USER_LOGIN_NAME";
            this.用户代码.HeaderText = "用户代码";
            this.用户代码.Name = "用户代码";
            this.用户代码.ReadOnly = true;
            this.用户代码.Width = 115;
            // 
            // 用户名
            // 
            this.用户名.DataPropertyName = "USER_FULL_NAME";
            this.用户名.HeaderText = "用户名";
            this.用户名.Name = "用户名";
            this.用户名.ReadOnly = true;
            this.用户名.Width = 135;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(166, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Base0073
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 406);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Base0073";
            this.Text = "选择用户";
            this.Load += new System.EventHandler(this.Base0073_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn RKEY73;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rkey05;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 用户名;
    }
}