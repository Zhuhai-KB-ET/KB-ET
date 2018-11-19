namespace KB.Module.Base
{
    partial class BaseCustomerLocation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseCustomerLocation));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonClean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.装运地点 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.地址 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.add3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.州 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.邮编 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "装运地点：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(225, 21);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.装运地点,
            this.地址,
            this.add2,
            this.add3,
            this.州,
            this.邮编});
            this.dataGridView1.Location = new System.Drawing.Point(2, 33);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(503, 450);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDoubleClick);
            // 
            // buttonClean
            // 
            this.buttonClean.ImageKey = "Choose2.bmp";
            this.buttonClean.ImageList = this.imageList1;
            this.buttonClean.Location = new System.Drawing.Point(312, 5);
            this.buttonClean.Name = "buttonClean";
            this.buttonClean.Size = new System.Drawing.Size(24, 23);
            this.buttonClean.TabIndex = 3;
            this.buttonClean.UseVisualStyleBackColor = true;
            this.buttonClean.Click += new System.EventHandler(this.buttonClean_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Choose2.bmp");
            // 
            // 装运地点
            // 
            this.装运地点.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.装运地点.DataPropertyName = "LOCATION";
            this.装运地点.HeaderText = "装运地点";
            this.装运地点.Name = "装运地点";
            this.装运地点.ReadOnly = true;
            // 
            // 地址
            // 
            this.地址.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.地址.DataPropertyName = "SHIP_TO_ADDRESS_1 ";
            this.地址.HeaderText = "地址";
            this.地址.Name = "地址";
            this.地址.ReadOnly = true;
            // 
            // add2
            // 
            this.add2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.add2.DataPropertyName = "SHIP_TO_ADDRESS_2";
            this.add2.HeaderText = "";
            this.add2.Name = "add2";
            this.add2.ReadOnly = true;
            // 
            // add3
            // 
            this.add3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.add3.DataPropertyName = "SHIP_TO_ADDRESS_3";
            this.add3.HeaderText = "";
            this.add3.Name = "add3";
            this.add3.ReadOnly = true;
            // 
            // 州
            // 
            this.州.DataPropertyName = "STATE";
            this.州.HeaderText = "州";
            this.州.Name = "州";
            this.州.ReadOnly = true;
            this.州.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.州.Width = 40;
            // 
            // 邮编
            // 
            this.邮编.DataPropertyName = "ZIP";
            this.邮编.HeaderText = "邮编";
            this.邮编.Name = "邮编";
            this.邮编.ReadOnly = true;
            this.邮编.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.邮编.Width = 80;
            // 
            // BaseCustomerLocation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(508, 486);
            this.Controls.Add(this.buttonClean);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "BaseCustomerLocation";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "客户装运地点";
            this.Load += new System.EventHandler(this.BaseCustomerLocation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonClean;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 装运地点;
        private System.Windows.Forms.DataGridViewTextBoxColumn 地址;
        private System.Windows.Forms.DataGridViewTextBoxColumn add2;
        private System.Windows.Forms.DataGridViewTextBoxColumn add3;
        private System.Windows.Forms.DataGridViewTextBoxColumn 州;
        private System.Windows.Forms.DataGridViewTextBoxColumn 邮编;
    }
}