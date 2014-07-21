using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_OutAssistance_WorkPlan。
	/// </summary>
	public class pms_OutAssistance_WorkPlan
	{
		public pms_OutAssistance_WorkPlan()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("WorkPlanID", "pms_OutAssistance_WorkPlan"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int WorkPlanID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_OutAssistance_WorkPlan");
			strSql.Append(" where WorkPlanID=@WorkPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkPlanID", SqlDbType.Int,4)};
			parameters[0].Value = WorkPlanID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_OutAssistance_WorkPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_OutAssistance_WorkPlan(");
			strSql.Append("PlanMonth,WorkTypeID,WorkContentID,WorkPlan,PlanTime,PlannerID,Report,ReportTime,ReporterID,Completion,Result,WorkHour)");
			strSql.Append(" values (");
			strSql.Append("@PlanMonth,@WorkTypeID,@WorkContentID,@WorkPlan,@PlanTime,@PlannerID,@Report,@ReportTime,@ReporterID,@Completion,@Result,@WorkHour)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@PlanMonth", SqlDbType.VarChar,7),
					new SqlParameter("@WorkTypeID", SqlDbType.Int,4),
					new SqlParameter("@WorkContentID", SqlDbType.Int,4),
					new SqlParameter("@WorkPlan", SqlDbType.VarChar,300),
					new SqlParameter("@PlanTime", SqlDbType.DateTime),
					new SqlParameter("@PlannerID", SqlDbType.Int,4),
					new SqlParameter("@Report", SqlDbType.VarChar,300),
					new SqlParameter("@ReportTime", SqlDbType.DateTime),
					new SqlParameter("@ReporterID", SqlDbType.Int,4),
					new SqlParameter("@Completion", SqlDbType.VarChar,64),
					new SqlParameter("@Result", SqlDbType.VarChar,64),
					new SqlParameter("@WorkHour", SqlDbType.Int,4)};
			parameters[0].Value = model.PlanMonth;
			parameters[1].Value = model.WorkTypeID;
			parameters[2].Value = model.WorkContentID;
			parameters[3].Value = model.WorkPlan;
			parameters[4].Value = model.PlanTime;
			parameters[5].Value = model.PlannerID;
			parameters[6].Value = model.Report;
			parameters[7].Value = model.ReportTime;
			parameters[8].Value = model.ReporterID;
			parameters[9].Value = model.Completion;
			parameters[10].Value = model.Result;
			parameters[11].Value = model.WorkHour;

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
		public void Update(TSM.Model.pms_OutAssistance_WorkPlan model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_OutAssistance_WorkPlan set ");
			strSql.Append("PlanMonth=@PlanMonth,");
			strSql.Append("WorkTypeID=@WorkTypeID,");
			strSql.Append("WorkContentID=@WorkContentID,");
			strSql.Append("WorkPlan=@WorkPlan,");
			strSql.Append("PlanTime=@PlanTime,");
			strSql.Append("PlannerID=@PlannerID,");
			strSql.Append("Report=@Report,");
			strSql.Append("ReportTime=@ReportTime,");
			strSql.Append("ReporterID=@ReporterID,");
			strSql.Append("Completion=@Completion,");
			strSql.Append("Result=@Result,");
			strSql.Append("WorkHour=@WorkHour");
			strSql.Append(" where WorkPlanID=@WorkPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkPlanID", SqlDbType.Int,4),
					new SqlParameter("@PlanMonth", SqlDbType.VarChar,7),
					new SqlParameter("@WorkTypeID", SqlDbType.Int,4),
					new SqlParameter("@WorkContentID", SqlDbType.Int,4),
					new SqlParameter("@WorkPlan", SqlDbType.VarChar,300),
					new SqlParameter("@PlanTime", SqlDbType.DateTime),
					new SqlParameter("@PlannerID", SqlDbType.Int,4),
					new SqlParameter("@Report", SqlDbType.VarChar,300),
					new SqlParameter("@ReportTime", SqlDbType.DateTime),
					new SqlParameter("@ReporterID", SqlDbType.Int,4),
					new SqlParameter("@Completion", SqlDbType.VarChar,64),
					new SqlParameter("@Result", SqlDbType.VarChar,64),
					new SqlParameter("@WorkHour", SqlDbType.Int,4)};
			parameters[0].Value = model.WorkPlanID;
			parameters[1].Value = model.PlanMonth;
			parameters[2].Value = model.WorkTypeID;
			parameters[3].Value = model.WorkContentID;
			parameters[4].Value = model.WorkPlan;
			parameters[5].Value = model.PlanTime;
			parameters[6].Value = model.PlannerID;
			parameters[7].Value = model.Report;
			parameters[8].Value = model.ReportTime;
			parameters[9].Value = model.ReporterID;
			parameters[10].Value = model.Completion;
			parameters[11].Value = model.Result;
			parameters[12].Value = model.WorkHour;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int WorkPlanID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_OutAssistance_WorkPlan ");
			strSql.Append(" where WorkPlanID=@WorkPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkPlanID", SqlDbType.Int,4)};
			parameters[0].Value = WorkPlanID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_OutAssistance_WorkPlan GetModel(int WorkPlanID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 WorkPlanID,PlanMonth,WorkTypeID,WorkContentID,WorkPlan,PlanTime,PlannerID,Report,ReportTime,ReporterID,Completion,Result,WorkHour from pms_OutAssistance_WorkPlan ");
			strSql.Append(" where WorkPlanID=@WorkPlanID ");
			SqlParameter[] parameters = {
					new SqlParameter("@WorkPlanID", SqlDbType.Int,4)};
			parameters[0].Value = WorkPlanID;

			TSM.Model.pms_OutAssistance_WorkPlan model=new TSM.Model.pms_OutAssistance_WorkPlan();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["WorkPlanID"].ToString()!="")
				{
					model.WorkPlanID=int.Parse(ds.Tables[0].Rows[0]["WorkPlanID"].ToString());
				}
				model.PlanMonth=ds.Tables[0].Rows[0]["PlanMonth"].ToString();
				if(ds.Tables[0].Rows[0]["WorkTypeID"].ToString()!="")
				{
					model.WorkTypeID=int.Parse(ds.Tables[0].Rows[0]["WorkTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["WorkContentID"].ToString()!="")
				{
					model.WorkContentID=int.Parse(ds.Tables[0].Rows[0]["WorkContentID"].ToString());
				}
				model.WorkPlan=ds.Tables[0].Rows[0]["WorkPlan"].ToString();
				if(ds.Tables[0].Rows[0]["PlanTime"].ToString()!="")
				{
					model.PlanTime=DateTime.Parse(ds.Tables[0].Rows[0]["PlanTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PlannerID"].ToString()!="")
				{
					model.PlannerID=int.Parse(ds.Tables[0].Rows[0]["PlannerID"].ToString());
				}
				model.Report=ds.Tables[0].Rows[0]["Report"].ToString();
				if(ds.Tables[0].Rows[0]["ReportTime"].ToString()!="")
				{
					model.ReportTime=DateTime.Parse(ds.Tables[0].Rows[0]["ReportTime"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ReporterID"].ToString()!="")
				{
					model.ReporterID=int.Parse(ds.Tables[0].Rows[0]["ReporterID"].ToString());
				}
				model.Completion=ds.Tables[0].Rows[0]["Completion"].ToString();
				model.Result=ds.Tables[0].Rows[0]["Result"].ToString();
				if(ds.Tables[0].Rows[0]["WorkHour"].ToString()!="")
				{
					model.WorkHour=int.Parse(ds.Tables[0].Rows[0]["WorkHour"].ToString());
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
			strSql.Append("select WorkPlanID,PlanMonth,WorkTypeID,WorkContentID,WorkPlan,PlanTime,PlannerID,Report,ReportTime,ReporterID,Completion,Result,WorkHour ");
			strSql.Append(" FROM pms_OutAssistance_WorkPlan ");
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
			strSql.Append(" WorkPlanID,PlanMonth,WorkTypeID,WorkContentID,WorkPlan,PlanTime,PlannerID,Report,ReportTime,ReporterID,Completion,Result,WorkHour ");
			strSql.Append(" FROM pms_OutAssistance_WorkPlan ");
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
			parameters[0].Value = "pms_OutAssistance_WorkPlan";
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

