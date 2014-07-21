using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_OutAssistance_WorkPlan 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_OutAssistance_WorkPlan
	{
		public pms_OutAssistance_WorkPlan()
		{}
		#region Model
		private int _workplanid;
		private string _planmonth;
		private int _worktypeid;
		private int _workcontentid;
		private string _workplan;
		private DateTime _plantime;
		private int _plannerid;
		private string _report;
		private DateTime _reporttime;
		private int _reporterid;
		private string _completion;
		private string _result;
		private int _workhour;
		/// <summary>
		/// 
		/// </summary>
		public int WorkPlanID
		{
			set{ _workplanid=value;}
			get{return _workplanid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PlanMonth
		{
			set{ _planmonth=value;}
			get{return _planmonth;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WorkTypeID
		{
			set{ _worktypeid=value;}
			get{return _worktypeid;}
		}
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
		public string WorkPlan
		{
			set{ _workplan=value;}
			get{return _workplan;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime PlanTime
		{
			set{ _plantime=value;}
			get{return _plantime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PlannerID
		{
			set{ _plannerid=value;}
			get{return _plannerid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Report
		{
			set{ _report=value;}
			get{return _report;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ReportTime
		{
			set{ _reporttime=value;}
			get{return _reporttime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ReporterID
		{
			set{ _reporterid=value;}
			get{return _reporterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Completion
		{
			set{ _completion=value;}
			get{return _completion;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Result
		{
			set{ _result=value;}
			get{return _result;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WorkHour
		{
			set{ _workhour=value;}
			get{return _workhour;}
		}
		#endregion Model

	}
}

