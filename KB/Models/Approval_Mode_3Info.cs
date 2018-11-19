using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����Approval_Mode_3Info ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Approval_Mode_3Info
	{
		public Approval_Mode_3Info()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private int? _approval_step_no;
		private string _approval_step_desc;
		/// <summary>
		/// ͨ��������3
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
		/// ��������
		/// </summary>
		public int? APPROVAL_STEP_NO
		{
			set{ _approval_step_no=value;}
			get{return _approval_step_no;}
		}
		/// <summary>
		/// ��������˵��
		/// </summary>
		public string APPROVAL_STEP_DESC
		{
			set{ _approval_step_desc=value;}
			get{return _approval_step_desc;}
		}
		#endregion Model

	}
}

