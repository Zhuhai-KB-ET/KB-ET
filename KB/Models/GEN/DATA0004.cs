﻿//============================================================
// 项目名称:	    方正集团 PCB事业部 ERP系统
// 版本号: 		 v1.0
// CopyRight@ 2010,方正集团 All Rights Reserved 版权所有
// 编写日期: 	2010/9/27 16:01:35
//============================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace KB.Models
{
	///<summary>
	///数据实体 [表名("DATA0004")]
	/// </summary>
	[Serializable()]
	public class DATA0004 : ICloneable
	{
		/// <summary>
		///  成员 
		/// </summary> 
		private decimal rkey; 
		private decimal control_no_length;
		private string seed_value = String.Empty;
		private decimal seed_flag;
		
		///<summary>
		///  构造方法
		///</summary>
		public DATA0004() { } 
		
		///<summary>
		///主键 [字段("RKEY")]
		///数据库类型:numeric(10, 0)
		///</summary> 
		public decimal RKEY
		{
			get { return this.rkey; }
			set { this.rkey = value; }
		} 
		
		
		
		///<summary>
		///属性 [("CONTROL_NO_LENGTH")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal CONTROL_NO_LENGTH
		{
			get { return this.control_no_length; }
			set { this.control_no_length = value; }
		}
		
		///<summary>
		///属性 [("SEED_VALUE")]
		///数据库类型:char(20)
		///</summary>
		public string SEED_VALUE
		{
			get { return this.seed_value; }
			set { this.seed_value = value; }
		}
		
		///<summary>
		///属性 [("SEED_FLAG")]
		///数据库类型:numeric(10, 0)
		///</summary>
		public decimal SEED_FLAG
		{
			get { return this.seed_flag; }
			set { this.seed_flag = value; }
		}
		
				/// <summary>
        /// ICloneable 实现克隆本身, 深度克隆
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            BinaryFormatter Formatter = new BinaryFormatter(null, new StreamingContext(StreamingContextStates.Clone));
            MemoryStream stream = new MemoryStream();
            Formatter.Serialize(stream, this);
            stream.Position = 0;
            object clonedObj = Formatter.Deserialize(stream);
            stream.Close();
            return clonedObj; 
        }
	}
}
