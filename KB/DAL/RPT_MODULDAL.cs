using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Models;
namespace KB.DAL
{
	/// <summary>
	/// ���ݷ�����RPT_MODULDAL��
	/// </summary>
	public partial class RPT_MODULDAL
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
		public RPT_MODULDAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public RPT_MODULDAL(int factoryID)
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
		return dbHelper.GetMaxID("RKEY", "RPT_MODUL"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RPT_MODUL with(nolock) ");
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
		public int Add(RPT_MODUL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_MODUL(");
			strSql.Append("MODUL_NAME,ACTIVE_FLAG,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@MODUL_NAME,@ACTIVE_FLAG,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MODUL_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.MODUL_NAME;
			parameters[1].Value = model.ACTIVE_FLAG;
			parameters[2].Value = model.EMP_PTR;

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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_MODUL(");
			strSql.Append("MODUL_NAME,ACTIVE_FLAG,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@MODUL_NAME,@ACTIVE_FLAG,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@MODUL_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.MODUL_NAME;
			parameters[1].Value = model.ACTIVE_FLAG;
			parameters[2].Value = model.EMP_PTR;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion ����

		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RPT_MODUL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_MODUL set ");
			strSql.Append("MODUL_NAME=@MODUL_NAME,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@MODUL_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.MODUL_NAME;
			parameters[2].Value = model.ACTIVE_FLAG;
			parameters[3].Value = model.EMP_PTR;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_MODUL model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_MODUL set ");
			strSql.Append("MODUL_NAME=@MODUL_NAME,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@MODUL_NAME", SqlDbType.VarChar,50),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.MODUL_NAME;
			parameters[2].Value = model.ACTIVE_FLAG;
			parameters[3].Value = model.EMP_PTR;

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
			strSql.Append("delete from RPT_MODUL ");
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
			strSql.Append("delete from RPT_MODUL ");
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
		public RPT_MODUL GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,MODUL_NAME,ACTIVE_FLAG,EMP_PTR from RPT_MODUL with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			RPT_MODUL model=new RPT_MODUL();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				model.MODUL_NAME=ds.Tables[0].Rows[0]["MODUL_NAME"].ToString();
				if(ds.Tables[0].Rows[0]["ACTIVE_FLAG"].ToString()!="")
				{
					model.ACTIVE_FLAG=int.Parse(ds.Tables[0].Rows[0]["ACTIVE_FLAG"].ToString());
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
			strSql.Append("select RKEY,MODUL_NAME,ACTIVE_FLAG,EMP_PTR ");
			strSql.Append(" FROM RPT_MODUL with(nolock)  ");
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
			strSql.Append(" RKEY,MODUL_NAME,ACTIVE_FLAG,EMP_PTR ");
			strSql.Append(" FROM RPT_MODUL with(nolock) ");
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
			parameters[0].Value = "RPT_MODUL";
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
