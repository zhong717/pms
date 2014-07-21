using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_WorkContent 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_WorkContent
	{
		public pms_WorkContent()
		{}
		#region Model
		private int _workcontentid;
		private string _workcontent;
		/// <summary>
		/// 
		/// </summary>
		public int WorkContentID
		{
			set{ _workcontentid=value;}
			get{return _workcontentid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WorkContent
		{
			set{ _workcontent=value;}
			get{return _workcontent;}
		}
		#endregion Model

	}
}

