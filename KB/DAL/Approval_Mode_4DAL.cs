using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Models;
namespace KB.DAL
{
	/// <summary>
	/// ���ݷ�����Approval_Mode_4DAL��
	/// </summary>
	public partial class Approval_Mode_4DAL
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
		public Approval_Mode_4DAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public Approval_Mode_4DAL(int factoryID)
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
		return dbHelper.GetMaxID("RKEY", "Approval_Mode_4"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Approval_Mode_4 with(nolock) ");
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
		public int Add(Approval_Mode_4Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Approval_Mode_4(");
			strSql.Append("ROUTE_STEP_PTR,USER_PTR)");
			strSql.Append(" values (");
			strSql.Append("@ROUTE_STEP_PTR,@USER_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ROUTE_STEP_PTR", SqlDbType.Int,4),
					new SqlParameter("@USER_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.ROUTE_STEP_PTR;
			parameters[1].Value = model.USER_PTR;

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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_4Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Approval_Mode_4(");
			strSql.Append("ROUTE_STEP_PTR,USER_PTR)");
			strSql.Append(" values (");
			strSql.Append("@ROUTE_STEP_PTR,@USER_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ROUTE_STEP_PTR", SqlDbType.Int,4),
					new SqlParameter("@USER_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.ROUTE_STEP_PTR;
			parameters[1].Value = model.USER_PTR;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion ����

		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(Approval_Mode_4Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Approval_Mode_4 set ");
			strSql.Append("ROUTE_STEP_PTR=@ROUTE_STEP_PTR,");
			strSql.Append("USER_PTR=@USER_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@ROUTE_STEP_PTR", SqlDbType.Int,4),
					new SqlParameter("@USER_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.ROUTE_STEP_PTR;
			parameters[2].Value = model.USER_PTR;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,Approval_Mode_4Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Approval_Mode_4 set ");
			strSql.Append("ROUTE_STEP_PTR=@ROUTE_STEP_PTR,");
			strSql.Append("USER_PTR=@USER_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@ROUTE_STEP_PTR", SqlDbType.Int,4),
					new SqlParameter("@USER_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.ROUTE_STEP_PTR;
			parameters[2].Value = model.USER_PTR;

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
			strSql.Append("delete from Approval_Mode_4 ");
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
			strSql.Append("delete from Approval_Mode_4 ");
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
		public Approval_Mode_4Info GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,ROUTE_STEP_PTR,USER_PTR from Approval_Mode_4 with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			Approval_Mode_4Info model=new Approval_Mode_4Info();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ROUTE_STEP_PTR"].ToString()!="")
				{
					model.ROUTE_STEP_PTR=int.Parse(ds.Tables[0].Rows[0]["ROUTE_STEP_PTR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["USER_PTR"].ToString()!="")
				{
					model.USER_PTR=int.Parse(ds.Tables[0].Rows[0]["USER_PTR"].ToString());
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
			strSql.Append("select RKEY,ROUTE_STEP_PTR,USER_PTR ");
			strSql.Append(" FROM Approval_Mode_4 with(nolock)  ");
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
			strSql.Append(" RKEY,ROUTE_STEP_PTR,USER_PTR ");
			strSql.Append(" FROM Approval_Mode_4 with(nolock) ");
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
			parameters[0].Value = "Approval_Mode_4";
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

