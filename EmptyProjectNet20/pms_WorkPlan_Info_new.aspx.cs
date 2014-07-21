using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Net.Mail;
using System.Configuration;
using FineUI;
using System.Data;
using System.Text;

namespace EmptyProjectNet20
{
    public partial class pms_WorkPlan_Info_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_WorkType m_bllpms_WorkType = new TSM.BLL.pms_WorkType();
        private TSM.BLL.pms_WorkContent m_bllpms_WorkContent = new TSM.BLL.pms_WorkContent();
        private TSM.BLL.pms_User_Info m_bllpms_User_Info = new TSM.BLL.pms_User_Info();
        private TSM.BLL.pms_OutAssistance_WorkPlan m_bllpms_OutAssistance_WorkPlan = new TSM.BLL.pms_OutAssistance_WorkPlan();


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
            DataSet dsType = m_bllpms_WorkType.GetList("");
            DataSet dsCont = m_bllpms_WorkContent.GetList("");
            DataSet dsRept = m_bllpms_User_Info.GetList("");

            ddlType.DataValueField = "WorkTypeID";
            ddlType.DataTextField = "WorkType";
            ddlType.DataSource = dsType.Tables[0];
            ddlType.DataBind();

            ddlCont.DataValueField = "WorkContentID";
            ddlCont.DataTextField = "WorkContent";
            ddlCont.DataSource = dsCont.Tables[0];
            ddlCont.DataBind();

