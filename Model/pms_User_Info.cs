using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_User_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_User_Info
	{
		public pms_User_Info()
		{}
		#region Model
		private int _userinfoid;
		private string _username;
		private string _pwd;
		private int _companyinfoid;
		private int _deptinfoid;
		private int _permissioninfoid;
		private string _usertel;
		private string _userphone;
		private string _usermail;
		/// <summary>
		/// 
		/// </summary>
		public int UserInfoID
		{
			set{ _userinfoid=value;}
			get{return _userinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Pwd
		{
			set{ _pwd=value;}
			get{return _pwd;}
		}
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
		public int DeptInfoID
		{
			set{ _deptinfoid=value;}
			get{return _deptinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PermissionInfoID
		{
			set{ _permissioninfoid=value;}
			get{return _permissioninfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserTel
		{
			set{ _usertel=value;}
			get{return _usertel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserPhone
		{
			set{ _userphone=value;}
			get{return _userphone;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserMail
		{
			set{ _usermail=value;}
			get{return _usermail;}
		}
		#endregion Model

	}
}

