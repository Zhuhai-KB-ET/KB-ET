using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// ҵ���߼���RPT_MODULBLL ��ժҪ˵����
	/// </summary>
	public class RPT_MODULBLL
	{
		private RPT_MODULDAL dal=null;
		#region ���췽��
		public RPT_MODULBLL(DBHelper DB)
		{
				dal=new RPT_MODULDAL(DB);
		}
		public RPT_MODULBLL(int factoryID)
		{
				dal=new RPT_MODULDAL(factoryID);
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
		public int  Add(RPT_MODUL model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RPT_MODUL model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
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
		public RPT_MODUL GetModel(int RKEY)
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
		public List<RPT_MODUL> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RPT_MODUL> DataTableToList(DataTable dt)
		{
			List<RPT_MODUL> modelList = new List<RPT_MODUL>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RPT_MODUL model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RPT_MODUL();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					model.MODUL_NAME=dt.Rows[n]["MODUL_NAME"].ToString();
					if(dt.Rows[n]["ACTIVE_FLAG"].ToString()!="")
					{
						model.ACTIVE_FLAG=int.Parse(dt.Rows[n]["ACTIVE_FLAG"].ToString());
					}
					if(dt.Rows[n]["EMP_PTR"].ToString()!="")
					{
						model.EMP_PTR=int.Parse(dt.Rows[n]["EMP_PTR"].ToString());
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

