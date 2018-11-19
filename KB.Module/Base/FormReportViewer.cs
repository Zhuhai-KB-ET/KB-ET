using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace FOUNDERPCB.Module.Base
{
    public partial class FormReportViewer : ChildModule
    {
        /// <summary>
        /// 允许打印
        /// </summary>
        public Boolean AllowedPrint = false;
        /// <summary>
        /// 允许导出
        /// </summary>
        public Boolean AllowedExport = false;
        /// <summary>
        /// 报表路径
        /// </summary>
        public string ReportPath = string.Empty;
        /// <summary>
        /// 报表服务器路径
        /// </summary>
        public Uri ReportServerUrl;

        public FormReportViewer()
        {
            InitializeComponent();
        }

        private void FormReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote;
                reportViewer1.ShowPrintButton = AllowedPrint;
                reportViewer1.ShowExportButton = AllowedExport;
                reportViewer1.ServerReport.ReportPath = ReportPath;
                reportViewer1.ServerReport.ReportServerUrl = ReportServerUrl;

                this.reportViewer1.RefreshReport();
            }
            catch (Exception ex)
            {
                FOUNDERPCB.FUNC.log.RecordInfo(ex);
                reportViewer1.Visible = false;
                MessageBox.Show("初始化错误:" + ex.ToString());
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
