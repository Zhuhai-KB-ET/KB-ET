using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����Approval_Mode_1Info ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Approval_Mode_1Info
	{
		public Approval_Mode_1Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _from_step_no;
		private int? _to_step_no;
		private int? _trans_type;
		private string _trans_description;
		private int? _user_ptr;
		private DateTime? _trans_date_time;
		/// <summary>
		/// ͨ��������1
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// ҵ��ģ���ָ��
		/// </summary>
		public int? FILE_POINTER
		{
			set{ _file_pointer=value;}
			get{return _file_pointer;}
		}
		/// <summary>
		/// ���1��Ӧ���������룬2�ֳ���˱��棬3�����������룬4��Ʒ���ñ���������5С�������ñ��棬6�ϸ�Ӧ������,7SCAR����׶Σ�8SCAR�ɹ�����׶Σ�9��������׶Σ�10����ɹ�����׶�
		/// </summary>
		public int? SOURCE_TYPE
		{
			set{ _source_type=value;}
			get{return _source_type;}
		}
		/// <summary>
		/// �ӵڼ���
		/// </summary>
		public int? FROM_STEP_NO
		{
			set{ _from_step_no=value;}
			get{return _from_step_no;}
		}
		/// <summary>
		/// ���ڼ���
		/// </summary>
		public int? TO_STEP_NO
		{
			set{ _to_step_no=value;}
			get{return _to_step_no;}
		}
		/// <summary>
		/// 1���ɣ�2����������3û����������4�������̸ı䣻5���·�����6������7�ܾ�
		/// </summary>
		public int? TRANS_TYPE
		{
			set{ _trans_type=value;}
			get{return _trans_type;}
		}
		/// <summary>
		/// ��������
		/// </summary>
		public string TRANS_DESCRIPTION
		{
			set{ _trans_description=value;}
			get{return _trans_description;}
		}
		/// <summary>
		/// ������73��ָ��
		/// </summary>
		public int? USER_PTR
		{
			set{ _user_ptr=value;}
			get{return _user_ptr;}
		}
		/// <summary>
		/// ����ʱ��
		/// </summary>
		public DateTime? TRANS_DATE_TIME
		{
			set{ _trans_date_time=value;}
			get{return _trans_date_time;}
		}
		#endregion Model

	}
}

