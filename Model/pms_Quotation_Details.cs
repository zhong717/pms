using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Quotation_Details 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Quotation_Details
	{
		public pms_Quotation_Details()
		{}
		#region Model
		private int _quotationdetailsid;
		private int _quotationinfoid;
		private int _machinepriceid;
		private decimal _workinghour;
		/// <summary>
		/// 
		/// </summary>
		public int QuotationDetailsID
		{
			set{ _quotationdetailsid=value;}
			get{return _quotationdetailsid;}
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
		public int MachinePriceID
		{
			set{ _machinepriceid=value;}
			get{return _machinepriceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal WorkingHour
		{
			set{ _workinghour=value;}
			get{return _workinghour;}
		}
		#endregion Model

	}
}

