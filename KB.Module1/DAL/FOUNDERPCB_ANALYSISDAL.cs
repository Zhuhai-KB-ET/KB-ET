using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Model;
namespace KB.DAL
{
	/// <summary>
	/// ���ݷ�����FOUNDERPCB_ANALYSISDAL��
	/// </summary>
	public partial class FOUNDERPCB_ANALYSISDAL
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
		public FOUNDERPCB_ANALYSISDAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public FOUNDERPCB_ANALYSISDAL(int factoryID)
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
		return dbHelper.GetMaxID("RKEY", "FOUNDERPCB_ANALYSIS"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from FOUNDERPCB_ANALYSIS with(nolock) ");
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
		public int Add(FOUNDERPCB_ANALYSIS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FOUNDERPCB_ANALYSIS(");
			strSql.Append("SOURCE_CODE,ID_KEY,ANS_NAME)");
			strSql.Append(" values (");
			strSql.Append("@SOURCE_CODE,@ID_KEY,@ANS_NAME)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SOURCE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ID_KEY", SqlDbType.Int,4),
					new SqlParameter("@ANS_NAME", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SOURCE_CODE;
			parameters[1].Value = model.ID_KEY;
			parameters[2].Value = model.ANS_NAME;

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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into FOUNDERPCB_ANALYSIS(");
			strSql.Append("SOURCE_CODE,ID_KEY,ANS_NAME)");
			strSql.Append(" values (");
			strSql.Append("@SOURCE_CODE,@ID_KEY,@ANS_NAME)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SOURCE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ID_KEY", SqlDbType.Int,4),
					new SqlParameter("@ANS_NAME", SqlDbType.VarChar,50)};
			parameters[0].Value = model.SOURCE_CODE;
			parameters[1].Value = model.ID_KEY;
			parameters[2].Value = model.ANS_NAME;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion ����

		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(FOUNDERPCB_ANALYSIS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FOUNDERPCB_ANALYSIS set ");
			strSql.Append("SOURCE_CODE=@SOURCE_CODE,");
			strSql.Append("ID_KEY=@ID_KEY,");
			strSql.Append("ANS_NAME=@ANS_NAME");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ID_KEY", SqlDbType.Int,4),
					new SqlParameter("@ANS_NAME", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.SOURCE_CODE;
			parameters[2].Value = model.ID_KEY;
			parameters[3].Value = model.ANS_NAME;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,FOUNDERPCB_ANALYSIS model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update FOUNDERPCB_ANALYSIS set ");
			strSql.Append("SOURCE_CODE=@SOURCE_CODE,");
			strSql.Append("ID_KEY=@ID_KEY,");
			strSql.Append("ANS_NAME=@ANS_NAME");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@SOURCE_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@ID_KEY", SqlDbType.Int,4),
					new SqlParameter("@ANS_NAME", SqlDbType.VarChar,50)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.SOURCE_CODE;
			parameters[2].Value = model.ID_KEY;
			parameters[3].Value = model.ANS_NAME;

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
			strSql.Append("delete from FOUNDERPCB_ANALYSIS ");
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
			strSql.Append("delete from FOUNDERPCB_ANALYSIS ");
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
		public FOUNDERPCB_ANALYSIS GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,SOURCE_CODE,ID_KEY,ANS_NAME from FOUNDERPCB_ANALYSIS with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			FOUNDERPCB_ANALYSIS model=new FOUNDERPCB_ANALYSIS();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				model.SOURCE_CODE=ds.Tables[0].Rows[0]["SOURCE_CODE"].ToString();
				if(ds.Tables[0].Rows[0]["ID_KEY"].ToString()!="")
				{
					model.ID_KEY=int.Parse(ds.Tables[0].Rows[0]["ID_KEY"].ToString());
				}
				model.ANS_NAME=ds.Tables[0].Rows[0]["ANS_NAME"].ToString();
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
			strSql.Append("select RKEY,SOURCE_CODE,ID_KEY,ANS_NAME ");
			strSql.Append(" FROM FOUNDERPCB_ANALYSIS with(nolock)  ");
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
			strSql.Append(" RKEY,SOURCE_CODE,ID_KEY,ANS_NAME ");
			strSql.Append(" FROM FOUNDERPCB_ANALYSIS with(nolock) ");
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
			parameters[0].Value = "FOUNDERPCB_ANALYSIS";
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

