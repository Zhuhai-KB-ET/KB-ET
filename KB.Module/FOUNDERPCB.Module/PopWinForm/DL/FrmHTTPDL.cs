using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using FOUNDERPCB.FUNC;
using FOUNDERPCB.DAL;
using FOUNDERPCB.Models;
using FOUNDERPCB.BLL;

namespace FOUNDERPCB.Module.PopWinForm.DL
{
    /// <summary>
    /// 数据层
    /// </summary>
    public partial class FrmHTTPDL
    {
        #region 实例化
        FrmHTTP Frm;
        public FrmHTTPDL(FrmHTTP psFrm)
        {
            Frm = psFrm; 
        }
        #endregion  
    }
}
