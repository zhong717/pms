using System;
namespace TSM.Model
{
	/// <summary>
	/// 实体类pms_Machine_Price 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class pms_Machine_Price
	{
		public pms_Machine_Price()
		{}
		#region Model
		private int _machinepriceid;
		private string _devicetype;
		private string _devicedescript;
		private int _internalcost;
		private int _internalprice;
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
		public string DeviceType
		{
			set{ _devicetype=value;}
			get{return _devicetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DeviceDescript
		{
			set{ _devicedescript=value;}
			get{return _devicedescript;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InternalCost
		{
			set{ _internalcost=value;}
			get{return _internalcost;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int InternalPrice
		{
			set{ _internalprice=value;}
			get{return _internalprice;}
		}
		#endregion Model

	}
}

