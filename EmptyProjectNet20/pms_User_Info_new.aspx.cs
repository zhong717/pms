using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FineUI;
using System.Data;

namespace EmptyProjectNet20
{
    public partial class pms_User_Info_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_User_Info m_bllpms_User_Info = new TSM.BLL.pms_User_Info();
        private TSM.BLL.pms_Company_Info m_bllpms_Company_Info = new TSM.BLL.pms_Company_Info();
        private TSM.BLL.pms_Permission_Info m_bllpms_Permission_Info = new TSM.BLL.pms_Permission_Info();
        private TSM.BLL.pms_Dept_Info m_bllpms_Dept_Info_Info = new TSM.BLL.pms_Dept_Info();


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
            DataSet dsDept = m_bllpms_Dept_Info_Info.GetList("");
            DataSet dsPerm = m_bllpms_Permission_Info.GetList("");
            ddlCompany.DataValueField = "CompanyInfoID";
            ddlCompany.DataTextField = "CompanyName";
            ddlCompany.DataSource = dsCom.Tables[0];
            ddlCompany.DataBind();

            ddlPermission.DataValueField = "PermissionInfoID";
            ddlPermission.DataTextField = "Permission";
            ddlPermission.DataSource = dsPerm.Tables[0];
            ddlPermission.DataBind();

            ddlDept.DataValueField = "DeptInfoID";
            ddlDept.DataTextField = "DeptName";
            ddlDept.DataSource = dsDept.Tables[0];
            ddlDept.DataBind();

        }

        #endregion

        #region Events

        private void SaveProductType()
        {
            TSM.Model.pms_User_Info modelpms_User_Info = new TSM.Model.pms_User_Info();
            modelpms_User_Info.UserName = tbxName.Text.Trim();
            modelpms_User_Info.CompanyInfoID = int.Parse(ddlCompany.SelectedValue);
            modelpms_User_Info.DeptInfoID = int.Parse(ddlDept.SelectedValue);
            modelpms_User_Info.UserMail = tbxMail.Text.Trim();
            modelpms_User_Info.PermissionInfoID = int.Parse(ddlPermission.SelectedValue);
            modelpms_User_Info.UserPhone = tbxPhone.Text.Trim();
            modelpms_User_Info.UserTel = tbxTel.Text.Trim();
            modelpms_User_Info.Pwd = tbxPwd.Text.Trim();
            m_bllpms_User_Info.Add(modelpms_User_Info);

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