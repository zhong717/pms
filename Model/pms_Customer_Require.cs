using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Customer_Require 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Customer_Require
	{
		public pms_Customer_Require()
		{}
		#region Model
		private int _customerrequireid;
		private string _customerrequire;
		/// <summary>
		/// 
		/// </summary>
		public int CustomerRequireID
		{
			set{ _customerrequireid=value;}
			get{return _customerrequireid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CustomerRequire
		{
			set{ _customerrequire=value;}
			get{return _customerrequire;}
		}
		#endregion Model

	}
}

