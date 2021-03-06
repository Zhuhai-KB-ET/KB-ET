﻿//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/10/12 16:03:29
//============================================================


using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using KB.Models;
using KB.FUNC;
using System.Configuration;

namespace KB.DAL
{
	/// <summary>
	/// 数据访问层   FOUNDERPCB_FRIGHTE_02DAL
	/// </summary>
	public  partial class FOUNDERPCB_FRIGHTE_02DAL
	{ 
		#region   字段 and 属性
		DBHelper  dbHelper=null;  
		private int factoryID=0; 
		private string userAD=String.Empty; 
		public int FactoryID{
			get{
				return this.factoryID;
			}	
			set{
				this.factoryID=value;	
			}
		} 
		public string UserAD{
			get{
				return this.userAD;
			}	
			set{
				this.userAD=value;	
			}
		}
	    #endregion
		
		#region 构造函数
		/// <summary>
		/// 构造函数
		/// </summary> 
		public 	FOUNDERPCB_FRIGHTE_02DAL(Form frm)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_FRIGHTE_02DAL(Form frm, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(frm);
		}
		public 	FOUNDERPCB_FRIGHTE_02DAL(int Thread, int factoryID)
		{ 
		    this.FactoryID = factoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public 	FOUNDERPCB_FRIGHTE_02DAL(int Thread)
		{ 
		    this.FactoryID = GlobalVal.UserInfo.FactoryID;
			this.UserAD    = GlobalVal.UserInfo.LoginName;
			this.dbHelper  = new DBHelper(Thread, this.FactoryID);
		}
		public	FOUNDERPCB_FRIGHTE_02DAL(DBHelper DB)
        {
            this.FactoryID = DB.FactoryID;
            this.UserAD    = GlobalVal.UserInfo.LoginName;
            this.dbHelper  = DB;
        } 
		#endregion
		
		#region 添加
		/// <summary>
		/// 向数据库中插入一条新记录。
		/// </summary>
		/// <param name="FOUNDERPCB_FRIGHTE_02">founderpcb_frighte_02对象</param>
		/// <returns>新插入记录的编号</returns>
		public int Add(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{		
			#region 调用SQL存储过程进行添加
			string sql="sp_FOUNDERPCB_FRIGHTE_02_Add";
			///存储过程名
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			///new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@RKEY",SqlDbType.Float),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@SORT",SqlDbType.Int,4),
			new SqlParameter("@OPERATION_ENGLISH",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_NAME",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_DESC",SqlDbType.VarChar,100)
			};
				
			  parameters[0].Value=0;
			  parameters[0].Direction =ParameterDirection.InputOutput ;	
			  parameters[1].Value=this.userAD;
			  parameters[2].Direction =ParameterDirection.InputOutput ;
			  parameters[2].Value=founderpcb_frighte_02.RKEY;
			       parameters[3].Value=founderpcb_frighte_02.PRO_RKEY;
			       parameters[4].Value=founderpcb_frighte_02.SORT;
			       parameters[5].Value=founderpcb_frighte_02.OPERATION_ENGLISH;
			       parameters[6].Value=founderpcb_frighte_02.OPERATION_NAME;
			       parameters[7].Value=founderpcb_frighte_02.OPERATION_DESC;
				
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
				founderpcb_frighte_02.RKEY=decimal.Parse(parameters[2].Value.ToString());
				
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_FRIGHTE_02,save successful");
            } 
            catch (Exception e)
            {
				///message ID
				result=2;
				log.Error("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e); 
            } 
			#endregion
			
			return result;
		} 
		public int Add(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{	
			#region 创建SQL语法
			StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into FOUNDERPCB_FRIGHTE_02(");
			strSql.Append("PRO_RKEY,SORT,OPERATION_ENGLISH,OPERATION_NAME,OPERATION_DESC");
			strSql.Append(" ) values (");
			strSql.Append("@PRO_RKEY,@SORT,@OPERATION_ENGLISH,@OPERATION_NAME,@OPERATION_DESC");
			strSql.Append(");select @@IDENTITY");
			
			SqlParameter[] parameters={  
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@SORT",SqlDbType.Int,4),
			new SqlParameter("@OPERATION_ENGLISH",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_NAME",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_DESC",SqlDbType.VarChar,100)
			};
			
			       parameters[0].Value=founderpcb_frighte_02.PRO_RKEY;
			       parameters[1].Value=founderpcb_frighte_02.SORT;
			       parameters[2].Value=founderpcb_frighte_02.OPERATION_ENGLISH;
			       parameters[3].Value=founderpcb_frighte_02.OPERATION_NAME;
			       parameters[4].Value=founderpcb_frighte_02.OPERATION_DESC;
			#endregion
			
			#region 操作
			if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            int indentity = 0;
            object obj = cmd.ExecuteScalar();
            cmd.Parameters.Clear();
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                indentity = 0;
            }
            else
            {
                indentity = int.Parse(obj.ToString());
            }
			#endregion
			
            return indentity;
		}
		#endregion
		
		#region 修改
		///<sumary>
		///修改  
		///</sumary>
		/// <param name="FOUNDERPCB_FRIGHTE_02">founderpcb_frighte_02对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>
		public   int Update(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			#region 调用SQL存储过程进行修改
			string sql="sp_FOUNDERPCB_FRIGHTE_02_Update";
			//=====
			
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@SORT",SqlDbType.Int,4),
			new SqlParameter("@OPERATION_ENGLISH",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_NAME",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_DESC",SqlDbType.VarChar,100)
			};
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;		
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_frighte_02.RKEY;
			  		parameters[3].Value=founderpcb_frighte_02.PRO_RKEY;
			  		parameters[4].Value=founderpcb_frighte_02.SORT;
			  		parameters[5].Value=founderpcb_frighte_02.OPERATION_ENGLISH;
			  		parameters[6].Value=founderpcb_frighte_02.OPERATION_NAME;
			  		parameters[7].Value=founderpcb_frighte_02.OPERATION_DESC;
			
			//=== 
			#endregion 
			
			#region 数据库操作
			int result=0;
            try
            {
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString()); 
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_FRIGHTE_02,update successful");
            }
            catch (Exception e)
            {
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				result=2;
            }
			#endregion
			
			return result;			
		} 
		public   void Update(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			#region 创建语法
			StringBuilder strSql = new StringBuilder();
			strSql.Append("update FOUNDERPCB_FRIGHTE_02 set "); 
			strSql.Append("PRO_RKEY=@PRO_RKEY,");
			strSql.Append("SORT=@SORT,");
			strSql.Append("OPERATION_ENGLISH=@OPERATION_ENGLISH,");
			strSql.Append("OPERATION_NAME=@OPERATION_NAME,");
			strSql.Append("OPERATION_DESC=@OPERATION_DESC");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters={
			new SqlParameter("@RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@PRO_RKEY",SqlDbType.Decimal,9),
			new SqlParameter("@SORT",SqlDbType.Int,4),
			new SqlParameter("@OPERATION_ENGLISH",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_NAME",SqlDbType.VarChar,50),
			new SqlParameter("@OPERATION_DESC",SqlDbType.VarChar,100)
			};
			
			parameters[0].Value = founderpcb_frighte_02.RKEY;
			       parameters[1].Value=founderpcb_frighte_02.PRO_RKEY;
			       parameters[2].Value=founderpcb_frighte_02.SORT;
			       parameters[3].Value=founderpcb_frighte_02.OPERATION_ENGLISH;
			       parameters[4].Value=founderpcb_frighte_02.OPERATION_NAME;
			       parameters[5].Value=founderpcb_frighte_02.OPERATION_DESC;
			#endregion
			
			#region 操作
			 if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            cmd.ExecuteNonQuery();            
            cmd.Parameters.Clear();    
			#endregion
			
		} 
		#endregion
		
		#region 删除
		///<sumary>
		/// 删除  
		///</sumary>
		/// <param name="founderpcb_frighte_02">对象</param>
		///<returns>返回INT类型号, 0为操作成功, 非0操作失败.</returns>		
		public   int Delete(FOUNDERPCB_FRIGHTE_02 founderpcb_frighte_02)
		{
			#region 调用SQL存储过程进行删除
			string sql="sp_FOUNDERPCB_FRIGHTE_02_Delete";
			//=========================
			SqlParameter[] parameters={
			new SqlParameter("@returnID",SqlDbType.Int),
			new SqlParameter("@userAD",SqlDbType.VarChar),
			new SqlParameter("@RKEY",SqlDbType.Decimal,9)};
			
			  parameters[0].Value=1;
			  parameters[0].Direction =ParameterDirection.InputOutput ;
			  parameters[1].Value=this.userAD;
			  parameters[2].Value=founderpcb_frighte_02.RKEY;
			
			
			//=========================
			#endregion				 
			
			#region 数据库操作
			int result=0;
            try
            { 
				dbHelper.ExecuteCommandProc(sql, parameters);
				result = int.Parse(parameters[0].Value.ToString());
			//	log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_FRIGHTE_02,delete successful");
            }
            catch (Exception e)
            {
				result=2;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
            } 
			#endregion
			
			return result;							
		} 
		///<sumary>
		/// 删除  
		///</sumary>
		/// <param name="founderpcb_frighte_02">对象</param>
		///<returns>返回操作所影响的行数</returns>		 
		public   int DeleteByRKEY(decimal rkey)
		{
			#region 调用SQL存储过程进行删除
			string sql="delete from dbo.FOUNDERPCB_FRIGHTE_02 where RKEY='"+rkey+"'";
			int result=0;
		
            try
            {
				dbHelper.ExecuteCommand(sql);
				result=0;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FOUNDERPCB_FRIGHTE_02,delete successful");
            }
            catch (Exception e)
            {
                result=2;
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";"+e.Message,e);
				throw e;
            } 
			#endregion
			
			return result;							
		} 
		public void Delete(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, decimal rkey)
		{
			#region 创建语法
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from founderpcb_frighte_02 ");
			strSql.Append(" where RKEY=@RKEY ");
			
			SqlParameter[] parameters = {new SqlParameter("@RKEY",SqlDbType.Decimal,9)};				
			parameters[0].Value=rkey;
			#endregion
			
			#region 操作
			if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = strSql.ToString();
            cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;

            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }

            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
			#endregion			
		}
		#endregion
		
