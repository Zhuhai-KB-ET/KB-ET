using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Model;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// ҵ���߼���FOUNDERPCB_ANALYSISBLL ��ժҪ˵����
	/// </summary>
	public class FOUNDERPCB_ANALYSISBLL
	{
		private FOUNDERPCB_ANALYSISDAL dal=null;
		#region ���췽��
		public FOUNDERPCB_ANALYSISBLL(DBHelper DB)
		{
				dal=new FOUNDERPCB_ANALYSISDAL(DB);
		}
		public FOUNDERPCB_ANALYSISBLL(int factoryID)
		{
				dal=new FOUNDERPCB_ANALYSISDAL(factoryID);
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
		public int  Add(FOUNDERPCB_ANALYSIS model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(FOUNDERPCB_ANALYSIS model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
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
		public FOUNDERPCB_ANALYSIS GetModel(int RKEY)
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
		public List<FOUNDERPCB_ANALYSIS> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<FOUNDERPCB_ANALYSIS> DataTableToList(DataTable dt)
		{
			List<FOUNDERPCB_ANALYSIS> modelList = new List<FOUNDERPCB_ANALYSIS>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				FOUNDERPCB_ANALYSIS model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new FOUNDERPCB_ANALYSIS();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					model.SOURCE_CODE=dt.Rows[n]["SOURCE_CODE"].ToString();
					if(dt.Rows[n]["ID_KEY"].ToString()!="")
					{
						model.ID_KEY=int.Parse(dt.Rows[n]["ID_KEY"].ToString());
					}
					model.ANS_NAME=dt.Rows[n]["ANS_NAME"].ToString();
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

