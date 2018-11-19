using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using KB.Models;
namespace KB.DAL
{
	/// <summary>
	/// ���ݷ�����RPT_SETPARMDAL��
	/// </summary>
	public partial class RPT_SETPARMDAL
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
		public RPT_SETPARMDAL(DBHelper DB)
		{
				this.FactoryID =  DB.FactoryID;
				this.dbHelper = DB;
		}
		public RPT_SETPARMDAL(int factoryID)
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
		return dbHelper.GetMaxID("RKEY", "RPT_SETPARM"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(int RKEY)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from RPT_SETPARM with(nolock) ");
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
		public int Add(RPT_SETPARM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_SETPARM(");
			strSql.Append("SERVER_PTR,MODUL_PTR,TTYPE,REPORT_PATH,REPORT_NAME,DISPLAY_NAME,REPORT_CODE,REPORT_PARM,QUICK_PRINT,CHOOSE_PAYE,MARGINS_TOP,MARGINS_BUTTOM,MARGINS_LEFT,MARGINS_RIGHT,ACTIVE_FLAG,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@SERVER_PTR,@MODUL_PTR,@TTYPE,@REPORT_PATH,@REPORT_NAME,@DISPLAY_NAME,@REPORT_CODE,@REPORT_PARM,@QUICK_PRINT,@CHOOSE_PAYE,@MARGINS_TOP,@MARGINS_BUTTOM,@MARGINS_LEFT,@MARGINS_RIGHT,@ACTIVE_FLAG,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SERVER_PTR", SqlDbType.Int,4),
					new SqlParameter("@MODUL_PTR", SqlDbType.Int,4),
					new SqlParameter("@TTYPE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PATH", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@DISPLAY_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@REPORT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PARM", SqlDbType.VarChar,100),
					new SqlParameter("@QUICK_PRINT", SqlDbType.Int,4),
					new SqlParameter("@CHOOSE_PAYE", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_TOP", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_BUTTOM", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_LEFT", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_RIGHT", SqlDbType.Int,4),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.SERVER_PTR;
			parameters[1].Value = model.MODUL_PTR;
			parameters[2].Value = model.TTYPE;
			parameters[3].Value = model.REPORT_PATH;
			parameters[4].Value = model.REPORT_NAME;
			parameters[5].Value = model.DISPLAY_NAME;
			parameters[6].Value = model.REPORT_CODE;
			parameters[7].Value = model.REPORT_PARM;
			parameters[8].Value = model.QUICK_PRINT;
			parameters[9].Value = model.CHOOSE_PAYE;
			parameters[10].Value = model.MARGINS_TOP;
			parameters[11].Value = model.MARGINS_BUTTOM;
			parameters[12].Value = model.MARGINS_LEFT;
			parameters[13].Value = model.MARGINS_RIGHT;
			parameters[14].Value = model.ACTIVE_FLAG;
			parameters[15].Value = model.EMP_PTR;

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
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_SETPARM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into RPT_SETPARM(");
			strSql.Append("SERVER_PTR,MODUL_PTR,TTYPE,REPORT_PATH,REPORT_NAME,DISPLAY_NAME,REPORT_CODE,REPORT_PARM,QUICK_PRINT,CHOOSE_PAYE,MARGINS_TOP,MARGINS_BUTTOM,MARGINS_LEFT,MARGINS_RIGHT,ACTIVE_FLAG,EMP_PTR)");
			strSql.Append(" values (");
			strSql.Append("@SERVER_PTR,@MODUL_PTR,@TTYPE,@REPORT_PATH,@REPORT_NAME,@DISPLAY_NAME,@REPORT_CODE,@REPORT_PARM,@QUICK_PRINT,@CHOOSE_PAYE,@MARGINS_TOP,@MARGINS_BUTTOM,@MARGINS_LEFT,@MARGINS_RIGHT,@ACTIVE_FLAG,@EMP_PTR)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@SERVER_PTR", SqlDbType.Int,4),
					new SqlParameter("@MODUL_PTR", SqlDbType.Int,4),
					new SqlParameter("@TTYPE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PATH", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@DISPLAY_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@REPORT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PARM", SqlDbType.VarChar,100),
					new SqlParameter("@QUICK_PRINT", SqlDbType.Int,4),
					new SqlParameter("@CHOOSE_PAYE", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_TOP", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_BUTTOM", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_LEFT", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_RIGHT", SqlDbType.Int,4),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.SERVER_PTR;
			parameters[1].Value = model.MODUL_PTR;
			parameters[2].Value = model.TTYPE;
			parameters[3].Value = model.REPORT_PATH;
			parameters[4].Value = model.REPORT_NAME;
			parameters[5].Value = model.DISPLAY_NAME;
			parameters[6].Value = model.REPORT_CODE;
			parameters[7].Value = model.REPORT_PARM;
			parameters[8].Value = model.QUICK_PRINT;
			parameters[9].Value = model.CHOOSE_PAYE;
			parameters[10].Value = model.MARGINS_TOP;
			parameters[11].Value = model.MARGINS_BUTTOM;
			parameters[12].Value = model.MARGINS_LEFT;
			parameters[13].Value = model.MARGINS_RIGHT;
			parameters[14].Value = model.ACTIVE_FLAG;
			parameters[15].Value = model.EMP_PTR;

			return dbHelper.ExecuteTranByID(cmd,conn,trans,strSql.ToString(),parameters);
		}
		#endregion ����

		#region ����
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(RPT_SETPARM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_SETPARM set ");
			strSql.Append("SERVER_PTR=@SERVER_PTR,");
			strSql.Append("MODUL_PTR=@MODUL_PTR,");
			strSql.Append("TTYPE=@TTYPE,");
			strSql.Append("REPORT_PATH=@REPORT_PATH,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("DISPLAY_NAME=@DISPLAY_NAME,");
			strSql.Append("REPORT_CODE=@REPORT_CODE,");
			strSql.Append("REPORT_PARM=@REPORT_PARM,");
			strSql.Append("QUICK_PRINT=@QUICK_PRINT,");
			strSql.Append("CHOOSE_PAYE=@CHOOSE_PAYE,");
			strSql.Append("MARGINS_TOP=@MARGINS_TOP,");
			strSql.Append("MARGINS_BUTTOM=@MARGINS_BUTTOM,");
			strSql.Append("MARGINS_LEFT=@MARGINS_LEFT,");
			strSql.Append("MARGINS_RIGHT=@MARGINS_RIGHT,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@SERVER_PTR", SqlDbType.Int,4),
					new SqlParameter("@MODUL_PTR", SqlDbType.Int,4),
					new SqlParameter("@TTYPE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PATH", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@DISPLAY_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@REPORT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PARM", SqlDbType.VarChar,100),
					new SqlParameter("@QUICK_PRINT", SqlDbType.Int,4),
					new SqlParameter("@CHOOSE_PAYE", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_TOP", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_BUTTOM", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_LEFT", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_RIGHT", SqlDbType.Int,4),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.SERVER_PTR;
			parameters[2].Value = model.MODUL_PTR;
			parameters[3].Value = model.TTYPE;
			parameters[4].Value = model.REPORT_PATH;
			parameters[5].Value = model.REPORT_NAME;
			parameters[6].Value = model.DISPLAY_NAME;
			parameters[7].Value = model.REPORT_CODE;
			parameters[8].Value = model.REPORT_PARM;
			parameters[9].Value = model.QUICK_PRINT;
			parameters[10].Value = model.CHOOSE_PAYE;
			parameters[11].Value = model.MARGINS_TOP;
			parameters[12].Value = model.MARGINS_BUTTOM;
			parameters[13].Value = model.MARGINS_LEFT;
			parameters[14].Value = model.MARGINS_RIGHT;
			parameters[15].Value = model.ACTIVE_FLAG;
			parameters[16].Value = model.EMP_PTR;

			dbHelper.ExecuteNonQuery(strSql.ToString(),parameters);
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans,RPT_SETPARM model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update RPT_SETPARM set ");
			strSql.Append("SERVER_PTR=@SERVER_PTR,");
			strSql.Append("MODUL_PTR=@MODUL_PTR,");
			strSql.Append("TTYPE=@TTYPE,");
			strSql.Append("REPORT_PATH=@REPORT_PATH,");
			strSql.Append("REPORT_NAME=@REPORT_NAME,");
			strSql.Append("DISPLAY_NAME=@DISPLAY_NAME,");
			strSql.Append("REPORT_CODE=@REPORT_CODE,");
			strSql.Append("REPORT_PARM=@REPORT_PARM,");
			strSql.Append("QUICK_PRINT=@QUICK_PRINT,");
			strSql.Append("CHOOSE_PAYE=@CHOOSE_PAYE,");
			strSql.Append("MARGINS_TOP=@MARGINS_TOP,");
			strSql.Append("MARGINS_BUTTOM=@MARGINS_BUTTOM,");
			strSql.Append("MARGINS_LEFT=@MARGINS_LEFT,");
			strSql.Append("MARGINS_RIGHT=@MARGINS_RIGHT,");
			strSql.Append("ACTIVE_FLAG=@ACTIVE_FLAG,");
			strSql.Append("EMP_PTR=@EMP_PTR");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4),
					new SqlParameter("@SERVER_PTR", SqlDbType.Int,4),
					new SqlParameter("@MODUL_PTR", SqlDbType.Int,4),
					new SqlParameter("@TTYPE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PATH", SqlDbType.VarChar,200),
					new SqlParameter("@REPORT_NAME", SqlDbType.VarChar,200),
					new SqlParameter("@DISPLAY_NAME", SqlDbType.VarChar,100),
					new SqlParameter("@REPORT_CODE", SqlDbType.VarChar,20),
					new SqlParameter("@REPORT_PARM", SqlDbType.VarChar,100),
					new SqlParameter("@QUICK_PRINT", SqlDbType.Int,4),
					new SqlParameter("@CHOOSE_PAYE", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_TOP", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_BUTTOM", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_LEFT", SqlDbType.Int,4),
					new SqlParameter("@MARGINS_RIGHT", SqlDbType.Int,4),
					new SqlParameter("@ACTIVE_FLAG", SqlDbType.Int,4),
					new SqlParameter("@EMP_PTR", SqlDbType.Int,4)};
			parameters[0].Value = model.RKEY;
			parameters[1].Value = model.SERVER_PTR;
			parameters[2].Value = model.MODUL_PTR;
			parameters[3].Value = model.TTYPE;
			parameters[4].Value = model.REPORT_PATH;
			parameters[5].Value = model.REPORT_NAME;
			parameters[6].Value = model.DISPLAY_NAME;
			parameters[7].Value = model.REPORT_CODE;
			parameters[8].Value = model.REPORT_PARM;
			parameters[9].Value = model.QUICK_PRINT;
			parameters[10].Value = model.CHOOSE_PAYE;
			parameters[11].Value = model.MARGINS_TOP;
			parameters[12].Value = model.MARGINS_BUTTOM;
			parameters[13].Value = model.MARGINS_LEFT;
			parameters[14].Value = model.MARGINS_RIGHT;
			parameters[15].Value = model.ACTIVE_FLAG;
			parameters[16].Value = model.EMP_PTR;

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
			strSql.Append("delete from RPT_SETPARM ");
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
			strSql.Append("delete from RPT_SETPARM ");
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
		public RPT_SETPARM GetModel(int RKEY)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 RKEY,SERVER_PTR,MODUL_PTR,TTYPE,REPORT_PATH,REPORT_NAME,DISPLAY_NAME,REPORT_CODE,REPORT_PARM,QUICK_PRINT,CHOOSE_PAYE,MARGINS_TOP,MARGINS_BUTTOM,MARGINS_LEFT,MARGINS_RIGHT,ACTIVE_FLAG,EMP_PTR from RPT_SETPARM with(nolock)  ");
			strSql.Append(" where RKEY=@RKEY ");
			SqlParameter[] parameters = {
					new SqlParameter("@RKEY", SqlDbType.Int,4)};
			parameters[0].Value = RKEY;

			RPT_SETPARM model=new RPT_SETPARM();
			DataSet ds=dbHelper.GetDataSet2(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["RKEY"].ToString()!="")
				{
					model.RKEY=int.Parse(ds.Tables[0].Rows[0]["RKEY"].ToString());
				}
				if(ds.Tables[0].Rows[0]["SERVER_PTR"].ToString()!="")
				{
					model.SERVER_PTR=int.Parse(ds.Tables[0].Rows[0]["SERVER_PTR"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MODUL_PTR"].ToString()!="")
				{
					model.MODUL_PTR=int.Parse(ds.Tables[0].Rows[0]["MODUL_PTR"].ToString());
				}
				model.TTYPE=ds.Tables[0].Rows[0]["TTYPE"].ToString();
				model.REPORT_PATH=ds.Tables[0].Rows[0]["REPORT_PATH"].ToString();
				model.REPORT_NAME=ds.Tables[0].Rows[0]["REPORT_NAME"].ToString();
				model.DISPLAY_NAME=ds.Tables[0].Rows[0]["DISPLAY_NAME"].ToString();
				model.REPORT_CODE=ds.Tables[0].Rows[0]["REPORT_CODE"].ToString();
				model.REPORT_PARM=ds.Tables[0].Rows[0]["REPORT_PARM"].ToString();
				if(ds.Tables[0].Rows[0]["QUICK_PRINT"].ToString()!="")
				{
					model.QUICK_PRINT=int.Parse(ds.Tables[0].Rows[0]["QUICK_PRINT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CHOOSE_PAYE"].ToString()!="")
				{
					model.CHOOSE_PAYE=int.Parse(ds.Tables[0].Rows[0]["CHOOSE_PAYE"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MARGINS_TOP"].ToString()!="")
				{
					model.MARGINS_TOP=int.Parse(ds.Tables[0].Rows[0]["MARGINS_TOP"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MARGINS_BUTTOM"].ToString()!="")
				{
					model.MARGINS_BUTTOM=int.Parse(ds.Tables[0].Rows[0]["MARGINS_BUTTOM"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MARGINS_LEFT"].ToString()!="")
				{
					model.MARGINS_LEFT=int.Parse(ds.Tables[0].Rows[0]["MARGINS_LEFT"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MARGINS_RIGHT"].ToString()!="")
				{
					model.MARGINS_RIGHT=int.Parse(ds.Tables[0].Rows[0]["MARGINS_RIGHT"].ToString());
				}
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
			strSql.Append("select RKEY,SERVER_PTR,MODUL_PTR,TTYPE,REPORT_PATH,REPORT_NAME,DISPLAY_NAME,REPORT_CODE,REPORT_PARM,QUICK_PRINT,CHOOSE_PAYE,MARGINS_TOP,MARGINS_BUTTOM,MARGINS_LEFT,MARGINS_RIGHT,ACTIVE_FLAG,EMP_PTR ");
			strSql.Append(" FROM RPT_SETPARM with(nolock)  ");
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
			strSql.Append(" RKEY,SERVER_PTR,MODUL_PTR,TTYPE,REPORT_PATH,REPORT_NAME,DISPLAY_NAME,REPORT_CODE,REPORT_PARM,QUICK_PRINT,CHOOSE_PAYE,MARGINS_TOP,MARGINS_BUTTOM,MARGINS_LEFT,MARGINS_RIGHT,ACTIVE_FLAG,EMP_PTR ");
			strSql.Append(" FROM RPT_SETPARM with(nolock) ");
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
			parameters[0].Value = "RPT_SETPARM";
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

