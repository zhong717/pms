using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using FineUI;
using System.Security.Principal;
using System.Text;
using System.Data.SqlClient;
using TSM.Model;
using System.Data;


namespace FineUIDemo
{
    public partial class _default : Page
    {
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

            // 如果用户已经登录，则重定向到管理首页
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect(FormsAuthentication.DefaultUrl);
            }
            DataSet dsContact = m_bllpms_User_Info.GetList("");
            ddlUname.DataValueField = "UserInfoID";
            ddlUname.DataTextField = "UserName";
            ddlUname.DataSource = dsContact.Tables[0];
            ddlUname.DataBind();
            Window1.Title = String.Format("系统登录（生产管理系统）");
        }

        #endregion

        #region Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            string userName = ddlUname.SelectedText;
            string password = tbxPassword.Text;

            pms_User_Info user = new pms_User_Info();
            TSM.Model.pms_User_Info modelpms_User_Info = m_bllpms_User_Info.GetModel(userName, password);

            if (modelpms_User_Info == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("输入的用户名或密码有误，请重新输入！", String.Empty, ActiveWindow.GetHideRefreshReference());
                return;
            }
            else
            {
                string id = modelpms_User_Info.UserInfoID.ToString();
                string uname = modelpms_User_Info.UserName.ToString();
                LoginSuccess(id,uname);
                return;
            }
            
        }


        private void LoginSuccess(string id,string uname)
        {
            

            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, 
                uname, 
                DateTime.Now,
                DateTime.Now.AddMinutes(120), 
                true,
                id, 
                FormsAuthentication.FormsCookiePath);
            string hashTicket = FormsAuthentication.Encrypt(ticket);
            HttpCookie userCookie = new HttpCookie(FormsAuthentication.FormsCookieName, hashTicket);
            userCookie.HttpOnly = true;
            userCookie.Expires = DateTime.Now.AddMinutes(120);
            Response.Cookies.Add(userCookie);
        
            Response.Redirect(FormsAuthentication.DefaultUrl);
        }


        #endregion
    }
}
