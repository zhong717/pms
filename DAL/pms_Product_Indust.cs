using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Product_Indust。
	/// </summary>
	public class pms_Product_Indust
	{
		public pms_Product_Indust()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductIndustID", "pms_Product_Indust"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductIndustID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Product_Indust");
			strSql.Append(" where ProductIndustID=@ProductIndustID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4)};
			parameters[0].Value = ProductIndustID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Product_Indust model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Product_Indust(");
			strSql.Append("ProductIndust)");
			strSql.Append(" values (");
			strSql.Append("@ProductIndust)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductIndust", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ProductIndust;

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
		public void Update(TSM.Model.pms_Product_Indust model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Product_Indust set ");
			strSql.Append("ProductIndust=@ProductIndust");
			strSql.Append(" where ProductIndustID=@ProductIndustID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4),
					new SqlParameter("@ProductIndust", SqlDbType.VarChar,64)};
			parameters[0].Value = model.ProductIndustID;
			parameters[1].Value = model.ProductIndust;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductIndustID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Product_Indust ");
			strSql.Append(" where ProductIndustID=@ProductIndustID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4)};
			parameters[0].Value = ProductIndustID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Product_Indust GetModel(int ProductIndustID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductIndustID,ProductIndust from pms_Product_Indust ");
			strSql.Append(" where ProductIndustID=@ProductIndustID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4)};
			parameters[0].Value = ProductIndustID;

			TSM.Model.pms_Product_Indust model=new TSM.Model.pms_Product_Indust();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductIndustID"].ToString()!="")
				{
					model.ProductIndustID=int.Parse(ds.Tables[0].Rows[0]["ProductIndustID"].ToString());
				}
				model.ProductIndust=ds.Tables[0].Rows[0]["ProductIndust"].ToString();
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
			strSql.Append("select ProductIndustID,ProductIndust ");
			strSql.Append(" FROM pms_Product_Indust ");
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
			strSql.Append(" ProductIndustID,ProductIndust ");
			strSql.Append(" FROM pms_Product_Indust ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
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
			parameters[0].Value = "pms_Product_Indust";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

