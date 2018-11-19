namespace FOUNDERPCB.Module.PopWinForm
{
    partial class FrmData0017_WH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmData0017_WH));
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxInv_Part_Number = new System.Windows.Forms.TextBox();
            this.labelInv_Part_Desc = new System.Windows.Forms.Label();
            this.labelInv_Unit = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxFind
            // 
            this.textBoxFind.Location = new System.Drawing.Point(256, 448);
            this.textBoxFind.Visible = false; 
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(218, 453);
            this.label11.Visible = false;
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
            this.button_Find.Location = new System.Drawing.Point(415, 444);
            this.button_Find.Visible = false; 
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(72, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 12);
            this.label2.TabIndex = 38;
            this.label2.Text = "材料名称：";
            // 
            // textBoxInv_Part_Number
            // 
            this.textBoxInv_Part_Number.Location = new System.Drawing.Point(134, 9);
            this.textBoxInv_Part_Number.Name = "textBoxInv_Part_Number";
            this.textBoxInv_Part_Number.ReadOnly = true;
            this.textBoxInv_Part_Number.Size = new System.Drawing.Size(183, 21);
            this.textBoxInv_Part_Number.TabIndex = 39;
            // 
            // labelInv_Part_Desc
            // 
            this.labelInv_Part_Desc.Location = new System.Drawing.Point(132, 33);
            this.labelInv_Part_Desc.Name = "labelInv_Part_Desc";
            this.labelInv_Part_Desc.Size = new System.Drawing.Size(323, 18);
            this.labelInv_Part_Desc.TabIndex = 40;
            // 
            // labelInv_Unit
            // 
            this.labelInv_Unit.Location = new System.Drawing.Point(323, 12);
            this.labelInv_Unit.Name = "labelInv_Unit";
            this.labelInv_Unit.Size = new System.Drawing.Size(155, 18);
            this.labelInv_Unit.TabIndex = 45;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 20);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(462, 181);
            this.dataGridView1.TabIndex = 44;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(4, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(474, 207);
            this.groupBox1.TabIndex = 47;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "仓库";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(4, 268);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(474, 214);
            this.groupBox2.TabIndex = 48;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "寄售仓";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToResizeColumns = false;
            this.dataGridView2.AllowUserToResizeRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(6, 20);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 23;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(462, 188);
            this.dataGridView2.TabIndex = 44;
            // 
            // FrmData0017_WH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(486, 507);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.labelInv_Unit);
            this.Controls.Add(this.labelInv_Part_Desc);
            this.Controls.Add(this.textBoxInv_Part_Number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmData0017_WH";
            this.Text = "库存数据概要";
            this.Load += new System.EventHandler(this.FrmData0017_WH_Load);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.textBoxInv_Part_Number, 0);
            this.Controls.SetChildIndex(this.labelInv_Part_Desc, 0);
            this.Controls.SetChildIndex(this.labelInv_Unit, 0);
            this.Controls.SetChildIndex(this.button_Find, 0);
            this.Controls.SetChildIndex(this.label11, 0);
            this.Controls.SetChildIndex(this.textBoxFind, 0);
            this.Controls.SetChildIndex(this.buttonExit, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox textBoxInv_Part_Number;
        public System.Windows.Forms.Label labelInv_Part_Desc;
        public System.Windows.Forms.Label labelInv_Unit;
        public System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.DataGridView dataGridView2;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.GroupBox groupBox2;

    }
}
