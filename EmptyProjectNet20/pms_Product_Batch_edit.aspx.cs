using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Batch_edit : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Info m_bllpms_Product_Info = new TSM.BLL.pms_Product_Info();
        private TSM.BLL.pms_Product_Batch m_bllpms_Product_Batch = new TSM.BLL.pms_Product_Batch();
        private TSM.BLL.pms_Company_Info m_bllpms_Company_Info = new TSM.BLL.pms_Company_Info();
        private TSM.BLL.pms_User_Info m_bllpms_User_Info = new TSM.BLL.pms_User_Info();

        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected int GetQueryIntValue(string queryKey)
        {
            int queryIntValue = -1;
            try
            {
                queryIntValue = Convert.ToInt32(Request.QueryString[queryKey]);
            }
            catch (Exception)
            {
                // TODO
            }

            return queryIntValue;
        }

        private void LoadData()
        {            
            //绑定三个下拉列表控件
            DataSet dsCom = m_bllpms_Company_Info.GetList("");
            DataSet dsContact = m_bllpms_User_Info.GetList("");

            ddlCompany.DataValueField = "CompanyInfoID";
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataSource = dsCom.Tables[0];
            ddlCompany.DataBind();

            ddlFinCustom.DataValueField = "CompanyInfoID";
            ddlFinCustom.DataTextField = "CompanyName";
            ddlFinCustom.DataSource = dsCom.Tables[0];
            ddlFinCustom.DataBind();

            ddlBisContact.DataValueField = "UserInfoID";
            ddlBisContact.DataTextField = "UserName";
            ddlBisContact.DataSource = dsContact.Tables[0];
            ddlBisContact.DataBind();

            ddlQuaContact.DataValueField = "UserInfoID";
            ddlQuaContact.DataTextField = "UserName";
            ddlQuaContact.DataSource = dsContact.Tables[0];
            ddlQuaContact.DataBind();

            //// 默认的排序列和排序方向
            //Grid1.SortColumnIndex = 0;
            //Grid1.SortDirection = "DESC";

            // 每页记录数
            Grid1.PageSize = 15;

            //// 点击删除按钮时，至少选中一项
            //ResolveDeleteGridItem(btnDeleteSelected, Grid1);

            int id = GetQueryIntValue("id");
            TSM.Model.pms_Product_Batch modelpms_Product_Batch = m_bllpms_Product_Batch.GetModel(id);

            if (modelpms_Product_Batch == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            //给控件赋初值,显示
            lbBatchID.Text = modelpms_Product_Batch.ProductBatchID.ToString().Trim();
            tbxBatchName.Text = modelpms_Product_Batch.ProductBatchName.ToString().Trim();
            ddlBisContact.SelectedValue = modelpms_Product_Batch.BisnessContactID.ToString().Trim();
            ddlQuaContact.SelectedValue = modelpms_Product_Batch.QualityContactID.ToString().Trim();
            ddlCompany.SelectedValue = modelpms_Product_Batch.CustomerInfoID.ToString().Trim();
            ddlFinCustom.SelectedValue = modelpms_Product_Batch.FinalCustInfoID.ToString().Trim();
            //绑定表格
            BindGrid();

            //父窗口向子窗口传值
            string BatchId = lbBatchID.Text.ToString().Trim();
            btnNew.OnClientClick = Window1.GetShowReference("~/pms_Product_Info_new.aspx?id=" + BatchId, "添加新产品");
        }

        private void BindGrid()
        {
            DataSet ds;
            string strWhere = "ProductBatchID='" + lbBatchID.Text +"'";
            ds = m_bllpms_Product_Info.GetList(strWhere);
            // 在查询添加之后，排序和分页之前获取总记录数
            // Grid1总共有多少条记录
            Grid1.RecordCount = ds.Tables[0].Rows.Count;

            ds = m_bllpms_Product_Info.GetList(Grid1.PageSize, Grid1.PageIndex + 1, strWhere);


            Grid1.DataSource = ds.Tables[0];
            Grid1.DataBind();
        }

        #endregion

        #region Events


        protected void Grid1_PreDataBound(object sender, EventArgs e)
        {
            // 数据绑定之前，进行权限检查
            //CheckPowerEditWithWindowField(Grid1, "editField");
            //CheckPowerDeleteWithLinkButtonField(Grid1, "deleteField");
        }


        protected void Grid1_Sort(object sender, GridSortEventArgs e)
        {
            Grid1.SortColumnIndex = e.ColumnIndex;
            BindGrid();
        }

        protected void Grid1_PageIndexChange(object sender, GridPageEventArgs e)
        {
            Grid1.PageIndex = e.NewPageIndex;
            BindGrid();
        }

        //protected void btnDeleteSelected_Click(object sender, EventArgs e)
        //{
        //    // 在操作之前进行权限检查
        //    if (!CheckPowerDelete())
        //    {
        //        CheckPowerFailWithAlert();
        //        return;
        //    }

        //    // 从每个选中的行中获取ID（在Grid1中定义的DataKeyNames）
        //    List<int> ids = GetSelectedDataKeyIDs(Grid1);

        //    // 执行数据库操作
        //    new Delete().From<XJobTitle>()
        //         .Where(XJobTitle.IdColumn).In(ids)
        //         .Execute();

        //    //// 清空当前选中的项
        //    //Grid1.SelectedRowIndexArray = null;

        //    // 重新绑定表格
        //    BindGrid();
        //}

        protected void Grid1_RowCommand(object sender, GridCommandEventArgs e)
        {
            int id = Convert.ToInt32(Grid1.DataKeys[e.RowIndex][0]);

            if (e.CommandName == "Delete")
            {

                try
                {

                    m_bllpms_Product_Info.Delete(id);
                    BindGrid();


                }
                catch (Exception ex)
                {
                    Alert.ShowInTop(ex.ToString());
                    return;
                }


            }
        }

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProductType();

            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveProductType()
        {
            TSM.Model.pms_Product_Batch modelpms_Product_Batch = new TSM.Model.pms_Product_Batch();
            modelpms_Product_Batch.ProductBatchName = tbxBatchName.Text.Trim();
            modelpms_Product_Batch.BisnessContactID = int.Parse(ddlBisContact.SelectedValue);
            modelpms_Product_Batch.QualityContactID = int.Parse(ddlQuaContact.SelectedValue);
            modelpms_Product_Batch.CustomerInfoID = int.Parse(ddlCompany.SelectedValue);
            modelpms_Product_Batch.FinalCustInfoID = int.Parse(ddlFinCustom.SelectedValue);
            modelpms_Product_Batch.ProductDate = DateTime.Now.Date;
            modelpms_Product_Batch.ProductBatchID = int.Parse(lbBatchID.Text);
            m_bllpms_Product_Batch.Update(modelpms_Product_Batch);

            FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultMessageBoxIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion
    }
}