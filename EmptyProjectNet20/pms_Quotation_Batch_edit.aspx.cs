using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Web.Security;
using System.Net.Mail;
using System.Text;

namespace EmptyProjectNet20
{
    public partial class pms_Quotation_Batch_edit : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Info m_bllpms_Product_Info = new TSM.BLL.pms_Product_Info();
        private TSM.BLL.pms_Product_Batch m_bllpms_Product_Batch = new TSM.BLL.pms_Product_Batch();
        private TSM.BLL.pms_Company_Info m_bllpms_Company_Info = new TSM.BLL.pms_Company_Info();
       // private TSM.BLL.pms_User_Info m_bllpms_User_Info = new TSM.BLL.pms_User_Info();
        private TSM.BLL.pms_Quotation_Details m_bllpms_Quotation_Details = new TSM.BLL.pms_Quotation_Details();
        private TSM.BLL.pms_Quotation_Info m_bllpms_Quotation_Info = new TSM.BLL.pms_Quotation_Info();
        private TSM.BLL.pms_Approval_Info m_bllpms_Approval_Info = new TSM.BLL.pms_Approval_Info();
        private TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();
        
        #region Page_Load

        protected void Page_Load(object sender, EventArgs e)
        {
            //如果页面是首次加载则loaddata;
            if (!IsPostBack)
            {
                LoadData();
            }
            if (IsPostBack)
            {
                BindGrid();
                LoadData1();
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

        protected string GetQueryValue(string queryKey)
        {
            string queryValue = "-1";
            try
            {
                queryValue = Request.QueryString[queryKey];
            }
            catch (Exception)
            {
                // TODO
            }

            return queryValue;
        }


        private void LoadData()
        {
            //绑定报价单位下拉列表控件
            DataSet dsCom = m_bllpms_Company_Info.GetList("");

            ddlCom.DataValueField = "CompanyInfoID";
            ddlCom.DataTextField = "CompanyName";
            ddlCom.DataSource = dsCom.Tables[0];
            ddlCom.DataBind();

            //// 默认的排序列和排序方向
            //Grid1.SortColumnIndex = 0;
            //Grid1.SortDirection = "DESC";

            // 每页记录数
            Grid1.PageSize = 15;

            //// 点击删除按钮时，至少选中一项
            //ResolveDeleteGridItem(btnDeleteSelected, Grid1);

            int id = GetQueryIntValue("id");
            string weight = GetQueryValue("id1");
            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = m_bllpms_Quotation_Info.GetModel(id);
            if (modelpms_Quotation_Info == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
 
            }
            else
            {
                //给控件赋初值,显示
                lbBatchID.Text = modelpms_Quotation_Info.QuotationInfoID.ToString().Trim();
                ddlCom.SelectedValue = modelpms_Quotation_Info.QuotationDepart.ToString().Trim();
                tbxKnife.Text = modelpms_Quotation_Info.KnifeCharges.ToString().Trim();
                tbxTool.Text = modelpms_Quotation_Info.ToolCharges.ToString().Trim();
                tbxSpray.Text = modelpms_Quotation_Info.SprayingCharges.ToString().Trim();
                tbxPack.Text = modelpms_Quotation_Info.PackingCharges.ToString().Trim();
                tbxTest.Text = modelpms_Quotation_Info.TestingCharges.ToString().Trim();
                tbxTrans.Text = modelpms_Quotation_Info.TransportCharges.ToString().Trim();
                tbxCharge.Text = modelpms_Quotation_Info.Charge.ToString().Trim();
                lbProID.Text = modelpms_Quotation_Info.ProductInfoID.ToString().Trim();
                if (modelpms_Quotation_Info.ChargeDescrib != null)
                { tbxChargeDesc.Text = modelpms_Quotation_Info.ChargeDescrib; }
                if (modelpms_Quotation_Info.KinfeDescrib != null)
                { tbxKnifeDesc.Text = modelpms_Quotation_Info.KinfeDescrib; }
                if (modelpms_Quotation_Info.PackingDescrib != null)
                { tbxPackDesc.Text = modelpms_Quotation_Info.PackingDescrib; }
                if (modelpms_Quotation_Info.SprayingDescrib != null)
                { tbxSprayDesc.Text = modelpms_Quotation_Info.SprayingDescrib; }
                if (modelpms_Quotation_Info.TestingDescrib != null)
                { tbxTestDesc.Text = modelpms_Quotation_Info.TestingDescrib; }
                if (modelpms_Quotation_Info.ToolsDescrib != null)
                { tbxToolDesc.Text = modelpms_Quotation_Info.ToolsDescrib; }
                if (modelpms_Quotation_Info.TransportDescrib != null)
                { tbxTransDesc.Text = modelpms_Quotation_Info.TransportDescrib; }
                if (modelpms_Quotation_Info.Charge.ToString().Trim() != null) 
                {
                    decimal Price = Convert.ToDecimal(modelpms_Quotation_Info.Charge) + Convert.ToDecimal(tbxPack.Text)
                                    + Convert.ToDecimal(tbxTrans.Text) + Convert.ToDecimal(tbxTest.Text)
                                    + Convert.ToDecimal(tbxSpray.Text);
                    lbUnitPrice.Text = Math.Round((Price / Convert.ToDecimal(weight)), 0).ToString();
                }
                 
            }
            //绑定表格
            BindGrid();

            //父窗口向子窗口传值
            string BatchId = lbBatchID.Text.ToString().Trim();
            btnNew.OnClientClick = Window1.GetSaveStateReference(tbxCharge.ClientID) + Window1.GetShowReference("~/pms_Quotation_Info_new.aspx?id=" + BatchId, "添加机床");
        }

        private void BindGrid()
        {
            DataSet ds;
            string strWhere = "报价单ID='" + lbBatchID.Text + "'";
            //string strWhere = "";
            ds = m_bllpms_Quotation_Details.GetList(strWhere);
            // 在查询添加之后，排序和分页之前获取总记录数
            // Grid1总共有多少条记录
            Grid1.RecordCount = ds.Tables[0].Rows.Count;

            ds = m_bllpms_Quotation_Details.GetList(Grid1.PageSize, Grid1.PageIndex + 1, strWhere);


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
                    m_bllpms_Quotation_Details.Delete(id);
                    BindGrid();
                    LoadData1(); 
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
            sendMail();
            SaveAttachment();
            Alert.Show("保存成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        protected void btn_PriceClick(object sender, EventArgs e)
        {
            LoadData1();  
        }

        private void LoadData1()
        {
            string weight = GetQueryValue("id1");
            int id1 = GetQueryIntValue("id");
            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = m_bllpms_Quotation_Info.GetModel(id1);
            tbxCharge.Text = modelpms_Quotation_Info.Charge.ToString().Trim();
            decimal Price = Convert.ToDecimal(modelpms_Quotation_Info.Charge) + Convert.ToDecimal(tbxPack.Text)
            + Convert.ToDecimal(tbxTrans.Text) + Convert.ToDecimal(tbxTest.Text)
            + Convert.ToDecimal(tbxSpray.Text);
            lbUnitPrice.Text = Math.Round((Price / Convert.ToDecimal(weight)), 0).ToString();
        }

        private void SaveProductType()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = new TSM.Model.pms_Quotation_Info();
            modelpms_Quotation_Info.QuotationInfoID = int.Parse(lbBatchID.Text);
            modelpms_Quotation_Info.ProductInfoID = int.Parse(lbProID.Text);
            modelpms_Quotation_Info.QuotationDepart = int.Parse(ddlCom.SelectedValue);
            modelpms_Quotation_Info.QuotationTime = DateTime.Now.Date;
            modelpms_Quotation_Info.KnifeCharges = Convert.ToDecimal(tbxKnife.Text);
            modelpms_Quotation_Info.ToolCharges = Convert.ToDecimal(tbxTool.Text);
            modelpms_Quotation_Info.SprayingCharges = Convert.ToDecimal(tbxSpray.Text);
            modelpms_Quotation_Info.PackingCharges = Convert.ToDecimal(tbxPack.Text);
            modelpms_Quotation_Info.TestingCharges = Convert.ToDecimal(tbxTest.Text);
            modelpms_Quotation_Info.TransportCharges = Convert.ToDecimal( tbxTrans.Text);
            modelpms_Quotation_Info.QuotationPrice = 0;
            modelpms_Quotation_Info.ApprovalStatus = "待生产部审批";
            modelpms_Quotation_Info.UserInfoID = int.Parse(uid);
            modelpms_Quotation_Info.ToolsDescrib = tbxToolDesc.Text;
            modelpms_Quotation_Info.KinfeDescrib = tbxKnifeDesc.Text;
            modelpms_Quotation_Info.PackingDescrib = tbxPackDesc.Text;
            modelpms_Quotation_Info.TransportDescrib = tbxTransDesc.Text;
            modelpms_Quotation_Info.ChargeDescrib = tbxChargeDesc.Text;
            modelpms_Quotation_Info.TestingDescrib = tbxTestDesc.Text;
            modelpms_Quotation_Info.SprayingDescrib = tbxSprayDesc.Text;

            m_bllpms_Quotation_Info.Update(modelpms_Quotation_Info);
            
        }

        private void sendMail()
        {
            var uname = HttpUtility.UrlEncode("刘立");
            var url1 = "http://192.168.0.6/pms/pms_Processing_Approval_Info.aspx?uname=" + uname + "&uid=4";
            //var url1 = "http://localhost:2840/pms_Processing_Approval_Info.aspx?uname=" + uname + "&uid=4";
            int id = int.Parse(lbProID.Text);
            TSM.Model.pms_Product_Info modelpms_Product_Info = m_bllpms_Product_Info.GetViewModel(id);
            decimal Price = Convert.ToDecimal(tbxCharge.Text) + Convert.ToDecimal(tbxTrans.Text) + Convert.ToDecimal(tbxTest.Text) + Convert.ToDecimal(tbxPack.Text) + Convert.ToDecimal(tbxSpray.Text);
            /********发送审批结果通知邮件*******/
            MailMessage mmsg2 = new MailMessage();
            mmsg2.From = new MailAddress("kp.ccz@kocel.com", "生产管理系统", Encoding.UTF8);
            mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.报价邮箱));
            mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.营销员邮箱));
            mmsg2.To.Add(new MailAddress("kmc.ll@kocel.com"));
            mmsg2.To.Add(new MailAddress("kp.ccz@kocel.com"));
            mmsg2.Subject = modelpms_Product_Info.图号+"-"+ modelpms_Product_Info.产品名称 + "-审批通知";
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
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>产品名称</td><td>图号</td><td>单重(T)</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>"+ modelpms_Product_Info.产品名称
                    +"</td><td>"+ modelpms_Product_Info.图号 +"</td><td>" + modelpms_Product_Info.净重 + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>序号</td><td>项目</td><td>报价(元)</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>1</td><td>加工费用</td><td>" + tbxCharge.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>2</td><td>运输费用</td><td>" + tbxTrans.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>3</td><td>检测费用</td><td>" + tbxTest.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>4</td><td>包装费用</td><td>" + tbxPack.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>5</td><td>喷涂费用</td><td>" + tbxSpray.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>合计单价</td><td></td><td>" + Price + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>吨单价</td><td></td><td>" + lbUnitPrice.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>其它</td><td>特殊刀具</td><td>" + tbxKnife.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>其它</td><td>特殊工装</td><td>" + tbxTool.Text + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center ""><td colspan= 3 >刘部长您好,请您<a href=" + url1 + @"><span style="" font-weight:bolder; color:Red"">登录系统</span></a>进行报价审批!</td></tr>
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
            if (fileUpload.HasFile)
            {
                int id = int.Parse(lbProID.Text); //产品id
                //获取当前登录用户uid
                var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                string uid = ticket.UserData;

                string fileName = fileUpload.ShortFileName;
                //把附件报存在服务器上
                fileName = fileName.Replace(":", "_").Replace(" ", "_").Replace("\\", "_").Replace("/", "_");
                fileName = DateTime.Now.Ticks.ToString() + "_" + fileName;
                fileUpload.SaveAs(Server.MapPath("~/upload/attachment/" + fileName));
                TSM.Model.pms_Attachment modelpms_Attachment = new TSM.Model.pms_Attachment();
                TSM.BLL.pms_Attachment m_bllpms_Attachment = new TSM.BLL.pms_Attachment();
                TSM.Model.pms_Attachment modelpms_Attachment_1 = m_bllpms_Attachment.GetModel2(id); //以产品id获取工艺员上传附件
                if (modelpms_Attachment_1 == null)
                {
                    // 为空则ADD
                    modelpms_Attachment.ProductInfoID = id;
                    modelpms_Attachment.UploadUid = int.Parse(uid);
                    modelpms_Attachment.AttachmentName = fileName;
                    modelpms_Attachment.AttachmentAddr = "~/upload/attachment/" + fileName;
                    modelpms_Attachment.UploadPermission = "工艺员";
                    modelpms_Attachment.UploadTime = DateTime.Now.Date;
                    m_bllpms_Attachment.Add(modelpms_Attachment);
                }
                else
                {
                    //非空则UPDATE
                    modelpms_Attachment.AttachmentID = modelpms_Attachment_1.AttachmentID;
                    modelpms_Attachment.ProductInfoID = id;
                    modelpms_Attachment.UploadUid = int.Parse(uid);
                    modelpms_Attachment.AttachmentName = fileName;
                    modelpms_Attachment.AttachmentAddr = "~/upload/attachment/" + fileName;
                    modelpms_Attachment.UploadPermission = "工艺员";
                    modelpms_Attachment.UploadTime = DateTime.Now.Date;
                    m_bllpms_Attachment.Update(modelpms_Attachment);
                }

                // 清空文件上传组件
                fileUpload.Reset();
            }

        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lbProID.Text);
            TSM.Model.pms_Attachment modelpms_Attachment = m_bllpms_Attachment.GetModel1(id);
            if (modelpms_Attachment == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("营销员没有上传过附件!");
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

        #endregion
    }
}