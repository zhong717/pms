using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_WorkContent。
	/// </summary>
	public class pms_WorkContent
	{
		public pms_WorkContent()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("WorkContentID", "pms_WorkContent"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WorkContentID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_WorkContent");
			strSql.Append(" where WorkContentID=@WorkContentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkContentID", SqlDbType.Int,4)};
			parameters[0].Value = WorkContentID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_WorkContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_WorkContent(");
			strSql.Append("WorkContent)");
			strSql.Append(" values (");
			strSql.Append("@WorkContent)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkContent", SqlDbType.VarChar,20)};
			parameters[0].Value = model.WorkContent;

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
		public void Update(TSM.Model.pms_WorkContent model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_WorkContent set ");
			strSql.Append("WorkContent=@WorkContent");
			strSql.Append(" where WorkContentID=@WorkContentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkContentID", SqlDbType.Int,4),
					new SqlParameter("@WorkContent", SqlDbType.VarChar,20)};
			parameters[0].Value = model.WorkContentID;
			parameters[1].Value = model.WorkContent;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int WorkContentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_WorkContent ");
			strSql.Append(" where WorkContentID=@WorkContentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkContentID", SqlDbType.Int,4)};
			parameters[0].Value = WorkContentID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_WorkContent GetModel(int WorkContentID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WorkContentID,WorkContent from pms_WorkContent ");
			strSql.Append(" where WorkContentID=@WorkContentID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkContentID", SqlDbType.Int,4)};
			parameters[0].Value = WorkContentID;

			TSM.Model.pms_WorkContent model=new TSM.Model.pms_WorkContent();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["WorkContentID"].ToString()!="")
				{
					model.WorkContentID=int.Parse(ds.Tables[0].Rows[0]["WorkContentID"].ToString());
				}
				model.WorkContent=ds.Tables[0].Rows[0]["WorkContent"].ToString();
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
			strSql.Append("select WorkContentID,WorkContent ");
			strSql.Append(" FROM pms_WorkContent ");
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
			strSql.Append(" WorkContentID,WorkContent ");
			strSql.Append(" FROM pms_WorkContent ");
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
			parameters[0].Value = "pms_WorkContent";
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

