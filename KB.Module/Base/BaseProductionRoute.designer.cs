namespace KB.Module.Base
{
    partial class BaseProductionRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseProductionRoute));
            this.lab_name = new System.Windows.Forms.Label();
            this.txt_SearchStr = new System.Windows.Forms.TextBox();
            this.btn_Clean = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.流程代码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.流程名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lab_name
            // 
            this.lab_name.AutoSize = true;
            this.lab_name.Location = new System.Drawing.Point(18, 17);
            this.lab_name.Name = "lab_name";
            this.lab_name.Size = new System.Drawing.Size(65, 12);
            this.lab_name.TabIndex = 0;
            this.lab_name.Text = "流程代码：";
            // 
            // txt_SearchStr
            // 
            this.txt_SearchStr.Location = new System.Drawing.Point(87, 14);
            this.txt_SearchStr.Name = "txt_SearchStr";
            this.txt_SearchStr.Size = new System.Drawing.Size(159, 21);
            this.txt_SearchStr.TabIndex = 1;
            this.txt_SearchStr.TextChanged += new System.EventHandler(this.txt_SearchStr_TextChanged);
            // 
            // btn_Clean
            // 
            this.btn_Clean.ImageKey = "Choose2.bmp";
            this.btn_Clean.ImageList = this.imageList1;
            this.btn_Clean.Location = new System.Drawing.Point(252, 14);
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
            this.流程代码,
            this.流程名称});
            this.dataGridView1.Location = new System.Drawing.Point(4, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(422, 444);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            // 
            // 流程代码
            // 
            this.流程代码.DataPropertyName = "PROD_ROUTE_CODE";
            this.流程代码.HeaderText = "流程代码";
            this.流程代码.Name = "流程代码";
            this.流程代码.ReadOnly = true;
            this.流程代码.Width = 120;
            // 
            // 流程名称
            // 
            this.流程名称.DataPropertyName = "PROD_ROUTE_CODE_NAME";
            this.流程名称.HeaderText = "流程名称";
            this.流程名称.Name = "流程名称";
            this.流程名称.ReadOnly = true;
            this.流程名称.Width = 270;
            // 
            // BaseProductionRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 488);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_Clean);
            this.Controls.Add(this.txt_SearchStr);
            this.Controls.Add(this.lab_name);
            this.MaximizeBox = false;
            this.Name = "BaseProductionRoute";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "生产流程";
            this.Load += new System.EventHandler(this.BaseProductionRoute_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab_name;
        private System.Windows.Forms.TextBox txt_SearchStr;
        private System.Windows.Forms.Button btn_Clean;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 流程代码;
        private System.Windows.Forms.DataGridViewTextBoxColumn 流程名称;
    }
}