using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Approval_Info 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Approval_Info
	{
		public pms_Approval_Info()
		{}
		#region Model
		private int _approvalinfoid;
		private int _quotationinfoid;
		private int _userinfoid;
		private int _quotationrate;
		private int _transportrate;
		private int _testingrate;
		private int _packingrate;
		private int _kniferate;
		private int _toolrate;
		private DateTime _approvaldate;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public int ApprovalInfoID
		{
			set{ _approvalinfoid=value;}
			get{return _approvalinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int QuotationInfoID
		{
			set{ _quotationinfoid=value;}
			get{return _quotationinfoid;}
		}
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
		public int QuotationRate
		{
			set{ _quotationrate=value;}
			get{return _quotationrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TransportRate
		{
			set{ _transportrate=value;}
			get{return _transportrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TestingRate
		{
			set{ _testingrate=value;}
			get{return _testingrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int PackingRate
		{
			set{ _packingrate=value;}
			get{return _packingrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int KnifeRate
		{
			set{ _kniferate=value;}
			get{return _kniferate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ToolRate
		{
			set{ _toolrate=value;}
			get{return _toolrate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime ApprovalDate
		{
			set{ _approvaldate=value;}
			get{return _approvaldate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

