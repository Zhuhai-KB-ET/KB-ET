using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����RPT_QUICKREPORT_LINK ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class RPT_QUICKREPORT_LINK
	{
		public RPT_QUICKREPORT_LINK()
		{}
		#region Model
		private int _rkey;
		private string _from_name;
		private string _report_name;
		private string _report_desc;
		private int _report_ptr;
		private int _emp_ptr;
		/// <summary>
		/// 
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string FROM_NAME
		{
			set{ _from_name=value;}
			get{return _from_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_NAME
		{
			set{ _report_name=value;}
			get{return _report_name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string REPORT_dESC
		{
			set{ _report_desc=value;}
			get{return _report_desc;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int REPORT_PTR
		{
			set{ _report_ptr=value;}
			get{return _report_ptr;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int EMP_PTR
		{
			set{ _emp_ptr=value;}
			get{return _emp_ptr;}
		}
		#endregion Model

	}
}

