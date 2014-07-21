using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_Product_Mater 的摘要说明。
	/// </summary>
	public class pms_Product_Mater
	{
		private readonly TSM.DAL.pms_Product_Mater dal=new TSM.DAL.pms_Product_Mater();
		public pms_Product_Mater()
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
		public bool Exists(int ProductMaterID)
		{
			return dal.Exists(ProductMaterID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_Product_Mater model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Product_Mater model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductMaterID)
		{
			
			dal.Delete(ProductMaterID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Product_Mater GetModel(int ProductMaterID)
		{
			
			return dal.GetModel(ProductMaterID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_Product_Mater GetModelByCache(int ProductMaterID)
		{
			
			string CacheKey = "pms_Product_MaterModel-" + ProductMaterID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductMaterID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_Product_Mater)objModel;
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
		public List<TSM.Model.pms_Product_Mater> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Product_Mater> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_Product_Mater> modelList = new List<TSM.Model.pms_Product_Mater>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_Product_Mater model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_Product_Mater();
					if(dt.Rows[n]["ProductMaterID"].ToString()!="")
					{
						model.ProductMaterID=int.Parse(dt.Rows[n]["ProductMaterID"].ToString());
					}
					model.ProductMater=dt.Rows[n]["ProductMater"].ToString();
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

