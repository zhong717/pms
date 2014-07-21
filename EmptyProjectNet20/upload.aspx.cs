using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Text;
using System.Web.Security;

namespace EmptyProjectNet20
{
    public partial class upload : System.Web.UI.Page
    {
        private TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void filePhoto_FileSelected(object sender, EventArgs e)
        {
            if (filePhoto.HasFile)
            {
                string fileName = filePhoto.ShortFileName;            
                
               /* if (!ValidateFileType(fileName))
                {
                    Alert.Show("无效的文件类型！");
                    return;
                }
                */

                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");

                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;

                filePhoto.SaveAs(Server.MapPath("~/upload/photo/" + fileName));

                imgPhoto.ImageUrl = "~/upload/photo/" + fileName;

                // 清空文件上传组件
                filePhoto.Reset();
            }

        }

        private bool ValidateFileType(string fileName)
        {
            throw new NotImplementedException();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (imgPhoto.ImageUrl == "~/res/images/login/login_4.png")
            {
                filePhoto.MarkInvalid("请先上传个人头像！");

                Alert.ShowInTop("请先上传个人头像！");

                return;
            }

            labResult.Text = "用户名：" + tbxUserName.Text + "<br/>" +
                    "邮箱：" + tbxEmail.Text + "<br/>" +
                    "头像地址：" + imgPhoto.ImageUrl + "<br/>";

            // 清空表单字段（注意，不要清空imgPhoto，否则就看不到上传的头像了）
            filePhoto.Reset();
            tbxEmail.Reset();
            tbxUserName.Reset();

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            string filename = Server.MapPath("~/upload/photo/635386998799322088_外协报价表.xlsx");
    Response.Clear();
    Response.ClearContent();
    Response.ClearHeaders();
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode("635386998799322088_外协报价表.xlsx", Encoding.UTF8));

    Response.TransmitFile(filename);
    Response.End(); 



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            labResult.Text = uid;

        }

        protected void btnDownload_Click2(object sender, EventArgs e)
        {
            //int id = GetQueryIntValue("id1");
            TSM.Model.pms_Attachment modelpms_Attachment = m_bllpms_Attachment.GetModel2(26);
            if (modelpms_Attachment == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("工艺员没有上传过附件!");
                return;

            }
            string shortName = modelpms_Attachment.AttachmentName;
            shortName = shortName.Remove(0, 19); //去掉字符串的前19个字符

            string filename = Server.MapPath("~/upload/attachment/" + modelpms_Attachment.AttachmentName);

            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(shortName, Encoding.UTF8));

            Response.TransmitFile(filename);
            Response.End(); 

        }
    }
}