using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Machine_Price。
	/// </summary>
	public class pms_Machine_Price
	{
		public pms_Machine_Price()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("MachinePriceID", "pms_Machine_Price"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int MachinePriceID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Machine_Price");
			strSql.Append(" where MachinePriceID=@MachinePriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4)};
			parameters[0].Value = MachinePriceID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Machine_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Machine_Price(");
			strSql.Append("DeviceType,DeviceDescript,InternalCost,InternalPrice)");
			strSql.Append(" values (");
			strSql.Append("@DeviceType,@DeviceDescript,@InternalCost,@InternalPrice)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@DeviceType", SqlDbType.VarChar,64),
					new SqlParameter("@DeviceDescript", SqlDbType.VarChar,64),
					new SqlParameter("@InternalCost", SqlDbType.Int,4),
					new SqlParameter("@InternalPrice", SqlDbType.Int,4)};
			parameters[0].Value = model.DeviceType;
			parameters[1].Value = model.DeviceDescript;
			parameters[2].Value = model.InternalCost;
			parameters[3].Value = model.InternalPrice;

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
		public void Update(TSM.Model.pms_Machine_Price model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Machine_Price set ");
			strSql.Append("DeviceType=@DeviceType,");
			strSql.Append("DeviceDescript=@DeviceDescript,");
			strSql.Append("InternalCost=@InternalCost,");
			strSql.Append("InternalPrice=@InternalPrice");
			strSql.Append(" where MachinePriceID=@MachinePriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4),
					new SqlParameter("@DeviceType", SqlDbType.VarChar,64),
					new SqlParameter("@DeviceDescript", SqlDbType.VarChar,64),
					new SqlParameter("@InternalCost", SqlDbType.Int,4),
					new SqlParameter("@InternalPrice", SqlDbType.Int,4)};
			parameters[0].Value = model.MachinePriceID;
			parameters[1].Value = model.DeviceType;
			parameters[2].Value = model.DeviceDescript;
			parameters[3].Value = model.InternalCost;
			parameters[4].Value = model.InternalPrice;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int MachinePriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Machine_Price ");
			strSql.Append(" where MachinePriceID=@MachinePriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4)};
			parameters[0].Value = MachinePriceID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Machine_Price GetModel(int MachinePriceID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 MachinePriceID,DeviceType,DeviceDescript,InternalCost,InternalPrice from pms_Machine_Price ");
			strSql.Append(" where MachinePriceID=@MachinePriceID ");
			SqlParameter[] parameters = {
					new SqlParameter("@MachinePriceID", SqlDbType.Int,4)};
			parameters[0].Value = MachinePriceID;

			TSM.Model.pms_Machine_Price model=new TSM.Model.pms_Machine_Price();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["MachinePriceID"].ToString()!="")
				{
					model.MachinePriceID=int.Parse(ds.Tables[0].Rows[0]["MachinePriceID"].ToString());
				}
				model.DeviceType=ds.Tables[0].Rows[0]["DeviceType"].ToString();
				model.DeviceDescript=ds.Tables[0].Rows[0]["DeviceDescript"].ToString();
				if(ds.Tables[0].Rows[0]["InternalCost"].ToString()!="")
				{
					model.InternalCost=int.Parse(ds.Tables[0].Rows[0]["InternalCost"].ToString());
				}
				if(ds.Tables[0].Rows[0]["InternalPrice"].ToString()!="")
				{
					model.InternalPrice=int.Parse(ds.Tables[0].Rows[0]["InternalPrice"].ToString());
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
			strSql.Append("select MachinePriceID,DeviceType,DeviceDescript,InternalCost,InternalPrice ");
			strSql.Append(" FROM pms_Machine_Price ");
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
			strSql.Append(" MachinePriceID,DeviceType,DeviceDescript,InternalCost,InternalPrice ");
			strSql.Append(" FROM pms_Machine_Price ");
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
			parameters[0].Value = "pms_Machine_Price";
            parameters[1].Value = "MachinePriceID";
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

