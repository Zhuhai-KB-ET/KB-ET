using System;
namespace KB.Models
{
	/// <summary>
	/// ʵ����Approval_Mode_NoteInfo ��(����˵���Զ���ȡ���ݿ��ֶε�������Ϣ)
	/// </summary>
	[Serializable]
	public class Approval_Mode_NoteInfo
	{
		public Approval_Mode_NoteInfo()
		{}
		#region Model
		private int _rkey;
		private int? _file_pointer;
		private int? _source_type;
		private string _notes;
		/// <summary>
		/// 
		/// </summary>
		public int RKEY
		{
			set{ _rkey=value;}
			get{return _rkey;}
		}
		/// <summary>
		/// ���ָ��
		/// </summary>
		public int? FILE_POINTER
		{
			set{ _file_pointer=value;}
			get{return _file_pointer;}
		}
		/// <summary>
		/// ���ͣ�1��Approval_Mode_1
		/// </summary>
		public int? SOURCE_TYPE
		{
			set{ _source_type=value;}
			get{return _source_type;}
		}
		/// <summary>
		/// ���±�
		/// </summary>
		public string NOTES
		{
			set{ _notes=value;}
			get{return _notes;}
		}
		#endregion Model

	}
}

