using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_User_Info。
	/// </summary>
	public class pms_User_Info
	{
		public pms_User_Info()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("UserInfoID", "pms_User_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int UserInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_User_Info");
			strSql.Append(" where UserInfoID=@UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.Int,4)};
			parameters[0].Value = UserInfoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_User_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_User_Info(");
			strSql.Append("UserName,Pwd,CompanyInfoID,DeptInfoID,PermissionInfoID,UserTel,UserPhone,UserMail)");
			strSql.Append(" values (");
			strSql.Append("@UserName,@Pwd,@CompanyInfoID,@DeptInfoID,@PermissionInfoID,@UserTel,@UserPhone,@UserMail)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
					new SqlParameter("@Pwd", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4),
					new SqlParameter("@DeptInfoID", SqlDbType.Int,4),
					new SqlParameter("@PermissionInfoID", SqlDbType.Int,4),
					new SqlParameter("@UserTel", SqlDbType.VarChar,64),
					new SqlParameter("@UserPhone", SqlDbType.VarChar,64),
					new SqlParameter("@UserMail", SqlDbType.VarChar,64)};
			parameters[0].Value = model.UserName;
			parameters[1].Value = model.Pwd;
			parameters[2].Value = model.CompanyInfoID;
			parameters[3].Value = model.DeptInfoID;
			parameters[4].Value = model.PermissionInfoID;
			parameters[5].Value = model.UserTel;
			parameters[6].Value = model.UserPhone;
			parameters[7].Value = model.UserMail;

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
		public void Update(TSM.Model.pms_User_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_User_Info set ");
			strSql.Append("UserName=@UserName,");
			strSql.Append("Pwd=@Pwd,");
			strSql.Append("CompanyInfoID=@CompanyInfoID,");
			strSql.Append("DeptInfoID=@DeptInfoID,");
			strSql.Append("PermissionInfoID=@PermissionInfoID,");
			strSql.Append("UserTel=@UserTel,");
			strSql.Append("UserPhone=@UserPhone,");
			strSql.Append("UserMail=@UserMail");
			strSql.Append(" where UserInfoID=@UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
					new SqlParameter("@Pwd", SqlDbType.VarChar,64),
					new SqlParameter("@CompanyInfoID", SqlDbType.Int,4),
					new SqlParameter("@DeptInfoID", SqlDbType.Int,4),
					new SqlParameter("@PermissionInfoID", SqlDbType.Int,4),
					new SqlParameter("@UserTel", SqlDbType.VarChar,64),
					new SqlParameter("@UserPhone", SqlDbType.VarChar,64),
					new SqlParameter("@UserMail", SqlDbType.VarChar,64)};
			parameters[0].Value = model.UserInfoID;
			parameters[1].Value = model.UserName;
			parameters[2].Value = model.Pwd;
			parameters[3].Value = model.CompanyInfoID;
			parameters[4].Value = model.DeptInfoID;
			parameters[5].Value = model.PermissionInfoID;
			parameters[6].Value = model.UserTel;
			parameters[7].Value = model.UserPhone;
			parameters[8].Value = model.UserMail;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int UserInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_User_Info ");
			strSql.Append(" where UserInfoID=@UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.Int,4)};
			parameters[0].Value = UserInfoID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_User_Info GetModel(int UserInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 UserInfoID,UserName,Pwd,CompanyInfoID,DeptInfoID,PermissionInfoID,UserTel,UserPhone,UserMail from pms_User_Info ");
			strSql.Append(" where UserInfoID=@UserInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@UserInfoID", SqlDbType.Int,4)};
			parameters[0].Value = UserInfoID;

			TSM.Model.pms_User_Info model=new TSM.Model.pms_User_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["UserInfoID"].ToString()!="")
				{
					model.UserInfoID=int.Parse(ds.Tables[0].Rows[0]["UserInfoID"].ToString());
				}
				model.UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				model.Pwd=ds.Tables[0].Rows[0]["Pwd"].ToString();
				if(ds.Tables[0].Rows[0]["CompanyInfoID"].ToString()!="")
				{
					model.CompanyInfoID=int.Parse(ds.Tables[0].Rows[0]["CompanyInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["DeptInfoID"].ToString()!="")
				{
					model.DeptInfoID=int.Parse(ds.Tables[0].Rows[0]["DeptInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["PermissionInfoID"].ToString()!="")
				{
					model.PermissionInfoID=int.Parse(ds.Tables[0].Rows[0]["PermissionInfoID"].ToString());
				}
				model.UserTel=ds.Tables[0].Rows[0]["UserTel"].ToString();
				model.UserPhone=ds.Tables[0].Rows[0]["UserPhone"].ToString();
				model.UserMail=ds.Tables[0].Rows[0]["UserMail"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体(登录名,密码)
        /// </summary>
        public TSM.Model.pms_User_Info GetModel(string sUserName, string sPassword)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 UserInfoID,UserName,Pwd,CompanyInfoID,DeptInfoID,PermissionInfoID,UserTel,UserPhone,UserMail from pms_User_Info ");
            strSql.Append("where UserName=@UserName and  Pwd=@Password");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,64),
                    new SqlParameter("@Password",SqlDbType.VarChar,64)};
            parameters[0].Value = sUserName;
            parameters[1].Value = sPassword;
            TSM.Model.pms_User_Info model = new TSM.Model.pms_User_Info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["UserInfoID"].ToString() != "")
                {
                    model.UserInfoID = int.Parse(ds.Tables[0].Rows[0]["UserInfoID"].ToString());
                }
                model.UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                model.Pwd = ds.Tables[0].Rows[0]["Pwd"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyInfoID"].ToString() != "")
                {
                    model.CompanyInfoID = int.Parse(ds.Tables[0].Rows[0]["CompanyInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["DeptInfoID"].ToString() != "")
                {
                    model.DeptInfoID = int.Parse(ds.Tables[0].Rows[0]["DeptInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PermissionInfoID"].ToString() != "")
                {
                    model.PermissionInfoID = int.Parse(ds.Tables[0].Rows[0]["PermissionInfoID"].ToString());
                }
                model.UserTel = ds.Tables[0].Rows[0]["UserTel"].ToString();
                model.UserPhone = ds.Tables[0].Rows[0]["UserPhone"].ToString();
                model.UserMail = ds.Tables[0].Rows[0]["UserMail"].ToString();
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
			strSql.Append(" FROM view_pms_User_Info ");
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
			strSql.Append(" UserInfoID,UserName,Pwd,CompanyInfoID,DeptInfoID,PermissionInfoID,UserTel,UserPhone,UserMail ");
			strSql.Append(" FROM pms_User_Info ");
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
			parameters[0].Value = "view_pms_User_Info";
            parameters[1].Value = "UserInfoID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}

      public DataSet GetUserLogin(string sUserName, string sPassword)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from pms_User_Info ");
            strSql.Append("where UserName='" + sUserName + "' and  Pwd='" + sPassword + "'");
            return DbHelperSQL.Query(strSql.ToString());
        }
      
        #endregion  成员方法
    }
}

