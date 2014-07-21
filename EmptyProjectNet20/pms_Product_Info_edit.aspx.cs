using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using FineUI;
using System.Text;
using System.Web.Security;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Info_edit : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Type m_bllpms_Product_Type = new TSM.BLL.pms_Product_Type();
        private TSM.BLL.pms_Product_Struc m_bllpms_Product_Struc = new TSM.BLL.pms_Product_Struc();
        private TSM.BLL.pms_Product_Mater m_bllpms_Product_Mater = new TSM.BLL.pms_Product_Mater();
        private TSM.BLL.pms_Product_Indust m_bllpms_Product_Indust = new TSM.BLL.pms_Product_Indust();
        private TSM.BLL.pms_Customer_Require m_bllpms_Customer_Require = new TSM.BLL.pms_Customer_Require();
        private TSM.BLL.pms_Product_Info m_bllpms_Product_Info = new TSM.BLL.pms_Product_Info();
        private TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();

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
            //绑定几个下拉列表值
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

            int id = GetQueryIntValue("id");
            TSM.Model.pms_Product_Info modelpms_Product_Info = m_bllpms_Product_Info.GetModel(id);

            if (modelpms_Product_Info == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            //给控件赋初值,显示
            lbBatchID.Text = modelpms_Product_Info.ProductBatchID.ToString().Trim();
            tbxProName.Text = modelpms_Product_Info.ProductInfoName.ToString().Trim();
            ddlStr.SelectedValue = modelpms_Product_Info.ProductStrucID.ToString().Trim();
            ddlMet.SelectedValue = modelpms_Product_Info.ProductMaterID.ToString().Trim();
            ddlReq.SelectedValue = modelpms_Product_Info.CustomerRequireID.ToString().Trim();
            ddlInd.SelectedValue = modelpms_Product_Info.ProductIndustID.ToString().Trim();
            tbxPic.Text = modelpms_Product_Info.ProductPhotoNum.ToString().Trim();
            tbxSta.Text = modelpms_Product_Info.ProductStandard.ToString().Trim();
            tbxWei.Text = modelpms_Product_Info.ProductWeight.ToString().Trim();
            tbxOrd.Text = modelpms_Product_Info.OrderQuantity.ToString().Trim();
            tbxRem.Text = modelpms_Product_Info.Remarks.ToString().Trim();
        }

        #endregion

        #region Events

        private void SaveProductType()
        {
            TSM.Model.pms_Product_Info modelpms_Product_Info = new TSM.Model.pms_Product_Info();
            modelpms_Product_Info.ProductInfoID = GetQueryIntValue("id");
            modelpms_Product_Info.ProductBatchID = int.Parse(lbBatchID.Text);
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

            m_bllpms_Product_Info.Update(modelpms_Product_Info);

        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProductType();
            SaveAttachment();
            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveAttachment()
        {
            if (fileUpload.HasFile)
            {
                int id = GetQueryIntValue("id");
                //获取当前登录用户uid
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                string uid = ticket.UserData;

                //保存文件到服务器
                string fileName = fileUpload.ShortFileName;
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                fileUpload.SaveAs(Server.MapPath("~/upload/attachment/" + fileName));

                TSM.Model.pms_Attachment modelpms_Attachment = new TSM.Model.pms_Attachment();
                TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();
                TSM.Model.pms_Attachment modelpms_Attachment_1 = m_bllpms_Attachment.GetModel1(id);
                if (modelpms_Attachment_1 == null)
                {
                    // 为空则ADD
                    modelpms_Attachment.ProductInfoID = GetQueryIntValue("id");
                    modelpms_Attachment.UploadUid = int.Parse(uid);
                    modelpms_Attachment.AttachmentName = fileName;
                    modelpms_Attachment.AttachmentAddr = "~/upload/attachment/" + fileName;
                    modelpms_Attachment.UploadPermission = "营销员";
                    modelpms_Attachment.UploadTime = DateTime.Now.Date;
                    m_bllpms_Attachment.Add(modelpms_Attachment);
                }
                else
                {
                    //非空则UPDATE
                    modelpms_Attachment.AttachmentID = modelpms_Attachment_1.AttachmentID;
                    modelpms_Attachment.ProductInfoID = GetQueryIntValue("id");
                    modelpms_Attachment.UploadUid = int.Parse(uid);
                    modelpms_Attachment.AttachmentName = fileName;
                    modelpms_Attachment.AttachmentAddr = "~/upload/attachment/" + fileName;
                    modelpms_Attachment.UploadPermission = "营销员";
                    modelpms_Attachment.UploadTime = DateTime.Now.Date;
                    m_bllpms_Attachment.Update(modelpms_Attachment);
                }

                // 清空文件上传组件
                fileUpload.Reset();
            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.pms_Attachment modelpms_Attachment = m_bllpms_Attachment.GetModel1(id);
            if (modelpms_Attachment == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("营销员没有上传过附件!");
                return;

            }
            string shortName = modelpms_Attachment.AttachmentName;
            shortName = shortName.Remove(0, 19); //去掉字符串的前19个字符

            string filename = Server.MapPath("~/upload/attachment/"+ modelpms_Attachment.AttachmentName);
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(shortName, Encoding.UTF8));
            Response.TransmitFile(filename);
            Response.End();
        }

        #endregion

    }
}