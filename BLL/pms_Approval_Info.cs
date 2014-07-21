using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_Approval_Info 的摘要说明。
	/// </summary>
	public class pms_Approval_Info
	{
		private readonly TSM.DAL.pms_Approval_Info dal=new TSM.DAL.pms_Approval_Info();
		public pms_Approval_Info()
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
		public bool Exists(int ApprovalInfoID)
		{
			return dal.Exists(ApprovalInfoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_Approval_Info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Approval_Info model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ApprovalInfoID)
		{
			
			dal.Delete(ApprovalInfoID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Approval_Info GetModel(int ApprovalInfoID)
		{
			
			return dal.GetModel(ApprovalInfoID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_Approval_Info GetModelByCache(int ApprovalInfoID)
		{
			
			string CacheKey = "pms_Approval_InfoModel-" + ApprovalInfoID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ApprovalInfoID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_Approval_Info)objModel;
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
		public List<TSM.Model.pms_Approval_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Approval_Info> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_Approval_Info> modelList = new List<TSM.Model.pms_Approval_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_Approval_Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_Approval_Info();
					if(dt.Rows[n]["ApprovalInfoID"].ToString()!="")
					{
						model.ApprovalInfoID=int.Parse(dt.Rows[n]["ApprovalInfoID"].ToString());
					}
					if(dt.Rows[n]["QuotationInfoID"].ToString()!="")
					{
						model.QuotationInfoID=int.Parse(dt.Rows[n]["QuotationInfoID"].ToString());
					}
					if(dt.Rows[n]["UserInfoID"].ToString()!="")
					{
						model.UserInfoID=int.Parse(dt.Rows[n]["UserInfoID"].ToString());
					}
					if(dt.Rows[n]["QuotationRate"].ToString()!="")
					{
						model.QuotationRate=int.Parse(dt.Rows[n]["QuotationRate"].ToString());
					}
					if(dt.Rows[n]["TransportRate"].ToString()!="")
					{
						model.TransportRate=int.Parse(dt.Rows[n]["TransportRate"].ToString());
					}
					if(dt.Rows[n]["TestingRate"].ToString()!="")
					{
						model.TestingRate=int.Parse(dt.Rows[n]["TestingRate"].ToString());
					}
					if(dt.Rows[n]["PackingRate"].ToString()!="")
					{
						model.PackingRate=int.Parse(dt.Rows[n]["PackingRate"].ToString());
					}
					if(dt.Rows[n]["KnifeRate"].ToString()!="")
					{
						model.KnifeRate=int.Parse(dt.Rows[n]["KnifeRate"].ToString());
					}
					if(dt.Rows[n]["ToolRate"].ToString()!="")
					{
						model.ToolRate=int.Parse(dt.Rows[n]["ToolRate"].ToString());
					}
					if(dt.Rows[n]["ApprovalDate"].ToString()!="")
					{
						model.ApprovalDate=DateTime.Parse(dt.Rows[n]["ApprovalDate"].ToString());
					}
					model.Remarks=dt.Rows[n]["Remarks"].ToString();
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

		#endregion  成员方法
	}
}

