using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Security;

namespace FineUIDemo
{
    public partial class main : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                leftTree.DataSource = XmlDataSource1;
                leftTree.DataBind();
                lbdate.Text = "当前时间:" + DateTime.Now;
                lbname.Text = "欢迎您:" + HttpContext.Current.User.Identity.Name;
            }
        }
        protected void btnlogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/main.aspx");
        }
    }
}