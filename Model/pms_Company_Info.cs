using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Company_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Company_Info
	{
		public pms_Company_Info()
		{}
		#region Model
		private int _companyinfoid;
		private string _companytype;
		private string _companyname;
		/// <summary>
		/// 
		/// </summary>
		public int CompanyInfoID
		{
			set{ _companyinfoid=value;}
			get{return _companyinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyType
		{
			set{ _companytype=value;}
			get{return _companytype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string CompanyName
		{
			set{ _companyname=value;}
			get{return _companyname;}
		}
		#endregion Model

	}
}

