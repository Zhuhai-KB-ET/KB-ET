using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����Approval_Mode_4Info ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Approval_Mode_4Info
	{
		public Approval_Mode_4Info()
		{}
		#region Model
		private int _rkey;
		private int? _route_step_ptr;
		private int? _user_ptr;
		/// <summary>
		/// ͨ��������4
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// ͨ��������3ָ��
		/// </summary>
		public int? ROUTE_STEP_PTR
		{
			set{ _route_step_ptr=value;}
			get{return _route_step_ptr;}
		}
		/// <summary>
		/// data0073��ָ��
		/// </summary>
		public int? USER_PTR
		{
			set{ _user_ptr=value;}
			get{return _user_ptr;}
		}
		#endregion Model

	}
}

