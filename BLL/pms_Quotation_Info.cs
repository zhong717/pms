using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using TSM.Model;
namespace TSM.BLL
{
	/// <summary>
	/// 业务逻辑类pms_Quotation_Info 的摘要说明。
	/// </summary>
	public class pms_Quotation_Info
	{
		private readonly TSM.DAL.pms_Quotation_Info dal=new TSM.DAL.pms_Quotation_Info();
		public pms_Quotation_Info()
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
		public bool Exists(int QuotationInfoID)
		{
			return dal.Exists(QuotationInfoID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(TSM.Model.pms_Quotation_Info model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Quotation_Info model)
		{
			dal.Update(model);
		}

        /// <summary>
        /// 更新审批标志记录
        /// </summary>
        public void UpdateStatus(TSM.Model.pms_Quotation_Info model)
        {
            dal.UpdateStatus(model);
        }

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuotationInfoID)
		{
			
			dal.Delete(QuotationInfoID);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Quotation_Info GetModel(int QuotationInfoID)
		{
			
			return dal.GetModel(QuotationInfoID);
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TSM.Model.pms_Quotation_Info GetModel2(int QuotationInfoID)
        {

            return dal.GetModel2(QuotationInfoID);
        }

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public TSM.Model.pms_Quotation_Info GetModelByCache(int QuotationInfoID)
		{
			
			string CacheKey = "pms_Quotation_InfoModel-" + QuotationInfoID;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(QuotationInfoID);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (TSM.Model.pms_Quotation_Info)objModel;
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
		public List<TSM.Model.pms_Quotation_Info> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<TSM.Model.pms_Quotation_Info> DataTableToList(DataTable dt)
		{
			List<TSM.Model.pms_Quotation_Info> modelList = new List<TSM.Model.pms_Quotation_Info>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				TSM.Model.pms_Quotation_Info model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new TSM.Model.pms_Quotation_Info();
					if(dt.Rows[n]["QuotationInfoID"].ToString()!="")
					{
						model.QuotationInfoID=int.Parse(dt.Rows[n]["QuotationInfoID"].ToString());
					}
					if(dt.Rows[n]["ProductInfoID"].ToString()!="")
					{
						model.ProductInfoID=int.Parse(dt.Rows[n]["ProductInfoID"].ToString());
					}
                    if (dt.Rows[n]["QuotationDepart"].ToString() != "")
                    {
                        model.QuotationDepart = int.Parse(dt.Rows[n]["QuotationDepart"].ToString());
                    }
                    if (dt.Rows[n]["UserInfoID"].ToString() != "")
                    {
                        model.UserInfoID = int.Parse(dt.Rows[n]["UserInfoID"].ToString());
                    }				
					if(dt.Rows[n]["KnifeCharges"].ToString()!="")
					{
						model.KnifeCharges=decimal.Parse(dt.Rows[n]["KnifeCharges"].ToString());
					}
					if(dt.Rows[n]["ToolCharges"].ToString()!="")
					{
						model.ToolCharges=decimal.Parse(dt.Rows[n]["ToolCharges"].ToString());
					}
					if(dt.Rows[n]["QuotationPrice"].ToString()!="")
					{
						model.QuotationPrice=decimal.Parse(dt.Rows[n]["QuotationPrice"].ToString());
					}
					model.ApprovalStatus=dt.Rows[n]["ApprovalStatus"].ToString();
					if(dt.Rows[n]["QuotationTime"].ToString()!="")
					{
						model.QuotationTime=DateTime.Parse(dt.Rows[n]["QuotationTime"].ToString());
					}
					if(dt.Rows[n]["SprayingCharges"].ToString()!="")
					{
						model.SprayingCharges=decimal.Parse(dt.Rows[n]["SprayingCharges"].ToString());
					}
					if(dt.Rows[n]["PackingCharges"].ToString()!="")
					{
						model.PackingCharges=decimal.Parse(dt.Rows[n]["PackingCharges"].ToString());
					}
					if(dt.Rows[n]["TestingCharges"].ToString()!="")
					{
						model.TestingCharges=decimal.Parse(dt.Rows[n]["TestingCharges"].ToString());
					}
					if(dt.Rows[n]["TransportCharges"].ToString()!="")
					{
						model.TransportCharges=decimal.Parse(dt.Rows[n]["TransportCharges"].ToString());
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

		#endregion  成员方法
	}
}

