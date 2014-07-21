using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Dept_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Dept_Info
	{
		public pms_Dept_Info()
		{}
		#region Model
		private int _deptinfoid;
		private string _deptname;
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
		public string DeptName
		{
			set{ _deptname=value;}
			get{return _deptname;}
		}
		#endregion Model

	}
}

