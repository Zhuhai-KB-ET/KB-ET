using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Models;
namespace KB.DAL
{
	/// <summary>
	/// ���ݷ�����RPT_QUICKREPORT_LINKDAL��
	/// </summary>
	public partial class RPT_QUICKREPORT_LINKDAL
	{
		
		#region   �ֶ� and ����
		DBHelper dbHelper = null;
		///<sumary>
		///�ֶ� ����ָ��Ŀ�����ݿ�
		///</sumary>
		private int factoryid = 0;

		///<sumary>
		///���� ����ָ��Ŀ�����ݿ�
		///</sumary>
		public int FactoryID
		{
				get
				{
						return this.factoryid;
				}
				set
				{
						this.factoryid = value;
				}
		}
		#endregion

		#region ���췽��
		public RPT_QUICKREPORT_LINKDAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public RPT_QUICKREPORT_LINKDAL(int factoryID)
		{
				this.FactoryID = factoryID;
				this.dbHelper = new DBHelper(factoryID);
		}
		#endregion ���췽��

		#region  ��Ա����

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{
		return dbHelper.GetMaxID("RKEY", "RPT_QUICKREPORT_LINK"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RPT_QUICKREPORT_LINK with(nolock) ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			return dbHelper.Exists(strSql.ToString(),parameters);
		}


		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(RPT_QUICKREPORT_LINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_QUICKREPORT_LINK(");
			strSql.Append("FROM_NAME,REPORT_NAME,REPORT_dESC,REPORT_PTR,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@FROM_NAME,@REPORT_NAME,@REPORT_dESC,@REPORT_PTR,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FROM_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_dESC", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_PTR", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.FROM_NAME;
			parameters[1].Value = model.REPORT_NAME;
			parameters[2].Value = model.REPORT_dESC;
			parameters[3].Value = model.REPORT_PTR;
			parameters[4].Value = model.EMP_PTR;

			object obj = dbHelper.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_QUICKREPORT_LINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_QUICKREPORT_LINK(");
			strSql.Append("FROM_NAME,REPORT_NAME,REPORT_dESC,REPORT_PTR,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@FROM_NAME,@REPORT_NAME,@REPORT_dESC,@REPORT_PTR,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@FROM_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_dESC", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_PTR", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.FROM_NAME;
			parameters[1].Value = model.REPORT_NAME;
			parameters[2].Value = model.REPORT_dESC;
			parameters[3].Value = model.REPORT_PTR;
			parameters[4].Value = model.EMP_PTR;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion ����

		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RPT_QUICKREPORT_LINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_QUICKREPORT_LINK set ");
			strSql.Append("FROM_NAME=@FROM_NAME,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("REPORT_dESC=@REPORT_dESC,");
			strSql.Append("REPORT_PTR=@REPORT_PTR,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@FROM_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_dESC", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_PTR", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.FROM_NAME;
			parameters[2].Value = model.REPORT_NAME;
			parameters[3].Value = model.REPORT_dESC;
			parameters[4].Value = model.REPORT_PTR;
			parameters[5].Value = model.EMP_PTR;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_QUICKREPORT_LINK model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_QUICKREPORT_LINK set ");
			strSql.Append("FROM_NAME=@FROM_NAME,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("REPORT_dESC=@REPORT_dESC,");
			strSql.Append("REPORT_PTR=@REPORT_PTR,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@FROM_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_dESC", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_PTR", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.FROM_NAME;
			parameters[2].Value = model.REPORT_NAME;
			parameters[3].Value = model.REPORT_dESC;
			parameters[4].Value = model.REPORT_PTR;
			parameters[5].Value = model.EMP_PTR;

			dbHelper.ExecuteTranByNone(cmd,conn,trans,strSql.ToString(),parameters);
		}

		#endregion ����

		#region ɾ��
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RPT_QUICKREPORT_LINK ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from RPT_QUICKREPORT_LINK ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			dbHelper.ExecuteTranByNone(cmd,conn,trans,strSql.ToString(),parameters);
		}

		#endregion ɾ��


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public RPT_QUICKREPORT_LINK GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,FROM_NAME,REPORT_NAME,REPORT_dESC,REPORT_PTR,EMP_PTR from RPT_QUICKREPORT_LINK with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			RPT_QUICKREPORT_LINK model=new RPT_QUICKREPORT_LINK();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				model.FROM_NAME=ds.Tables[0].Rows[0]["FROM_NAME"].ToString();
				model.REPORT_NAME=ds.Tables[0].Rows[0]["REPORT_NAME"].ToString();
				model.REPORT_dESC=ds.Tables[0].Rows[0]["REPORT_dESC"].ToString();
				if(ds.Tables[0].Rows[0]["REPORT_PTR"].ToString()!="")
				{
					model.REPORT_PTR=int.Parse(ds.Tables[0].Rows[0]["REPORT_PTR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["EMP_PTR"].ToString()!="")
				{
					model.EMP_PTR=int.Parse(ds.Tables[0].Rows[0]["EMP_PTR"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select RKEY,FROM_NAME,REPORT_NAME,REPORT_dESC,REPORT_PTR,EMP_PTR ");
			strSql.Append(" FROM RPT_QUICKREPORT_LINK with(nolock)  ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbHelper.GetDataSet2(strSql.ToString());
		}

		/// <summary>
		/// ���ǰ��������
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" RKEY,FROM_NAME,REPORT_NAME,REPORT_dESC,REPORT_PTR,EMP_PTR ");
			strSql.Append(" FROM RPT_QUICKREPORT_LINK with(nolock) ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbHelper.GetDataSet2(strSql.ToString());
		}

		/*
		/// <summary>
		/// ��ҳ��ȡ�����б�
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "RPT_QUICKREPORT_LINK";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbHelper.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  ��Ա����
	}
}

