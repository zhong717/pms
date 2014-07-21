using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Product_Mater 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Product_Mater
	{
		public pms_Product_Mater()
		{}
		#region Model
		private int _productmaterid;
		private string _productmater;
		/// <summary>
		/// 
		/// </summary>
		public int ProductMaterID
		{
			set{ _productmaterid=value;}
			get{return _productmaterid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductMater
		{
			set{ _productmater=value;}
			get{return _productmater;}
		}
		#endregion Model

	}
}

