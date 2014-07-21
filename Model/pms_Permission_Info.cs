using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Permission_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Permission_Info
	{
		public pms_Permission_Info()
		{}
		#region Model
		private int _permissioninfoid;
		private string _permission;
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
		public string Permission
		{
			set{ _permission=value;}
			get{return _permission;}
		}
		#endregion Model

	}
}

