namespace KB.Module.Base
{
    partial class BaseCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseCustomer));
            this.lab_Name = new System.Windows.Forms.Label();
            this.txt_SearchStr = new System.Windows.Forms.TextBox();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.客户代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_Name
            // 
            this.lab_Name.AutoSize = true;
            this.lab_Name.Location = new System.Drawing.Point(12, 12);
            this.lab_Name.Name = "lab_Name";
            this.lab_Name.Size = new System.Drawing.Size(65, 12);
            this.lab_Name.TabIndex = 0;
            this.lab_Name.Text = "客户代码：";
            // 
            // txt_SearchStr
            // 
            this.txt_SearchStr.Location = new System.Drawing.Point(81, 8);
            this.txt_SearchStr.Name = "txt_SearchStr";
            this.txt_SearchStr.Size = new System.Drawing.Size(199, 21);
            this.txt_SearchStr.TabIndex = 1;
            this.txt_SearchStr.TextChanged += new System.EventHandler(this.txt_SearchStr_TextChanged);
            // 
            // btn_Clean
            // 
            this.btn_Clean.ImageKey = "Choose2.bmp";
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(286, 7);
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
            this.客户代码,
            this.客户名称});
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(412, 456);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // 客户代码
            // 
            this.客户代码.DataPropertyName = "CUST_CODE";
            this.客户代码.HeaderText = "客户代码";
            this.客户代码.Name = "客户代码";
            this.客户代码.ReadOnly = true;
            // 
            // 客户名称
            // 
            this.客户名称.DataPropertyName = "CUSTOMER_NAME";
            this.客户名称.HeaderText = "客户名称";
            this.客户名称.Name = "客户名称";
            this.客户名称.ReadOnly = true;
            this.客户名称.Width = 280;
            // 
            // BaseCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 492);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.txt_SearchStr);
            this.Controls.Add(this.lab_Name);
            this.MaximizeBox = false;
            this.Name = "BaseCustomer";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户搜索";
            this.Load += new System.EventHandler(this.BaseCustomer_Load);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户名称;
    }
}