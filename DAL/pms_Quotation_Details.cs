using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Quotation_Details。
	/// </summary>
	public class pms_Quotation_Details
	{
		public pms_Quotation_Details()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("QuotationDetailsID", "pms_Quotation_Details"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int QuotationDetailsID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Quotation_Details");
			strSql.Append(" where QuotationDetailsID=@QuotationDetailsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationDetailsID", SqlDbType.Int,4)};
			parameters[0].Value = QuotationDetailsID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Quotation_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Quotation_Details(");
			strSql.Append("QuotationInfoID,MachinePriceID,WorkingHour)");
			strSql.Append(" values (");
			strSql.Append("@QuotationInfoID,@MachinePriceID,@WorkingHour)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationInfoID", SqlDbType.Int,4),
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4),
					new SqlParameter("@WorkingHour", SqlDbType.Int,4)};
			parameters[0].Value = model.QuotationInfoID;
			parameters[1].Value = model.MachinePriceID;
			parameters[2].Value = model.WorkingHour;

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
		public void Update(TSM.Model.pms_Quotation_Details model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Quotation_Details set ");
			strSql.Append("QuotationInfoID=@QuotationInfoID,");
			strSql.Append("MachinePriceID=@MachinePriceID,");
			strSql.Append("WorkingHour=@WorkingHour");
			strSql.Append(" where QuotationDetailsID=@QuotationDetailsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationDetailsID", SqlDbType.Int,4),
					new SqlParameter("@QuotationInfoID", SqlDbType.Int,4),
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4),
					new SqlParameter("@WorkingHour", SqlDbType.Int,4)};
			parameters[0].Value = model.QuotationDetailsID;
			parameters[1].Value = model.QuotationInfoID;
			parameters[2].Value = model.MachinePriceID;
			parameters[3].Value = model.WorkingHour;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int QuotationDetailsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Quotation_Details ");
			strSql.Append(" where QuotationDetailsID=@QuotationDetailsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationDetailsID", SqlDbType.Int,4)};
			parameters[0].Value = QuotationDetailsID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Quotation_Details GetModel(int QuotationDetailsID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 QuotationDetailsID,QuotationInfoID,MachinePriceID,WorkingHour from pms_Quotation_Details ");
			strSql.Append(" where QuotationDetailsID=@QuotationDetailsID ");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationDetailsID", SqlDbType.Int,4)};
			parameters[0].Value = QuotationDetailsID;

			TSM.Model.pms_Quotation_Details model=new TSM.Model.pms_Quotation_Details();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["QuotationDetailsID"].ToString()!="")
				{
					model.QuotationDetailsID=int.Parse(ds.Tables[0].Rows[0]["QuotationDetailsID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuotationInfoID"].ToString()!="")
				{
					model.QuotationInfoID=int.Parse(ds.Tables[0].Rows[0]["QuotationInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["MachinePriceID"].ToString()!="")
				{
					model.MachinePriceID=int.Parse(ds.Tables[0].Rows[0]["MachinePriceID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WorkingHour"].ToString()!="")
				{
                    model.WorkingHour = decimal.Parse(ds.Tables[0].Rows[0]["WorkingHour"].ToString());
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
            strSql.Append(" FROM view_pms_Quotation_Details ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			strSql.Append(" QuotationDetailsID,QuotationInfoID,MachinePriceID,WorkingHour ");
			strSql.Append(" FROM pms_Quotation_Details ");
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
			parameters[0].Value = "view_pms_Quotation_Details";
            parameters[1].Value = "QuotationDetailsID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}

		#endregion  成员方法
	}
}

