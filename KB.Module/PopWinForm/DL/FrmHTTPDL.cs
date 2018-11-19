﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing; 
using System.Windows.Forms;
using KB.FUNC;
using KB.DAL;
using KB.Models;
using KB.BLL;

namespace KB.Module.PopWinForm.DL
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
