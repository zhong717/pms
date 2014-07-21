using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Product_Batch 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Product_Batch
	{
		public pms_Product_Batch()
		{}
		#region Model
		private int _productbatchid;
		private string _productbatchname;
		private int _bisnesscontactid;
		private int? _qualitycontactid;
		private int? _customerinfoid;
		private int? _finalcustinfoid;
		private DateTime? _productdate;
		/// <summary>
		/// 
		/// </summary>
		public int ProductBatchID
		{
			set{ _productbatchid=value;}
			get{return _productbatchid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductBatchName
		{
			set{ _productbatchname=value;}
			get{return _productbatchname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int BisnessContactID
		{
			set{ _bisnesscontactid=value;}
			get{return _bisnesscontactid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? QualityContactID
		{
			set{ _qualitycontactid=value;}
			get{return _qualitycontactid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CustomerInfoID
		{
			set{ _customerinfoid=value;}
			get{return _customerinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? FinalCustInfoID
		{
			set{ _finalcustinfoid=value;}
			get{return _finalcustinfoid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime? ProductDate
		{
			set{ _productdate=value;}
			get{return _productdate;}
		}
		#endregion Model

	}
}

