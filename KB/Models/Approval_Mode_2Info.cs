using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����Approval_Mode_2Info ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Approval_Mode_2Info
	{
		public Approval_Mode_2Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _approval_route_ptr;
		private int? _approval_status;
		private int? _approval_step_no;
		private int? _total_steps;
		/// <summary>
		/// ��������2
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
		/// �������̿�ָ��
		/// </summary>
		public int? APPROVAL_ROUTE_PTR
		{
			set{ _approval_route_ptr=value;}
			get{return _approval_route_ptr;}
		}
		/// <summary>
		/// 0δ����������1�����У�2�Ѿ�������3�ܾ�
		/// </summary>
		public int? APPROVAL_STATUS
		{
			set{ _approval_status=value;}
			get{return _approval_status;}
		}
		/// <summary>
		/// ��ǰ��������
		/// </summary>
		public int? APPROVAL_STEP_NO
		{
			set{ _approval_step_no=value;}
			get{return _approval_step_no;}
		}
		/// <summary>
		/// ����������
		/// </summary>
		public int? TOTAL_STEPS
		{
			set{ _total_steps=value;}
			get{return _total_steps;}
		}
		#endregion Model

	}
}

