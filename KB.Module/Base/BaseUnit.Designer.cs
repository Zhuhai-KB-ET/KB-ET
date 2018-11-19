namespace KB.Module.Base
{
    partial class BaseUnit
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseUnit));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_code = new System.Windows.Forms.TextBox();
            this.btn_clean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.单位代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.单位名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "单位代码或名称：";
            // 
            // txt_code
            // 
            this.txt_code.Location = new System.Drawing.Point(106, 5);
            this.txt_code.Name = "txt_code";
            this.txt_code.Size = new System.Drawing.Size(136, 21);
            this.txt_code.TabIndex = 1;
            this.txt_code.TextChanged += new System.EventHandler(this.txt_code_TextChanged);
            // 
            // btn_clean
            // 
            this.btn_clean.ImageKey = "Choose2.bmp";
            this.btn_clean.ImageList = this.imageList1;
            this.btn_clean.Location = new System.Drawing.Point(248, 5);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(23, 23);
            this.btn_clean.TabIndex = 2;
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Choose2.bmp");
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.单位代码,
            this.单位名称});
            this.dataGridView1.Location = new System.Drawing.Point(2, 32);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(409, 414);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // 单位代码
            // 
            this.单位代码.DataPropertyName = "UNIT_CODE";
            this.单位代码.HeaderText = "单位代码";
            this.单位代码.Name = "单位代码";
            this.单位代码.ReadOnly = true;
            // 
            // 单位名称
            // 
            this.单位名称.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.单位名称.DataPropertyName = "UNIT_NAME";
            this.单位名称.HeaderText = "单位名称";
            this.单位名称.Name = "单位名称";
            this.单位名称.ReadOnly = true;
            // 
            // BaseUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(412, 448);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_clean);
            this.Controls.Add(this.txt_code);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "BaseUnit";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "单位";
            this.Load += new System.EventHandler(this.BaseUnit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_code;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 单位名称;
    }
}