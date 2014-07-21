using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Approval_Info。
	/// </summary>
	public class pms_Approval_Info
	{
		public pms_Approval_Info()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ApprovalInfoID", "pms_Approval_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ApprovalInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Approval_Info");
			strSql.Append(" where ApprovalInfoID=@ApprovalInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ApprovalInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ApprovalInfoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Approval_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Approval_Info(");
			strSql.Append("QuotationInfoID,UserInfoID,QuotationRate,TransportRate,TestingRate,PackingRate,KnifeRate,ToolRate,ApprovalDate,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@QuotationInfoID,@UserInfoID,@QuotationRate,@TransportRate,@TestingRate,@PackingRate,@KnifeRate,@ToolRate,@ApprovalDate,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@QuotationInfoID", SqlDbType.Int,4),
					new SqlParameter("@UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@QuotationRate", SqlDbType.Int,4),
					new SqlParameter("@TransportRate", SqlDbType.Int,4),
					new SqlParameter("@TestingRate", SqlDbType.Int,4),
					new SqlParameter("@PackingRate", SqlDbType.Int,4),
					new SqlParameter("@KnifeRate", SqlDbType.Int,4),
					new SqlParameter("@ToolRate", SqlDbType.Int,4),
					new SqlParameter("@ApprovalDate", SqlDbType.DateTime),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.QuotationInfoID;
			parameters[1].Value = model.UserInfoID;
			parameters[2].Value = model.QuotationRate;
			parameters[3].Value = model.TransportRate;
			parameters[4].Value = model.TestingRate;
			parameters[5].Value = model.PackingRate;
			parameters[6].Value = model.KnifeRate;
			parameters[7].Value = model.ToolRate;
			parameters[8].Value = model.ApprovalDate;
			parameters[9].Value = model.Remarks;

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
		public void Update(TSM.Model.pms_Approval_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Approval_Info set ");
			strSql.Append("QuotationInfoID=@QuotationInfoID,");
			strSql.Append("UserInfoID=@UserInfoID,");
			strSql.Append("QuotationRate=@QuotationRate,");
			strSql.Append("TransportRate=@TransportRate,");
			strSql.Append("TestingRate=@TestingRate,");
			strSql.Append("PackingRate=@PackingRate,");
			strSql.Append("KnifeRate=@KnifeRate,");
			strSql.Append("ToolRate=@ToolRate,");
			strSql.Append("ApprovalDate=@ApprovalDate,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ApprovalInfoID=@ApprovalInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ApprovalInfoID", SqlDbType.Int,4),
					new SqlParameter("@QuotationInfoID", SqlDbType.Int,4),
					new SqlParameter("@UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@QuotationRate", SqlDbType.Int,4),
					new SqlParameter("@TransportRate", SqlDbType.Int,4),
					new SqlParameter("@TestingRate", SqlDbType.Int,4),
					new SqlParameter("@PackingRate", SqlDbType.Int,4),
					new SqlParameter("@KnifeRate", SqlDbType.Int,4),
					new SqlParameter("@ToolRate", SqlDbType.Int,4),
					new SqlParameter("@ApprovalDate", SqlDbType.DateTime),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.ApprovalInfoID;
			parameters[1].Value = model.QuotationInfoID;
			parameters[2].Value = model.UserInfoID;
			parameters[3].Value = model.QuotationRate;
			parameters[4].Value = model.TransportRate;
			parameters[5].Value = model.TestingRate;
			parameters[6].Value = model.PackingRate;
			parameters[7].Value = model.KnifeRate;
			parameters[8].Value = model.ToolRate;
			parameters[9].Value = model.ApprovalDate;
			parameters[10].Value = model.Remarks;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ApprovalInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Approval_Info ");
			strSql.Append(" where ApprovalInfoID=@ApprovalInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ApprovalInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ApprovalInfoID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Approval_Info GetModel(int ApprovalInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ApprovalInfoID,QuotationInfoID,UserInfoID,QuotationRate,TransportRate,TestingRate,PackingRate,KnifeRate,ToolRate,ApprovalDate,Remarks from pms_Approval_Info ");
			strSql.Append(" where ApprovalInfoID=@ApprovalInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ApprovalInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ApprovalInfoID;

			TSM.Model.pms_Approval_Info model=new TSM.Model.pms_Approval_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ApprovalInfoID"].ToString()!="")
				{
					model.ApprovalInfoID=int.Parse(ds.Tables[0].Rows[0]["ApprovalInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuotationInfoID"].ToString()!="")
				{
					model.QuotationInfoID=int.Parse(ds.Tables[0].Rows[0]["QuotationInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["UserInfoID"].ToString()!="")
				{
					model.UserInfoID=int.Parse(ds.Tables[0].Rows[0]["UserInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QuotationRate"].ToString()!="")
				{
					model.QuotationRate=int.Parse(ds.Tables[0].Rows[0]["QuotationRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TransportRate"].ToString()!="")
				{
					model.TransportRate=int.Parse(ds.Tables[0].Rows[0]["TransportRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["TestingRate"].ToString()!="")
				{
					model.TestingRate=int.Parse(ds.Tables[0].Rows[0]["TestingRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PackingRate"].ToString()!="")
				{
					model.PackingRate=int.Parse(ds.Tables[0].Rows[0]["PackingRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["KnifeRate"].ToString()!="")
				{
					model.KnifeRate=int.Parse(ds.Tables[0].Rows[0]["KnifeRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ToolRate"].ToString()!="")
				{
					model.ToolRate=int.Parse(ds.Tables[0].Rows[0]["ToolRate"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ApprovalDate"].ToString()!="")
				{
					model.ApprovalDate=DateTime.Parse(ds.Tables[0].Rows[0]["ApprovalDate"].ToString());
				}
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
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
			strSql.Append("select ApprovalInfoID,QuotationInfoID,UserInfoID,QuotationRate,TransportRate,TestingRate,PackingRate,KnifeRate,ToolRate,ApprovalDate,Remarks ");
			strSql.Append(" FROM pms_Approval_Info ");
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
			strSql.Append(" ApprovalInfoID,QuotationInfoID,UserInfoID,QuotationRate,TransportRate,TestingRate,PackingRate,KnifeRate,ToolRate,ApprovalDate,Remarks ");
			strSql.Append(" FROM pms_Approval_Info ");
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
			parameters[0].Value = "pms_Approval_Info";
			parameters[1].Value = "ID";
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

