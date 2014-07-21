using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Product_Struc 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Product_Struc
	{
		public pms_Product_Struc()
		{}
		#region Model
		private int _productstrucid;
		private string _productstruc;
		/// <summary>
		/// 
		/// </summary>
		public int ProductStrucID
		{
			set{ _productstrucid=value;}
			get{return _productstrucid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProductStruc
		{
			set{ _productstruc=value;}
			get{return _productstruc;}
		}
		#endregion Model

	}
}

