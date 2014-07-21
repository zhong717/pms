using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Product_Batch。
	/// </summary>
	public class pms_Product_Batch
	{
		public pms_Product_Batch()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductBatchID", "pms_Product_Batch"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductBatchID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Product_Batch");
			strSql.Append(" where ProductBatchID=@ProductBatchID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4)};
			parameters[0].Value = ProductBatchID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Product_Batch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Product_Batch(");
			strSql.Append("ProductBatchName,BisnessContactID,QualityContactID,CustomerInfoID,FinalCustInfoID,ProductDate)");
			strSql.Append(" values (");
			strSql.Append("@ProductBatchName,@BisnessContactID,@QualityContactID,@CustomerInfoID,@FinalCustInfoID,@ProductDate)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchName", SqlDbType.VarChar,64),
					new SqlParameter("@BisnessContactID", SqlDbType.Int,4),
					new SqlParameter("@QualityContactID", SqlDbType.Int,4),
					new SqlParameter("@CustomerInfoID", SqlDbType.Int,4),
					new SqlParameter("@FinalCustInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductDate", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductBatchName;
			parameters[1].Value = model.BisnessContactID;
			parameters[2].Value = model.QualityContactID;
			parameters[3].Value = model.CustomerInfoID;
			parameters[4].Value = model.FinalCustInfoID;
			parameters[5].Value = model.ProductDate;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(TSM.Model.pms_Product_Batch model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Product_Batch set ");
			strSql.Append("ProductBatchName=@ProductBatchName,");
			strSql.Append("BisnessContactID=@BisnessContactID,");
			strSql.Append("QualityContactID=@QualityContactID,");
			strSql.Append("CustomerInfoID=@CustomerInfoID,");
			strSql.Append("FinalCustInfoID=@FinalCustInfoID,");
			strSql.Append("ProductDate=@ProductDate");
			strSql.Append(" where ProductBatchID=@ProductBatchID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4),
					new SqlParameter("@ProductBatchName", SqlDbType.VarChar,64),
					new SqlParameter("@BisnessContactID", SqlDbType.Int,4),
					new SqlParameter("@QualityContactID", SqlDbType.Int,4),
					new SqlParameter("@CustomerInfoID", SqlDbType.Int,4),
					new SqlParameter("@FinalCustInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductDate", SqlDbType.DateTime)};
			parameters[0].Value = model.ProductBatchID;
			parameters[1].Value = model.ProductBatchName;
			parameters[2].Value = model.BisnessContactID;
			parameters[3].Value = model.QualityContactID;
			parameters[4].Value = model.CustomerInfoID;
			parameters[5].Value = model.FinalCustInfoID;
			parameters[6].Value = model.ProductDate;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductBatchID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Product_Batch ");
			strSql.Append(" where ProductBatchID=@ProductBatchID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4)};
			parameters[0].Value = ProductBatchID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Product_Batch GetModel(int ProductBatchID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductBatchID,ProductBatchName,BisnessContactID,QualityContactID,CustomerInfoID,FinalCustInfoID,ProductDate from pms_Product_Batch ");
			strSql.Append(" where ProductBatchID=@ProductBatchID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4)};
			parameters[0].Value = ProductBatchID;

			TSM.Model.pms_Product_Batch model=new TSM.Model.pms_Product_Batch();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductBatchID"].ToString()!="")
				{
					model.ProductBatchID=int.Parse(ds.Tables[0].Rows[0]["ProductBatchID"].ToString());
				}
				model.ProductBatchName=ds.Tables[0].Rows[0]["ProductBatchName"].ToString();
				if(ds.Tables[0].Rows[0]["BisnessContactID"].ToString()!="")
				{
					model.BisnessContactID=int.Parse(ds.Tables[0].Rows[0]["BisnessContactID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QualityContactID"].ToString()!="")
				{
					model.QualityContactID=int.Parse(ds.Tables[0].Rows[0]["QualityContactID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CustomerInfoID"].ToString()!="")
				{
					model.CustomerInfoID=int.Parse(ds.Tables[0].Rows[0]["CustomerInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["FinalCustInfoID"].ToString()!="")
				{
					model.FinalCustInfoID=int.Parse(ds.Tables[0].Rows[0]["FinalCustInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductDate"].ToString()!="")
				{
					model.ProductDate=DateTime.Parse(ds.Tables[0].Rows[0]["ProductDate"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM view_pms_Product_Batch ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetListApp(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM view_pms_Product_Batch_App ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" ProductBatchID,ProductBatchName,BisnessContactID,QualityContactID,CustomerInfoID,FinalCustInfoID,ProductDate ");
			strSql.Append(" FROM pms_Product_Batch ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "view_pms_Product_Batch";
            parameters[1].Value = "ProductBatchID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}

        /// <summary>
        /// 分页获取数据列表-审批时获取批次列表
        /// </summary>
        public DataSet GetListApp(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
            parameters[0].Value = "view_pms_Product_Batch_App";
            parameters[1].Value = "ProductBatchID";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

		#endregion  成员方法
	}
}

