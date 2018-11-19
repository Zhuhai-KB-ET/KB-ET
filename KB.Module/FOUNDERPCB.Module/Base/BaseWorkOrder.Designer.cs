namespace FOUNDERPCB.Module.Base
{
    partial class BaseWorkOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseWorkOrder));
            this.lab_name = new System.Windows.Forms.Label();
            this.txt_SearchStr = new System.Windows.Forms.TextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Clean = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.工单号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户部件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.版本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.库存部件号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(4, 12);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(65, 12);
            this.lab_name.TabIndex = 0;
            this.lab_name.Text = "基本工单：";
            // 
            // txt_SearchStr
            // 
            this.txt_SearchStr.Location = new System.Drawing.Point(70, 8);
            this.txt_SearchStr.Name = "txt_SearchStr";
            this.txt_SearchStr.Size = new System.Drawing.Size(209, 21);
            this.txt_SearchStr.TabIndex = 1;
            this.txt_SearchStr.TextChanged += new System.EventHandler(this.txt_SearchStr_TextChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Choose2.bmp");
            // 
            // btn_Clean
            // 
            this.btn_Clean.ImageKey = "Choose2.bmp";
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(286, 8);
            this.btn_Clean.Name = "btn_Clean";
            this.btn_Clean.Size = new System.Drawing.Size(24, 23);
            this.btn_Clean.TabIndex = 2;
            this.btn_Clean.UseVisualStyleBackColor = true;
            this.btn_Clean.Click += new System.EventHandler(this.btn_Clean_Click);
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
            this.工单号码,
            this.客户,
            this.客户部件,
            this.版本,
            this.库存部件号码});
            this.dataGridView1.Location = new System.Drawing.Point(2, 35);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(649, 484);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // 工单号码
            // 
            this.工单号码.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.工单号码.DataPropertyName = "WORK_ORDER_NUMBER";
            this.工单号码.FillWeight = 150F;
            this.工单号码.HeaderText = "工单号码";
            this.工单号码.Name = "工单号码";
            this.工单号码.ReadOnly = true;
            // 
            // 客户
            // 
            this.客户.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.客户.DataPropertyName = "CUST_CODE";
            this.客户.HeaderText = "客户";
            this.客户.Name = "客户";
            this.客户.ReadOnly = true;
            // 
            // 客户部件
            // 
            this.客户部件.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.客户部件.DataPropertyName = "CUSTOMER_PART_NUMBER";
            this.客户部件.FillWeight = 200F;
            this.客户部件.HeaderText = "客户部件";
            this.客户部件.Name = "客户部件";
            this.客户部件.ReadOnly = true;
            // 
            // 版本
            // 
            this.版本.DataPropertyName = "Data0050CP_REV";
            this.版本.HeaderText = "版本";
            this.版本.Name = "版本";
            this.版本.ReadOnly = true;
            this.版本.Width = 60;
            // 
            // 库存部件号码
            // 
            this.库存部件号码.DataPropertyName = "Data0017INV_PART_NUMBER";
            this.库存部件号码.FillWeight = 280F;
            this.库存部件号码.HeaderText = "库存部件号码";
            this.库存部件号码.Name = "库存部件号码";
            this.库存部件号码.ReadOnly = true;
            this.库存部件号码.Width = 180;
            // 
            // BaseWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(652, 523);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.txt_SearchStr);
            this.Controls.Add(this.lab_name);
            this.Name = "BaseWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "工单检索";
            this.Load += new System.EventHandler(this.BaseWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.TextBox txt_SearchStr;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 工单号码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户部件;
        private System.Windows.Forms.DataGridViewTextBoxColumn 版本;
        private System.Windows.Forms.DataGridViewTextBoxColumn 库存部件号码;
    }
}