            ddlRept.DataValueField = "UserInfoID";
            ddlRept.DataTextField = "UserName";
            ddlRept.DataSource = dsRept.Tables[0];
            ddlRept.DataBind();

        }

        #endregion

        #region Events

        private void SaveWorkPlan()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            TSM.Model.pms_OutAssistance_WorkPlan modelpms_OutAssistance_WorkPlan = new TSM.Model.pms_OutAssistance_WorkPlan();
            modelpms_OutAssistance_WorkPlan.PlanMonth = da1.Text.ToString();
            modelpms_OutAssistance_WorkPlan.WorkTypeID = int.Parse(ddlType.SelectedValue);
            modelpms_OutAssistance_WorkPlan.WorkContentID = int.Parse(ddlCont.SelectedValue);
            modelpms_OutAssistance_WorkPlan.WorkPlan = txaPlan.Text.ToString();
            modelpms_OutAssistance_WorkPlan.PlanTime = DateTime.Now.Date;
            modelpms_OutAssistance_WorkPlan.PlannerID = int.Parse(uid);
            modelpms_OutAssistance_WorkPlan.Report = "";
            modelpms_OutAssistance_WorkPlan.ReportTime = Convert.ToDateTime("2000-01-01");
            modelpms_OutAssistance_WorkPlan.ReporterID = int.Parse(ddlRept.SelectedValue);
            modelpms_OutAssistance_WorkPlan.Completion = "";
            modelpms_OutAssistance_WorkPlan.Result = "";
            modelpms_OutAssistance_WorkPlan.WorkHour = 0;
            m_bllpms_OutAssistance_WorkPlan.Add(modelpms_OutAssistance_WorkPlan);
        }


        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveWorkPlan();
            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHideReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            sendMail();
        }

        private void sendMail()
        {
            /*
            TSM.Model.pms_OutAssistance_WorkPlan modelpms_Product_Info = m_bllpms_OutAssistance_WorkPlan.GetModel(23);

            /********发送审批结果通知邮件******
            MailMessage mmsg2 = new MailMessage();
            mmsg2.From = new MailAddress("kp.ccz@kocel.com", "生产管理系统", Encoding.UTF8);
            string senderDisplayName = ConfigurationManager.AppSettings["生产管理系统"];//这个配置的是发件人的要显示在邮件的名称 
            mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.营销员邮箱));
            mmsg2.To.Add(new MailAddress("kmc.wsg@kocel.com"));
            mmsg2.To.Add(new MailAddress("kmc.wab@kocel.com"));
            mmsg2.To.Add(new MailAddress("xxx.jsb.xyl@kocel.com"));
            mmsg2.To.Add(new MailAddress("kmc.bcy@kocel.com"));
            mmsg2.CC.Add(new MailAddress("kmc.ll@kocel.com"));
            mmsg2.To.Add(new MailAddress("kp.ccz@kocel.com"));
            mmsg2.Subject = modelpms_Product_Info.图号.ToString().Trim() + "-" + modelpms_Product_Info.产品名称.ToString().Trim() + "-报价通知";
            mmsg2.Body = @"
                    <BODY style= margin:10px; width:1200px; height:900px>
                    <table style= width:1200px; height:900px>
                    <tr>
                    <td colspan=2 style= height:90px>
                    <img src=http://192.168.0.6/pms/res/images/bg_lft.gif alt=12 />
                    </td>
                    </tr>
                    <tr>
                    <td rowspan=2><img src= http://192.168.0.6/pms/res/images/bg_lft3.gif alt=22 />
                    <table style= ""width:570px; height:432px;"">
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>产品名称</td><td>图号</td><td>规范</tr></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center;""><td>" + modelpms_Product_Info.产品名称.ToString().Trim()
                    + "</td><td>" + modelpms_Product_Info.图号.ToString().Trim() + "</td><td>" + modelpms_Product_Info.规范.ToString().Trim() + @"</td></tr>
                    <tr style="" background-color:#FFB90F; text-align:center; font-weight:bolder ""><td>产品结构</td><td>材质</td><td>行业</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center ""><td>" + modelpms_Product_Info.产品结构.ToString().Trim()
                    + "</td><td>" + modelpms_Product_Info.产品材质.ToString().Trim() + "</td><td>" + modelpms_Product_Info.所在行业.ToString().Trim() + @"</td></tr>
                    <tr style="" background-color:#FFB90F; text-align:center; font-weight:bold ""><td>顾客要求</td><td>内部顾客</td><td>最终顾客</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; ""><td>" + modelpms_Product_Info.顾客要求.ToString().Trim()
                    + "</td><td>" + modelpms_Product_Info.顾客名称.ToString().Trim() + "</td><td>" + modelpms_Product_Info.最终客户.ToString().Trim() + @"</td></tr>
                    <tr style="" background-color:#FFB90F; text-align:center; font-weight:bold ""><td>净重(T)</td><td>订单量</td><td></td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; ""><td>" + modelpms_Product_Info.净重.ToString().Trim()
                    + "</td><td>" + modelpms_Product_Info.订单量.ToString().Trim() + @"</td><td></td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; ""><td>备注信息</td><td colspan= 2>" + modelpms_Product_Info.备注.ToString().Trim()
                    + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center ""><td colspan= 3 >请各位领导安排工艺员<a href=""http://192.168.0.6/pms/default.aspx""><span style="" font-weight:bolder; color:Red"">登录系统</span></a>进行报价!</td></tr>
                    </table></td>
                    <td><img src= http://192.168.0.6/pms/res/images/bg_rht2.gif  alt= 22  /></td>
                    </tr>
                    <tr>
                    <td><img src= http://192.168.0.6/pms/res/images/bg_rht1.gif  alt= 22  /></td>
                    </tr>
                    <tr>
                    <td colspan= 2 ><img src= http://192.168.0.6/pms/res/images/bg_btm.gif  alt= 22  /></td>
                    </tr>
                    </table>                  
                    </BODY> ";
            mmsg2.IsBodyHtml = true;
            SmtpClient msclient2 = new SmtpClient();
            msclient2.Host = "192.168.0.10";
            msclient2.DeliveryMethod = SmtpDeliveryMethod.Network;
            msclient2.Credentials = new System.Net.NetworkCredential("kp.ccz", "lan@2mail");
            try
            {
                msclient2.Send(mmsg2);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {

            }
            /****/
        }

        #endregion
    }
}