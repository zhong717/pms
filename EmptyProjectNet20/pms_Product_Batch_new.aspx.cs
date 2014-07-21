using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Batch_new : System.Web.UI.Page
    {

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

        private void LoadData()
        {


            btnClose.OnClientClick = ActiveWindow.GetHideReference();
            DataSet dsCom = m_bllpms_Company_Info.GetList("");
            DataSet dsContact = m_bllpms_User_Info.GetList("");
            ddlCompany.DataValueField = "CompanyInfoID";
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataSource = dsCom.Tables[0];
            ddlCompany.DataBind();

            ddlFinCostum.DataValueField = "CompanyInfoID";
            ddlFinCostum.DataTextField = "CompanyName";
            ddlFinCostum.DataSource = dsCom.Tables[0];
            ddlFinCostum.DataBind();

            ddlBisContact.DataValueField = "UserInfoID";
            ddlBisContact.DataTextField = "UserName";
            ddlBisContact.DataSource = dsContact.Tables[0];
            ddlBisContact.DataBind();

            ddlQuaContact.DataValueField = "UserInfoID";
            ddlQuaContact.DataTextField = "UserName";
            ddlQuaContact.DataSource = dsContact.Tables[0];
            ddlQuaContact.DataBind();

        }

        #endregion

        #region Events

        private void SaveProductType()
        {
            TSM.Model.pms_Product_Batch modelpms_Product_Batch = new TSM.Model.pms_Product_Batch();
            modelpms_Product_Batch.ProductBatchName = tbxBatchName.Text.Trim();
            modelpms_Product_Batch.CustomerInfoID = int.Parse(ddlCompany.SelectedValue);
            modelpms_Product_Batch.FinalCustInfoID = int.Parse(ddlFinCostum.SelectedValue);
            modelpms_Product_Batch.BisnessContactID = int.Parse(ddlBisContact.SelectedValue);
            modelpms_Product_Batch.QualityContactID = int.Parse(ddlQuaContact.SelectedValue);
            modelpms_Product_Batch.ProductDate = DateTime.Now.Date;
            m_bllpms_Product_Batch.Add(modelpms_Product_Batch);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProductType();

            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }
        #endregion
    }
}