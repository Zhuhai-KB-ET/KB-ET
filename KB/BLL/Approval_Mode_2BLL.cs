using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// ҵ���߼���Approval_Mode_2BLL ��ժҪ˵����
	/// </summary>
	public class Approval_Mode_2BLL
	{
		private Approval_Mode_2DAL dal=null;
		#region ���췽��
		public Approval_Mode_2BLL(DBHelper DB)
		{
				dal=new Approval_Mode_2DAL(DB);
		}
		public Approval_Mode_2BLL(int factoryID)
		{
				dal=new Approval_Mode_2DAL(factoryID);
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
		public int  Add(Approval_Mode_2Info model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_2Info model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Approval_Mode_2Info model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_2Info model)
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
		public Approval_Mode_2Info GetModel(int RKEY)
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
		public List<Approval_Mode_2Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<Approval_Mode_2Info> DataTableToList(DataTable dt)
		{
			List<Approval_Mode_2Info> modelList = new List<Approval_Mode_2Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Approval_Mode_2Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Approval_Mode_2Info();
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
					if(dt.Rows[n]["APPROVAL_ROUTE_PTR"].ToString()!="")
					{
						model.APPROVAL_ROUTE_PTR=int.Parse(dt.Rows[n]["APPROVAL_ROUTE_PTR"].ToString());
					}
					if(dt.Rows[n]["APPROVAL_STATUS"].ToString()!="")
					{
						model.APPROVAL_STATUS=int.Parse(dt.Rows[n]["APPROVAL_STATUS"].ToString());
					}
					if(dt.Rows[n]["APPROVAL_STEP_NO"].ToString()!="")
					{
						model.APPROVAL_STEP_NO=int.Parse(dt.Rows[n]["APPROVAL_STEP_NO"].ToString());
					}
					if(dt.Rows[n]["TOTAL_STEPS"].ToString()!="")
					{
						model.TOTAL_STEPS=int.Parse(dt.Rows[n]["TOTAL_STEPS"].ToString());
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

