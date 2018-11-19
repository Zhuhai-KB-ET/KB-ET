using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using KB.Models;
using KB.DAL;
namespace KB.BLL
{
	/// <summary>
	/// ҵ���߼���RPT_QUICKREPORT_LINKBLL ��ժҪ˵����
	/// </summary>
	public class RPT_QUICKREPORT_LINKBLL
	{
		private RPT_QUICKREPORT_LINKDAL dal=null;
		#region ���췽��
		public RPT_QUICKREPORT_LINKBLL(DBHelper DB)
		{
				dal=new RPT_QUICKREPORT_LINKDAL(DB);
		}
		public RPT_QUICKREPORT_LINKBLL(int factoryID)
		{
				dal=new RPT_QUICKREPORT_LINKDAL(factoryID);
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
		public int  Add(RPT_QUICKREPORT_LINK model)
		{
			return dal.Add(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int  Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_QUICKREPORT_LINK model)
		{
			return dal.Add(cmd,conn,trans,model);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RPT_QUICKREPORT_LINK model)
		{
			dal.Update(model);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_QUICKREPORT_LINK model)
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
		public RPT_QUICKREPORT_LINK GetModel(int RKEY)
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
		public List<RPT_QUICKREPORT_LINK> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<RPT_QUICKREPORT_LINK> DataTableToList(DataTable dt)
		{
			List<RPT_QUICKREPORT_LINK> modelList = new List<RPT_QUICKREPORT_LINK>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				RPT_QUICKREPORT_LINK model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new RPT_QUICKREPORT_LINK();
					if(dt.Rows[n]["RKEY"].ToString()!="")
					{
						model.RKEY=int.Parse(dt.Rows[n]["RKEY"].ToString());
					}
					model.FROM_NAME=dt.Rows[n]["FROM_NAME"].ToString();
					model.REPORT_NAME=dt.Rows[n]["REPORT_NAME"].ToString();
					model.REPORT_dESC=dt.Rows[n]["REPORT_dESC"].ToString();
					if(dt.Rows[n]["REPORT_PTR"].ToString()!="")
					{
						model.REPORT_PTR=int.Parse(dt.Rows[n]["REPORT_PTR"].ToString());
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

