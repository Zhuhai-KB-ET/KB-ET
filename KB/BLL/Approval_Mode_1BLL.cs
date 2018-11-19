using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// ҵ���߼���Approval_Mode_1BLL ��ժҪ˵����
	/// </summary>
	public class Approval_Mode_1BLL
	{
		private Approval_Mode_1DAL dal=null;
		#region ���췽��
		public Approval_Mode_1BLL(DBHelper DB)
		{
				dal=new Approval_Mode_1DAL(DB);
		}
		public Approval_Mode_1BLL(int factoryID)
		{
				dal=new Approval_Mode_1DAL(factoryID);
		}
		#endregion
		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			return dal.Exists(RKEY);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(Approval_Mode_1Info model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_1Info model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Approval_Mode_1Info model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_1Info model)
		{
			dal.Update(cmd,conn,trans,model);
		}


		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int RKEY)
		{
			
			dal.Delete(RKEY);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,int RKEY)
		{
			
			dal.Delete(cmd,conn,trans,RKEY);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public Approval_Mode_1Info GetModel(int RKEY)
		{
			
			return dal.GetModel(RKEY);
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Approval_Mode_1Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Approval_Mode_1Info> DataTableToList(DataTable dt)
		{
			List<Approval_Mode_1Info> modelList = new List<Approval_Mode_1Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Approval_Mode_1Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Approval_Mode_1Info();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					if(dt.Rows[n]["FILE_POINTER"].ToString()!="")
					{
						model.FILE_POINTER=int.Parse(dt.Rows[n]["FILE_POINTER"].ToString());
					}
					if(dt.Rows[n]["SOURCE_TYPE"].ToString()!="")
					{
						model.SOURCE_TYPE=int.Parse(dt.Rows[n]["SOURCE_TYPE"].ToString());
					}
					if(dt.Rows[n]["FROM_STEP_NO"].ToString()!="")
					{
						model.FROM_STEP_NO=int.Parse(dt.Rows[n]["FROM_STEP_NO"].ToString());
					}
					if(dt.Rows[n]["TO_STEP_NO"].ToString()!="")
					{
						model.TO_STEP_NO=int.Parse(dt.Rows[n]["TO_STEP_NO"].ToString());
					}
					if(dt.Rows[n]["TRANS_TYPE"].ToString()!="")
					{
						model.TRANS_TYPE=int.Parse(dt.Rows[n]["TRANS_TYPE"].ToString());
					}
					model.TRANS_DESCRIPTION=dt.Rows[n]["TRANS_DESCRIPTION"].ToString();
					if(dt.Rows[n]["USER_PTR"].ToString()!="")
					{
						model.USER_PTR=int.Parse(dt.Rows[n]["USER_PTR"].ToString());
					}
					if(dt.Rows[n]["TRANS_DATE_TIME"].ToString()!="")
					{
						model.TRANS_DATE_TIME=DateTime.Parse(dt.Rows[n]["TRANS_DATE_TIME"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