		#region 查
		///<sumary>
		///	通过主键获取数据对象
		///</sumary>
		/// <param name="RKEY">rkey</param>
		///<returns>FOUNDERPCB_FRIGHTE_02对象</returns>		
		public FOUNDERPCB_FRIGHTE_02 getFOUNDERPCB_FRIGHTE_02ByRKEY(decimal rkey)
		{
			#region SQL
			string sql=@"select top 1 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(sort,0) as sort
				,
				isNull(operation_english,'') as operation_english
				,
				isNull(operation_name,'') as operation_name
				,
				isNull(operation_desc,'') as operation_desc
				
			from FOUNDERPCB_FRIGHTE_02 with (nolock) where RKEY='{0}'";
             
			#endregion
			
			///定义返回对象
			FOUNDERPCB_FRIGHTE_02  founderpcb_frighte_02=null;
			
			#region 数据库操作
            try
            {
				 founderpcb_frighte_02=new FOUNDERPCB_FRIGHTE_02();
				
				using(DataTable tb=dbHelper.GetDataSet(string.Format(sql,rkey)) )
				{
					foreach(DataRow row in tb.Rows)
					{	
							    founderpcb_frighte_02.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							  	        founderpcb_frighte_02.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString());
							  	        founderpcb_frighte_02.SORT =int.Parse(row["SORT"].ToString());
								   founderpcb_frighte_02.OPERATION_ENGLISH =row["OPERATION_ENGLISH"].ToString();
								   founderpcb_frighte_02.OPERATION_NAME =row["OPERATION_NAME"].ToString();
								   founderpcb_frighte_02.OPERATION_DESC =row["OPERATION_DESC"].ToString();
							
	
							
					}
				}	
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";get function:"+e.Message,e);
            } 
			#endregion
			
			return founderpcb_frighte_02;			
		}
		///<sumary>
		///	通过获取所有数据对象
		///</sumary>
		public IList< FOUNDERPCB_FRIGHTE_02 >  FindAllFOUNDERPCB_FRIGHTE_02()
		{
			return FindBySql("1=1");
		} 
		///<sumary>
		///	通过SQL语句获取数据对象
		///</sumary>
		/// <param name="sqlWhere">sqlWhere参数条件</param>
		///<returns>IList<FOUNDERPCB_FRIGHTE_02>数据集合</returns>		
		public IList< FOUNDERPCB_FRIGHTE_02> FindBySql(string sqlWhere)
		{
			#region SQL
			string sql=@"select 
				isNull(rkey,0) as rkey
				,
				isNull(pro_rkey,0) as pro_rkey
				,
				isNull(sort,0) as sort
				,
				isNull(operation_english,'') as operation_english
				,
				isNull(operation_name,'') as operation_name
				,
				isNull(operation_desc,'') as operation_desc
				
			from FOUNDERPCB_FRIGHTE_02 with (nolock)";
			if(sqlWhere.Length>0)
			{
				sql=sql+" where "+sqlWhere;	
			}
			#endregion
			
			IList<FOUNDERPCB_FRIGHTE_02> resultList=new List<FOUNDERPCB_FRIGHTE_02>();
			
			#region 操作
            try
            { 
				using(DataTable tb=dbHelper.GetDataSet(sql)) 
				{
					foreach(DataRow row in tb.Rows)
					{
							FOUNDERPCB_FRIGHTE_02  founderpcb_frighte_02 =new FOUNDERPCB_FRIGHTE_02();
							
								founderpcb_frighte_02.RKEY=decimal.Parse(row["RKEY"].ToString()) ;
							
								  	founderpcb_frighte_02.PRO_RKEY =decimal.Parse(row["PRO_RKEY"].ToString()) ;
								  	founderpcb_frighte_02.SORT =int.Parse(row["SORT"].ToString()) ;
							      founderpcb_frighte_02.OPERATION_ENGLISH =row["OPERATION_ENGLISH"].ToString();
							      founderpcb_frighte_02.OPERATION_NAME =row["OPERATION_NAME"].ToString();
							      founderpcb_frighte_02.OPERATION_DESC =row["OPERATION_DESC"].ToString();
		
							resultList.Add(founderpcb_frighte_02);
					}
				}
            }
            catch (Exception e)
            { 
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";FindBySql function:"+e.Message,e);
				throw e;
            } 
			#endregion
			
			return resultList;			
		} 
		///<sumary>
		///	通过SQL语句获取数据
		///</sumary>
		/// <param name="sql">sql语句</param>
		///<returns>DataTable</returns> 
		public  DataTable getDataSet(string sql)
		{
			DataTable dt=null;
			try{
			dt=dbHelper.GetDataSet(sql);
			}catch(Exception e)
			{
				log.Info("FID="+this.factoryID.ToString()+";userAD="+this.userAD+";getDataSet function:"+e.Message,e);
				throw e;
			} 
			return dt; 
		} 
		#endregion
		
		#region 关闭
        public void CloseConnection()
        {
            this.dbHelper.CloseConnection();
        }
        #endregion
    } 
} 

