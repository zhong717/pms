using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using System.Web.Security;
using System.Net.Mail;
using System.Text;
using System.Configuration;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Info_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Type m_bllpms_Product_Type = new TSM.BLL.pms_Product_Type();
        private TSM.BLL.pms_Product_Struc m_bllpms_Product_Struc = new TSM.BLL.pms_Product_Struc();
        private TSM.BLL.pms_Product_Mater m_bllpms_Product_Mater = new TSM.BLL.pms_Product_Mater();
        private TSM.BLL.pms_Product_Indust m_bllpms_Product_Indust = new TSM.BLL.pms_Product_Indust();
        private TSM.BLL.pms_Customer_Require m_bllpms_Customer_Require = new TSM.BLL.pms_Customer_Require();
        private TSM.BLL.pms_Product_Info m_bllpms_Product_Info = new TSM.BLL.pms_Product_Info();
        //private TSM.BLL.pms_Quotation_Info m_bllpms_Quotation_Info = new TSM.BLL.pms_Quotation_Info();


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
            DataSet dsReq = m_bllpms_Customer_Require.GetList("");
            DataSet dsStr = m_bllpms_Product_Struc.GetList("");
            DataSet dsMet = m_bllpms_Product_Mater.GetList("");
            DataSet dsInd = m_bllpms_Product_Indust.GetList("");
            DataSet dsTyp = m_bllpms_Product_Type.GetList("");
            ddlReq.DataValueField = "CustomerRequireID";
            ddlReq.DataTextField = "CustomerRequire";
            ddlReq.DataSource = dsReq.Tables[0];
            ddlReq.DataBind();

            ddlStr.DataValueField = "ProductStrucID";
            ddlStr.DataTextField = "ProductStruc";
            ddlStr.DataSource = dsStr.Tables[0];
            ddlStr.DataBind();

            ddlMet.DataValueField = "ProductMaterID";
            ddlMet.DataTextField = "ProductMater";
            ddlMet.DataSource = dsMet.Tables[0];
            ddlMet.DataBind();

            ddlInd.DataValueField = "ProductIndustID";
            ddlInd.DataTextField = "ProductIndust";
            ddlInd.DataSource = dsInd.Tables[0];
            ddlInd.DataBind();
        }

        #endregion

        #region Events

        private void SaveProductType()
        {
            TSM.Model.pms_Product_Info modelpms_Product_Info = new TSM.Model.pms_Product_Info();
            modelpms_Product_Info.ProductBatchID = GetQueryIntValue("id");
            modelpms_Product_Info.ProductTypeID = 2;
            modelpms_Product_Info.ProductIndustID = int.Parse(ddlInd.SelectedValue);
            modelpms_Product_Info.ProductMaterID = int.Parse(ddlMet.SelectedValue);
            modelpms_Product_Info.ProductStrucID = int.Parse(ddlStr.SelectedValue);
            modelpms_Product_Info.CustomerRequireID = int.Parse(ddlReq.SelectedValue);
            modelpms_Product_Info.ProductInfoName = tbxProName.Text.Trim();
            modelpms_Product_Info.ProductPhotoNum = tbxPic.Text.Trim();
            modelpms_Product_Info.ProductStandard = tbxSta.Text.Trim();
            modelpms_Product_Info.ProductWeight = Convert.ToDecimal(tbxWei.Text);
            modelpms_Product_Info.OrderQuantity = tbxOrd.Text.Trim();
            modelpms_Product_Info.Remarks = tbxRem.Text.Trim();

            m_bllpms_Product_Info.Add(modelpms_Product_Info); 
        }

        private void SaveQuatation_Info()
            {
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                string uid = ticket.UserData;
                TSM.BLL.pms_Quotation_Info m_bllpms_Quotation_Info = new TSM.BLL.pms_Quotation_Info();
                TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = new TSM.Model.pms_Quotation_Info();
                modelpms_Quotation_Info.ProductInfoID = m_bllpms_Product_Info.GetMaxId()-1;
                modelpms_Quotation_Info.QuotationDepart = 1;
                modelpms_Quotation_Info.QuotationTime = DateTime.Now.Date;
                modelpms_Quotation_Info.KnifeCharges = 0;
                modelpms_Quotation_Info.ToolCharges = 0;
                modelpms_Quotation_Info.SprayingCharges = 0;
                modelpms_Quotation_Info.PackingCharges = 0;
                modelpms_Quotation_Info.TestingCharges = 0;
                modelpms_Quotation_Info.TransportCharges = 0;
                modelpms_Quotation_Info.QuotationPrice = 0;
                modelpms_Quotation_Info.ApprovalStatus = "待报价";
                modelpms_Quotation_Info.UserInfoID = int.Parse(uid);
                modelpms_Quotation_Info.TransportDescrib = "";
                modelpms_Quotation_Info.TestingDescrib = "";
                modelpms_Quotation_Info.ChargeDescrib = "";
                modelpms_Quotation_Info.SprayingDescrib = "";
                modelpms_Quotation_Info.ToolsDescrib = "";
                modelpms_Quotation_Info.KinfeDescrib = "";
                modelpms_Quotation_Info.PackingDescrib = "";
                m_bllpms_Quotation_Info.Add(modelpms_Quotation_Info);
            }
         

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProductType();
            SaveAttachment();
            SaveQuatation_Info();
            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHideReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
            sendMail();

           
        }

        private void sendMail()
        {
            int id = m_bllpms_Product_Info.GetMaxId() - 1;
            TSM.Model.pms_Product_Info modelpms_Product_Info = m_bllpms_Product_Info.GetViewModel(id);
            
            /********发送审批结果通知邮件*******/
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
            mmsg2.Subject = modelpms_Product_Info.图号.ToString().Trim() + "-"+modelpms_Product_Info.产品名称.ToString().Trim() + "-报价通知";
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
                    <tr style="" background-color:#D1EEEE; text-align:center;""><td>"+modelpms_Product_Info.产品名称.ToString().Trim()
                    +"</td><td>"+modelpms_Product_Info.图号.ToString().Trim()+"</td><td>"+modelpms_Product_Info.规范.ToString().Trim()+ @"</td></tr>
                    <tr style="" background-color:#FFB90F; text-align:center; font-weight:bolder ""><td>产品结构</td><td>材质</td><td>行业</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center ""><td>" + modelpms_Product_Info.产品结构.ToString().Trim()
                    +"</td><td>"+modelpms_Product_Info.产品材质.ToString().Trim()+"</td><td>"+modelpms_Product_Info.所在行业.ToString().Trim()+ @"</td></tr>
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
            /*****/
        }

        private void SaveAttachment()
        {
            if (filePhoto.HasFile)
            {
                //获取当前登录用户uid
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                string uid = ticket.UserData;
                //获取附件名
                string fileName = filePhoto.ShortFileName;
                TSM.Model.pms_Attachment modelpms_Attachment = new TSM.Model.pms_Attachment();
                TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");

                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                filePhoto.SaveAs(Server.MapPath("~/upload/attachment/" + fileName));

                modelpms_Attachment.ProductInfoID = m_bllpms_Product_Info.GetMaxId() - 1;
                modelpms_Attachment.UploadUid = int.Parse(uid);
                modelpms_Attachment.AttachmentName = fileName;
                modelpms_Attachment.AttachmentAddr = "~/upload/attachment/" + fileName;
                modelpms_Attachment.UploadPermission = "营销员";
                modelpms_Attachment.UploadTime = DateTime.Now.Date;
                m_bllpms_Attachment.Add(modelpms_Attachment);

                // 清空文件上传组件
                filePhoto.Reset();
            }

        }
        

        #endregion

    }
}