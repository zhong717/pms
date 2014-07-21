using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_Product_Batch 的摘要说明。
	/// </summary>
	public class pms_Product_Batch
	{
		private readonly TSM.DAL.pms_Product_Batch dal=new TSM.DAL.pms_Product_Batch();
		public pms_Product_Batch()
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
		public bool Exists(int ProductBatchID)
		{
			return dal.Exists(ProductBatchID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_Product_Batch model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Product_Batch model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductBatchID)
		{
			
			dal.Delete(ProductBatchID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Product_Batch GetModel(int ProductBatchID)
		{
			
			return dal.GetModel(ProductBatchID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_Product_Batch GetModelByCache(int ProductBatchID)
		{
			
			string CacheKey = "pms_Product_BatchModel-" + ProductBatchID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductBatchID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_Product_Batch)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListApp(string strWhere)
        {
            return dal.GetListApp(strWhere);
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
		public List<TSM.Model.pms_Product_Batch> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Product_Batch> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_Product_Batch> modelList = new List<TSM.Model.pms_Product_Batch>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_Product_Batch model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_Product_Batch();
					if(dt.Rows[n]["ProductBatchID"].ToString()!="")
					{
						model.ProductBatchID=int.Parse(dt.Rows[n]["ProductBatchID"].ToString());
					}
					model.ProductBatchName=dt.Rows[n]["ProductBatchName"].ToString();
					if(dt.Rows[n]["BisnessContactID"].ToString()!="")
					{
						model.BisnessContactID=int.Parse(dt.Rows[n]["BisnessContactID"].ToString());
					}
					if(dt.Rows[n]["QualityContactID"].ToString()!="")
					{
						model.QualityContactID=int.Parse(dt.Rows[n]["QualityContactID"].ToString());
					}
					if(dt.Rows[n]["CustomerInfoID"].ToString()!="")
					{
						model.CustomerInfoID=int.Parse(dt.Rows[n]["CustomerInfoID"].ToString());
					}
					if(dt.Rows[n]["FinalCustInfoID"].ToString()!="")
					{
						model.FinalCustInfoID=int.Parse(dt.Rows[n]["FinalCustInfoID"].ToString());
					}
					if(dt.Rows[n]["ProductDate"].ToString()!="")
					{
						model.ProductDate=DateTime.Parse(dt.Rows[n]["ProductDate"].ToString());
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
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			return dal.GetList(PageSize,PageIndex,strWhere);
		}

        /// <summary>
		/// 获得数据列表
		/// </summary>
        public DataSet GetListApp(int PageSize, int PageIndex, string strWhere)
		{
            return dal.GetListApp(PageSize, PageIndex, strWhere);
		}

        
		#endregion  成员方法
	}
}

