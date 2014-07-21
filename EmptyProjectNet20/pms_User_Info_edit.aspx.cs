using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EmptyProjectNet20
{
    public partial class pms_User_Info_edit : System.Web.UI.Page
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


            int id = GetQueryIntValue("id");
            TSM.Model.pms_User_Info modelpms_User_Info = m_bllpms_User_Info.GetModel(id);

            if (modelpms_User_Info == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
            ddlCompany.SelectedValue = modelpms_User_Info.CompanyInfoID.ToString();
            ddlDept.SelectedValue = modelpms_User_Info.DeptInfoID.ToString();
            ddlPermission.SelectedValue = modelpms_User_Info.PermissionInfoID.ToString();
            tbxName.Text = modelpms_User_Info.UserName;
            tbxMail.Text = modelpms_User_Info.UserMail;      
            tbxPhone.Text = modelpms_User_Info.UserPhone;
            tbxTel.Text = modelpms_User_Info.UserTel;
            tbxPwd.Text = modelpms_User_Info.Pwd;

        }


        #endregion

        #region Events

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.pms_User_Info modelpms_User_Info = m_bllpms_User_Info.GetModel(id);
            modelpms_User_Info.UserName = tbxName.Text.Trim();
            modelpms_User_Info.CompanyInfoID = int.Parse(ddlCompany.SelectedValue);
            modelpms_User_Info.DeptInfoID = int.Parse(ddlDept.SelectedValue);
            modelpms_User_Info.UserMail = tbxMail.Text.Trim();
            modelpms_User_Info.PermissionInfoID = int.Parse(ddlPermission.SelectedValue);
            modelpms_User_Info.UserPhone = tbxPhone.Text.Trim();
            modelpms_User_Info.UserTel = tbxTel.Text.Trim();
            modelpms_User_Info.Pwd = tbxPwd.Text.Trim();

            m_bllpms_User_Info.Update(modelpms_User_Info);

            FineUI.Alert.Show("保存成功！", String.Empty, FineUI.Alert.DefaultMessageBoxIcon, FineUI.ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        #endregion

    }
}