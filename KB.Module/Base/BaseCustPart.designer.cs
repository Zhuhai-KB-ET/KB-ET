namespace FOUNDERPCB.Module.Base
{
    partial class BaseCustPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseCustPart));
            this.lab_Name = new System.Windows.Forms.Label();
            this.txt_SearchStr = new System.Windows.Forms.TextBox();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.部件号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.部件描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.版本号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否激活 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(13, 13);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(65, 12);
            this.lab_Name.TabIndex = 0;
            this.lab_Name.Text = "部件号码：";
            // 
            // txt_SearchStr
            // 
            this.txt_SearchStr.Location = new System.Drawing.Point(77, 7);
            this.txt_SearchStr.Name = "txt_SearchStr";
            this.txt_SearchStr.Size = new System.Drawing.Size(241, 21);
            this.txt_SearchStr.TabIndex = 1;
            this.txt_SearchStr.TextChanged += new System.EventHandler(this.txt_SearchStr_TextChanged);
            // 
            // btn_Clean
            // 
            this.btn_Clean.ImageKey = "Choose2.bmp";
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(324, 6);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(23, 23);
            this.btn_Clean.TabIndex = 2;
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
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
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.部件号码,
            this.部件描述,
            this.版本号,
            this.是否激活});
            this.dataGridView1.Location = new System.Drawing.Point(-1, 39);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(492, 422);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // 部件号码
            // 
            this.部件号码.DataPropertyName = "CUSTOMER_PART_NUMBER";
            this.部件号码.HeaderText = "部件号码";
            this.部件号码.Name = "部件号码";
            this.部件号码.ReadOnly = true;
            this.部件号码.Width = 120;
            // 
            // 部件描述
            // 
            this.部件描述.DataPropertyName = "CUSTOMER_PART_DESC";
            this.部件描述.HeaderText = "部件描述";
            this.部件描述.Name = "部件描述";
            this.部件描述.ReadOnly = true;
            this.部件描述.Width = 240;
            // 
            // 版本号
            // 
            this.版本号.DataPropertyName = "CP_REV";
            this.版本号.HeaderText = "版本号";
            this.版本号.Name = "版本号";
            this.版本号.ReadOnly = true;
            this.版本号.Width = 70;
            // 
            // 是否激活
            // 
            this.是否激活.DataPropertyName = "ACTIVE_FLAG";
            this.是否激活.HeaderText = "是否激活";
            this.是否激活.Name = "是否激活";
            this.是否激活.ReadOnly = true;
            // 
            // BaseCustPart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 461);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.txt_SearchStr);
            this.Controls.Add(this.lab_Name);
            this.MaximizeBox = false;
            this.Name = "BaseCustPart";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产部件搜索";
            this.Load += new System.EventHandler(this.BaseCustPart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_Name;
        private System.Windows.Forms.TextBox txt_SearchStr;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部件号码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 部件描述;
        private System.Windows.Forms.DataGridViewTextBoxColumn 版本号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否激活;
    }
}