using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.PopWinForm
{
    public partial class FrmDate : FOUNDERPCB.Module.ChildModule
    {
        #region FrmDate
        IL.FrmDateIL frmDateIL = null; 
        public FrmDate()
        {
            InitializeComponent();
        }
        #endregion

        #region FrmDate_Load
        private void FrmDate_Load(object sender, EventArgs e)
        {
            frmDateIL = new FOUNDERPCB.Module.PopWinForm.IL.FrmDateIL(this);

            frmDateIL.FrmDate_Load(sender, e);
        }
        #endregion

        #region buttonCancel
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            frmDateIL.buttonCancel_Click(sender, e);
        }
        private void buttonCancel_KeyDown(object sender, KeyEventArgs e)
        {
            frmDateIL.buttonCancel_KeyDown(sender, e);
        }
        #endregion

        #region buttonOK
        private void buttonOK_Click(object sender, EventArgs e)
        {
            frmDateIL.buttonOK_Click(sender, e);
        }
        private void buttonOK_KeyDown(object sender, KeyEventArgs e)
        {
            frmDateIL.buttonOK_KeyDown(sender, e);
        } 
        #endregion 
    }
}
