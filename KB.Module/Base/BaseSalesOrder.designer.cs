namespace KB.Module.Base
{
    partial class BaseSalesOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseSalesOrder));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SearchStr = new System.Windows.Forms.TextBox();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.销售订单号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.订单类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.客户 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.采购订单号码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.销售部件号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.版本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产部件 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产部件描述 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.生产部件版本 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "销售订单代码：";
            // 
            // txt_SearchStr
            // 
            this.txt_SearchStr.Location = new System.Drawing.Point(101, 8);
            this.txt_SearchStr.Name = "txt_SearchStr";
            this.txt_SearchStr.Size = new System.Drawing.Size(202, 21);
            this.txt_SearchStr.TabIndex = 1;
            this.txt_SearchStr.TextChanged += new System.EventHandler(this.txt_SearchStr_TextChanged);
            // 
            // btn_Clean
            // 
            this.btn_Clean.ImageKey = "Choose2.bmp";
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(309, 7);
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
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.销售订单号,
            this.订单类型,
            this.客户,
            this.采购订单号码,
            this.销售部件号,
            this.版本,
            this.状态,
            this.生产部件,
            this.生产部件描述,
            this.生产部件版本});
            this.dataGridView1.Location = new System.Drawing.Point(4, 37);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(793, 502);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // 销售订单号
            // 
            this.销售订单号.DataPropertyName = "DATA0060SALES_ORDER";
            this.销售订单号.Frozen = true;
            this.销售订单号.HeaderText = "销售订单号";
            this.销售订单号.Name = "销售订单号";
            this.销售订单号.ReadOnly = true;
            // 
            // 订单类型
            // 
            this.订单类型.DataPropertyName = "SOTypeDesc";
            this.订单类型.FillWeight = 80F;
            this.订单类型.HeaderText = "订单类型";
            this.订单类型.Name = "订单类型";
            this.订单类型.ReadOnly = true;
            this.订单类型.Width = 80;
            // 
            // 客户
            // 
            this.客户.DataPropertyName = "cust_code";
            this.客户.HeaderText = "客户";
            this.客户.Name = "客户";
            this.客户.ReadOnly = true;
            this.客户.Width = 80;
            // 
            // 采购订单号码
            // 
            this.采购订单号码.DataPropertyName = "DATA0097PO_NUMBER";
            this.采购订单号码.HeaderText = "采购订单号码";
            this.采购订单号码.Name = "采购订单号码";
            this.采购订单号码.ReadOnly = true;
            this.采购订单号码.Width = 130;
            // 
            // 销售部件号
            // 
            this.销售部件号.DataPropertyName = "DATA0050CUSTOMER_PART_NUMBER";
            this.销售部件号.HeaderText = "销售部件号";
            this.销售部件号.Name = "销售部件号";
            this.销售部件号.ReadOnly = true;
            this.销售部件号.Width = 130;
            // 
            // 版本
            // 
            this.版本.DataPropertyName = "DATA0050CP_REV";
            this.版本.HeaderText = "版本";
            this.版本.Name = "版本";
            this.版本.ReadOnly = true;
            this.版本.Width = 60;
            // 
            // 状态
            // 
            this.状态.DataPropertyName = "DATA0060STATUS";
            this.状态.HeaderText = "状态";
            this.状态.Name = "状态";
            this.状态.ReadOnly = true;
            this.状态.Width = 60;
            // 
            // 生产部件
            // 
            this.生产部件.DataPropertyName = "Production_Part_Number";
            this.生产部件.HeaderText = "生产部件";
            this.生产部件.Name = "生产部件";
            this.生产部件.ReadOnly = true;
            this.生产部件.Width = 130;
            // 
            // 生产部件描述
            // 
            this.生产部件描述.DataPropertyName = "Production_Part_DESC";
            this.生产部件描述.HeaderText = "生产部件描述";
            this.生产部件描述.Name = "生产部件描述";
            this.生产部件描述.ReadOnly = true;
            this.生产部件描述.Width = 220;
            // 
            // 生产部件版本
            // 
            this.生产部件版本.DataPropertyName = "Production_Part_REV";
            this.生产部件版本.HeaderText = "版本";
            this.生产部件版本.Name = "生产部件版本";
            this.生产部件版本.ReadOnly = true;
            this.生产部件版本.Width = 60;
            // 
            // BaseSalesOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 543);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.txt_SearchStr);
            this.Controls.Add(this.label1);
            this.Name = "BaseSalesOrder";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "销售订单查询";
            this.Load += new System.EventHandler(this.BaseSalesOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SearchStr;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销售订单号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 订单类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 客户;
        private System.Windows.Forms.DataGridViewTextBoxColumn 采购订单号码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 销售部件号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 版本;
        private System.Windows.Forms.DataGridViewTextBoxColumn 状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产部件;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产部件描述;
        private System.Windows.Forms.DataGridViewTextBoxColumn 生产部件版本;
    }
}