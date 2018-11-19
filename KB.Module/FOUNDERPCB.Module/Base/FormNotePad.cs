using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormNotePad : ChildModule
    {
        public String Title = String.Empty;
        public String Notes = String.Empty;
        public FormNotePad()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void FormNotePad_Load(object sender, EventArgs e)
        {
            this.Text = Title;
            textBoxNotes.Text = Notes;
        }
    }
}
