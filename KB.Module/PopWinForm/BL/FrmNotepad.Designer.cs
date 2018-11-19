namespace FOUNDERPCB.Module.PopWinForm
{
    partial class FrmNotepad
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotepad));
            this.buttonFind = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.textBox = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonFind
            // 
            this.buttonFind.AccessibleDescription = "";
            this.buttonFind.AccessibleName = "";
            this.buttonFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFind.ImageKey = "Choose.bmp";
            this.buttonFind.ImageList = this.imageList1;
            this.buttonFind.Location = new System.Drawing.Point(6, 7);
            this.buttonFind.Name = "buttonFind";
            this.buttonFind.Size = new System.Drawing.Size(26, 26);
            this.buttonFind.TabIndex = 4;
            this.buttonFind.UseVisualStyleBackColor = true;
            this.buttonFind.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonFind_MouseClick);
            this.buttonFind.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonFind_KeyDown);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Save.bmp");
            this.imageList1.Images.SetKeyName(1, "Choose2.bmp");
            this.imageList1.Images.SetKeyName(2, "Choose.bmp");
            this.imageList1.Images.SetKeyName(3, "Computer.bmp");
            this.imageList1.Images.SetKeyName(4, "Exit.bmp");
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(6, 41);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(557, 120);
            this.textBox.TabIndex = 5;
            this.textBox.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_KeyUp);
            // 
            // buttonOK
            // 
            this.buttonOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonOK.Location = new System.Drawing.Point(203, 173);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 6;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonOK_MouseClick);
            this.buttonOK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonOK_KeyDown);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(295, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.buttonCancel_MouseClick);
            this.buttonCancel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.buttonCancel_KeyDown);
            // 
            // FrmNotepad
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(571, 208);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmNotepad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "";
            this.Load += new System.EventHandler(this.FrmNotepad_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button buttonFind;
        public System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TextBox textBox;
        public System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.Button buttonCancel;
    }
}
