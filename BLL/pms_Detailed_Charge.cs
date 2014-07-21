using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_Detailed_Charge 的摘要说明。
	/// </summary>
	public class pms_Detailed_Charge
	{
		private readonly TSM.DAL.pms_Detailed_Charge dal=new TSM.DAL.pms_Detailed_Charge();
		public pms_Detailed_Charge()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int DetailedChargeID)
		{
			return dal.Exists(DetailedChargeID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_Detailed_Charge model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Detailed_Charge model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int DetailedChargeID)
		{
			
			dal.Delete(DetailedChargeID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Detailed_Charge GetModel(int DetailedChargeID)
		{
			
			return dal.GetModel(DetailedChargeID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_Detailed_Charge GetModelByCache(int DetailedChargeID)
		{
			
			string CacheKey = "pms_Detailed_ChargeModel-" + DetailedChargeID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(DetailedChargeID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_Detailed_Charge)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Detailed_Charge> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Detailed_Charge> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_Detailed_Charge> modelList = new List<TSM.Model.pms_Detailed_Charge>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_Detailed_Charge model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_Detailed_Charge();
					if(dt.Rows[n]["DetailedChargeID"].ToString()!="")
					{
						model.DetailedChargeID=int.Parse(dt.Rows[n]["DetailedChargeID"].ToString());
					}
					if(dt.Rows[n]["QuotationInfoID"].ToString()!="")
					{
						model.QuotationInfoID=int.Parse(dt.Rows[n]["QuotationInfoID"].ToString());
					}
					model.DeviceType=dt.Rows[n]["DeviceType"].ToString();
					model.DeviceDescript=dt.Rows[n]["DeviceDescript"].ToString();
					if(dt.Rows[n]["InternalCost"].ToString()!="")
					{
						model.InternalCost=int.Parse(dt.Rows[n]["InternalCost"].ToString());
					}
					if(dt.Rows[n]["InternalPrice"].ToString()!="")
					{
						model.InternalPrice=int.Parse(dt.Rows[n]["InternalPrice"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

