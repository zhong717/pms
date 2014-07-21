using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Company_Info。
	/// </summary>
	public class pms_Company_Info
	{
		public pms_Company_Info()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CompanyInfoID", "pms_Company_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CompanyInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Company_Info");
			strSql.Append(" where CompanyInfoID=@CompanyInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4)};
			parameters[0].Value = CompanyInfoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Company_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Company_Info(");
			strSql.Append("CompanyType,CompanyName)");
			strSql.Append(" values (");
			strSql.Append("@CompanyType,@CompanyName)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyType", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CompanyType;
			parameters[1].Value = model.CompanyName;

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
		public void Update(TSM.Model.pms_Company_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Company_Info set ");
			strSql.Append("CompanyType=@CompanyType,");
			strSql.Append("CompanyName=@CompanyName");
			strSql.Append(" where CompanyInfoID=@CompanyInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4),
					new SqlParameter("@CompanyType", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyName", SqlDbType.VarChar,64)};
			parameters[0].Value = model.CompanyInfoID;
			parameters[1].Value = model.CompanyType;
			parameters[2].Value = model.CompanyName;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int CompanyInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Company_Info ");
			strSql.Append(" where CompanyInfoID=@CompanyInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4)};
			parameters[0].Value = CompanyInfoID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Company_Info GetModel(int CompanyInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 CompanyInfoID,CompanyType,CompanyName from pms_Company_Info ");
			strSql.Append(" where CompanyInfoID=@CompanyInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4)};
			parameters[0].Value = CompanyInfoID;

			TSM.Model.pms_Company_Info model=new TSM.Model.pms_Company_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["CompanyInfoID"].ToString()!="")
				{
					model.CompanyInfoID=int.Parse(ds.Tables[0].Rows[0]["CompanyInfoID"].ToString());
				}
				model.CompanyType=ds.Tables[0].Rows[0]["CompanyType"].ToString();
				model.CompanyName=ds.Tables[0].Rows[0]["CompanyName"].ToString();
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
			strSql.Append("select CompanyInfoID,CompanyType,CompanyName ");
			strSql.Append(" FROM pms_Company_Info ");
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
			strSql.Append(" CompanyInfoID,CompanyType,CompanyName ");
			strSql.Append(" FROM pms_Company_Info ");
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
			parameters[0].Value = "pms_Company_Info";
            parameters[1].Value = "CompanyInfoID";
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

