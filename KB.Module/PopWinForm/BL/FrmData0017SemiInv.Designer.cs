namespace KB.Module.PopWinForm
{
    partial class FrmData0017SemiInv
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmData0017SemiInv));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Size = new System.Drawing.Size(270, 21);
            this.textBoxFind.TextChanged += new System.EventHandler(this.textBoxFind_TextChanged);
            // 
            // buttonExit
            // 
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            this.buttonExit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonExit_KeyUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.Images.SetKeyName(0, "Exit.bmp");
            this.imageList1.Images.SetKeyName(1, "Choose2.bmp");
            // 
            // button_Find
            // 
            this.button_Find.Location = new System.Drawing.Point(433, 6);
            this.button_Find.Click += new System.EventHandler(this.buttonFind_Click);
            this.button_Find.KeyUp += new System.Windows.Forms.KeyEventHandler(this.buttonFind_KeyUp);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Location = new System.Drawing.Point(4, 37);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(607, 428);
            this.dataGridView1.TabIndex = 36;
            this.dataGridView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView1_MouseDoubleClick);
            this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyDown);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.dataGridView1_KeyUp);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 468);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 17);
            this.label1.TabIndex = 37;
            this.label1.Text = "注：为了提高资料的获取速度，界面只显示前300笔数据。";
            // 
            // FrmData0017SemiInv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(616, 507);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FrmData0017SemiInv";
            this.Text = "半成品/制造部件信息";
            this.Load += new System.EventHandler(this.FrmData0017SemiInv_Load);
            this.Controls.SetChildIndex(this.button_Find, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.dataGridView1, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.textBoxFind, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
    }
}
