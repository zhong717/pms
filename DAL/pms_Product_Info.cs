using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace TSM.DAL
{
	/// <summary>
	/// 数据访问类pms_Product_Info。
	/// </summary>
	public class pms_Product_Info
	{
		public pms_Product_Info()
		{}
		#region  成员方法

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("ProductInfoID", "pms_Product_Info"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ProductInfoID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from pms_Product_Info");
			strSql.Append(" where ProductInfoID=@ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ProductInfoID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(TSM.Model.pms_Product_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into pms_Product_Info(");
			strSql.Append("ProductBatchID,CustomerRequireID,ProductTypeID,ProductStrucID,ProductMaterID,ProductIndustID,ProductInfoName,ProductPhotoNum,ProductStandard,ProductWeight,OrderQuantity,ContourSize,Remarks)");
			strSql.Append(" values (");
			strSql.Append("@ProductBatchID,@CustomerRequireID,@ProductTypeID,@ProductStrucID,@ProductMaterID,@ProductIndustID,@ProductInfoName,@ProductPhotoNum,@ProductStandard,@ProductWeight,@OrderQuantity,@ContourSize,@Remarks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4),
					new SqlParameter("@CustomerRequireID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProductStrucID", SqlDbType.Int,4),
					new SqlParameter("@ProductMaterID", SqlDbType.Int,4),
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4),
					new SqlParameter("@ProductInfoName", SqlDbType.VarChar,64),
					new SqlParameter("@ProductPhotoNum", SqlDbType.VarChar,64),
					new SqlParameter("@ProductStandard", SqlDbType.VarChar,64),
					new SqlParameter("@ProductWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OrderQuantity", SqlDbType.VarChar,64),
					new SqlParameter("@ContourSize", SqlDbType.VarChar,144),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.ProductBatchID;
			parameters[1].Value = model.CustomerRequireID;
			parameters[2].Value = model.ProductTypeID;
			parameters[3].Value = model.ProductStrucID;
			parameters[4].Value = model.ProductMaterID;
			parameters[5].Value = model.ProductIndustID;
			parameters[6].Value = model.ProductInfoName;
			parameters[7].Value = model.ProductPhotoNum;
			parameters[8].Value = model.ProductStandard;
			parameters[9].Value = model.ProductWeight;
			parameters[10].Value = model.OrderQuantity;
			parameters[11].Value = model.ContourSize;
			parameters[12].Value = model.Remarks;

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
		public void Update(TSM.Model.pms_Product_Info model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update pms_Product_Info set ");
			strSql.Append("ProductBatchID=@ProductBatchID,");
			strSql.Append("CustomerRequireID=@CustomerRequireID,");
			strSql.Append("ProductTypeID=@ProductTypeID,");
			strSql.Append("ProductStrucID=@ProductStrucID,");
			strSql.Append("ProductMaterID=@ProductMaterID,");
			strSql.Append("ProductIndustID=@ProductIndustID,");
			strSql.Append("ProductInfoName=@ProductInfoName,");
			strSql.Append("ProductPhotoNum=@ProductPhotoNum,");
			strSql.Append("ProductStandard=@ProductStandard,");
			strSql.Append("ProductWeight=@ProductWeight,");
			strSql.Append("OrderQuantity=@OrderQuantity,");
			strSql.Append("ContourSize=@ContourSize,");
			strSql.Append("Remarks=@Remarks");
			strSql.Append(" where ProductInfoID=@ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductInfoID", SqlDbType.Int,4),
					new SqlParameter("@ProductBatchID", SqlDbType.Int,4),
					new SqlParameter("@CustomerRequireID", SqlDbType.Int,4),
					new SqlParameter("@ProductTypeID", SqlDbType.Int,4),
					new SqlParameter("@ProductStrucID", SqlDbType.Int,4),
					new SqlParameter("@ProductMaterID", SqlDbType.Int,4),
					new SqlParameter("@ProductIndustID", SqlDbType.Int,4),
					new SqlParameter("@ProductInfoName", SqlDbType.VarChar,64),
					new SqlParameter("@ProductPhotoNum", SqlDbType.VarChar,64),
					new SqlParameter("@ProductStandard", SqlDbType.VarChar,64),
					new SqlParameter("@ProductWeight", SqlDbType.Decimal,9),
					new SqlParameter("@OrderQuantity", SqlDbType.VarChar,64),
					new SqlParameter("@ContourSize", SqlDbType.VarChar,144),
					new SqlParameter("@Remarks", SqlDbType.Text)};
			parameters[0].Value = model.ProductInfoID;
			parameters[1].Value = model.ProductBatchID;
			parameters[2].Value = model.CustomerRequireID;
			parameters[3].Value = model.ProductTypeID;
			parameters[4].Value = model.ProductStrucID;
			parameters[5].Value = model.ProductMaterID;
			parameters[6].Value = model.ProductIndustID;
			parameters[7].Value = model.ProductInfoName;
			parameters[8].Value = model.ProductPhotoNum;
			parameters[9].Value = model.ProductStandard;
			parameters[10].Value = model.ProductWeight;
			parameters[11].Value = model.OrderQuantity;
			parameters[12].Value = model.ContourSize;
			parameters[13].Value = model.Remarks;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(int ProductInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from pms_Product_Info ");
			strSql.Append(" where ProductInfoID=@ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ProductInfoID;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public TSM.Model.pms_Product_Info GetModel(int ProductInfoID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ProductInfoID,ProductBatchID,CustomerRequireID,ProductTypeID,ProductStrucID,ProductMaterID,ProductIndustID,ProductInfoName,ProductPhotoNum,ProductStandard,ProductWeight,OrderQuantity,ContourSize,Remarks from pms_Product_Info ");
			strSql.Append(" where ProductInfoID=@ProductInfoID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ProductInfoID", SqlDbType.Int,4)};
			parameters[0].Value = ProductInfoID;

			TSM.Model.pms_Product_Info model=new TSM.Model.pms_Product_Info();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ProductInfoID"].ToString()!="")
				{
					model.ProductInfoID=int.Parse(ds.Tables[0].Rows[0]["ProductInfoID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductBatchID"].ToString()!="")
				{
					model.ProductBatchID=int.Parse(ds.Tables[0].Rows[0]["ProductBatchID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["CustomerRequireID"].ToString()!="")
				{
					model.CustomerRequireID=int.Parse(ds.Tables[0].Rows[0]["CustomerRequireID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductTypeID"].ToString()!="")
				{
					model.ProductTypeID=int.Parse(ds.Tables[0].Rows[0]["ProductTypeID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductStrucID"].ToString()!="")
				{
					model.ProductStrucID=int.Parse(ds.Tables[0].Rows[0]["ProductStrucID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductMaterID"].ToString()!="")
				{
					model.ProductMaterID=int.Parse(ds.Tables[0].Rows[0]["ProductMaterID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["ProductIndustID"].ToString()!="")
				{
					model.ProductIndustID=int.Parse(ds.Tables[0].Rows[0]["ProductIndustID"].ToString());
				}
				model.ProductInfoName=ds.Tables[0].Rows[0]["ProductInfoName"].ToString();
				model.ProductPhotoNum=ds.Tables[0].Rows[0]["ProductPhotoNum"].ToString();
				model.ProductStandard=ds.Tables[0].Rows[0]["ProductStandard"].ToString();
				if(ds.Tables[0].Rows[0]["ProductWeight"].ToString()!="")
				{
					model.ProductWeight=decimal.Parse(ds.Tables[0].Rows[0]["ProductWeight"].ToString());
				}
				model.OrderQuantity=ds.Tables[0].Rows[0]["OrderQuantity"].ToString();
				model.ContourSize=ds.Tables[0].Rows[0]["ContourSize"].ToString();
				model.Remarks=ds.Tables[0].Rows[0]["Remarks"].ToString();
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public TSM.Model.pms_Product_Info GetViewModel(int ProductInfoID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  * from view_pms_Product_Info ");
            strSql.Append(" where ProductInfoID=@ProductInfoID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ProductInfoID", SqlDbType.Int,4)};
            parameters[0].Value = ProductInfoID;

            TSM.Model.pms_Product_Info model = new TSM.Model.pms_Product_Info();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ProductInfoID"].ToString() != "")
                {
                    model.ProductInfoID = int.Parse(ds.Tables[0].Rows[0]["ProductInfoID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProductBatchID"].ToString() != "")
                {
                    model.ProductBatchID = int.Parse(ds.Tables[0].Rows[0]["ProductBatchID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["批次名称"].ToString() != "")
                {
                    model.批次名称 = ds.Tables[0].Rows[0]["批次名称"].ToString();
                }
                model.产品名称 = ds.Tables[0].Rows[0]["产品名称"].ToString();
                model.顾客类型 = ds.Tables[0].Rows[0]["顾客类型"].ToString();
                model.顾客名称 = ds.Tables[0].Rows[0]["顾客名称"].ToString();
                model.顾客要求 = ds.Tables[0].Rows[0]["顾客要求"].ToString();
                model.产品结构 = ds.Tables[0].Rows[0]["产品结构"].ToString();
                model.产品材质 = ds.Tables[0].Rows[0]["产品材质"].ToString();
                model.所在行业 = ds.Tables[0].Rows[0]["所在行业"].ToString();
                model.图号 = ds.Tables[0].Rows[0]["图号"].ToString();
                model.规范 = ds.Tables[0].Rows[0]["规范"].ToString();
                model.净重 = ds.Tables[0].Rows[0]["净重"].ToString();
                model.日期 = ds.Tables[0].Rows[0]["日期"].ToString();
                model.订单量 = ds.Tables[0].Rows[0]["订单量"].ToString();
                model.备注 = ds.Tables[0].Rows[0]["备注"].ToString();
                model.附件名称 = ds.Tables[0].Rows[0]["附件名称"].ToString();
                model.附件地址 = ds.Tables[0].Rows[0]["附件地址"].ToString();
                model.上传节点 = ds.Tables[0].Rows[0]["上传节点"].ToString();
                model.上传时间 = ds.Tables[0].Rows[0]["上传时间"].ToString();
                model.上传人 = ds.Tables[0].Rows[0]["上传人"].ToString();
                model.商务联系人 = ds.Tables[0].Rows[0]["商务联系人"].ToString();
                model.商务联系电话 = ds.Tables[0].Rows[0]["商务联系电话"].ToString();
                model.商务联系邮箱 = ds.Tables[0].Rows[0]["商务联系邮箱"].ToString();
                model.质量联系人 = ds.Tables[0].Rows[0]["质量联系人"].ToString();
                model.质量联系电话 = ds.Tables[0].Rows[0]["质量联系电话"].ToString();
                model.质量联系邮箱 = ds.Tables[0].Rows[0]["质量联系邮箱"].ToString();
                model.ApprovalStatus = ds.Tables[0].Rows[0]["ApprovalStatus"].ToString();
                model.QuotationInfoID = int.Parse(ds.Tables[0].Rows[0]["QuotationInfoID"].ToString());
                model.最终客户 = ds.Tables[0].Rows[0]["最终客户"].ToString();
                model.报价人 = ds.Tables[0].Rows[0]["报价人"].ToString();
                model.报价邮箱 = ds.Tables[0].Rows[0]["报价邮箱"].ToString();
                model.营销员邮箱 = ds.Tables[0].Rows[0]["营销员邮箱"].ToString();
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
            strSql.Append(" FROM view_pms_Product_Info_Final ");
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
			strSql.Append(" ProductInfoID,ProductBatchID,CustomerRequireID,ProductTypeID,ProductStrucID,ProductMaterID,ProductIndustID,ProductInfoName,ProductPhotoNum,ProductStandard,ProductWeight,OrderQuantity,ContourSize,Remarks ");
			strSql.Append(" FROM pms_Product_Info ");
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
            parameters[0].Value = "view_pms_Product_Info_Final";
            parameters[1].Value = "ProductInfoID";
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

