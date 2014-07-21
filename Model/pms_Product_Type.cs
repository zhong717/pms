using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Product_Type 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Product_Type
	{
		public pms_Product_Type()
		{}
		#region Model
		private int _producttypeid;
		private string _producttype;
		/// <summary>
		/// 
		/// </summary>
		public int ProductTypeID
		{
			set{ _producttypeid=value;}
			get{return _producttypeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductType
		{
			set{ _producttype=value;}
			get{return _producttype;}
		}
		#endregion Model

	}
}

