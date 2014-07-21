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
using System.IO;

namespace EmptyProjectNet20
{
    public partial class pms_Processing_Approval_edit : System.Web.UI.Page
    {
        private TSM.BLL.pms_Quotation_Info m_bllpms_Quotation_Info = new TSM.BLL.pms_Quotation_Info();
        private TSM.BLL.pms_Approval_Info m_bllpms_Approval_Info = new TSM.BLL.pms_Approval_Info();
        private TSM.BLL.pms_Quotation_Details m_bllpms_Quotation_Details = new TSM.BLL.pms_Quotation_Details();
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
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            //// 默认的排序列和排序方向
            //Grid1.SortColumnIndex = 0;
            //Grid1.SortDirection = "DESC";

            // 每页记录数
            Grid1.PageSize = 15;

            //// 点击删除按钮时，至少选中一项
            //ResolveDeleteGridItem(btnDeleteSelected, Grid1);

            int id = GetQueryIntValue("id");
            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = m_bllpms_Quotation_Info.GetModel(id);
             modelpms_Quotation_Info = m_bllpms_Quotation_Info.GetModel2(id); 
            

            if (modelpms_Quotation_Info == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }

            //给控件赋初值,显示
            lbBatchID.Text = modelpms_Quotation_Info.QuotationInfoID.ToString().Trim();

            lbChar0.Text = modelpms_Quotation_Info.加工费用.ToString().Trim();
            if (uid == "4")
            {
                lbPack0.Text = Convert.ToInt64(Convert.ToDecimal(modelpms_Quotation_Info.包装费用) + Convert.ToDecimal(modelpms_Quotation_Info.喷涂费用)).ToString();
                tbxPack.Text = Convert.ToInt64(Convert.ToDecimal(modelpms_Quotation_Info.包装费用) + Convert.ToDecimal(modelpms_Quotation_Info.喷涂费用)).ToString();
            }
            else
            {
                lbPack0.Text = Convert.ToInt64(Convert.ToDecimal(modelpms_Quotation_Info.包装费用)).ToString();
                tbxPack.Text = Convert.ToInt64(Convert.ToDecimal(modelpms_Quotation_Info.包装费用)).ToString();
            }
            
            lbTest0.Text = modelpms_Quotation_Info.检测费用.ToString().Trim();
            lbTrans0.Text = modelpms_Quotation_Info.运输费用.ToString().Trim();
            lbKnife0.Text = modelpms_Quotation_Info.刀具费用.ToString().Trim();
            lbTool0.Text = modelpms_Quotation_Info.工装费用.ToString().Trim();
            lbPrice0.Text = (Convert.ToDecimal(lbChar0.Text) + Convert.ToDecimal(lbPack0.Text) + Convert.ToDecimal(lbTest0.Text) +Convert.ToDecimal(lbTrans0.Text)).ToString();

            lbChar2.Text = modelpms_Quotation_Info.加工信息.ToString().Trim();
            lbPack2.Text = modelpms_Quotation_Info.包装信息 + ";喷涂:" + modelpms_Quotation_Info.喷涂信息;
            lbTest2.Text = modelpms_Quotation_Info.检测信息.ToString().Trim();
            lbTrans2.Text = modelpms_Quotation_Info.运费信息.ToString().Trim();
            lbKnife2.Text = modelpms_Quotation_Info.刀具信息.ToString().Trim();
            lbTool2.Text = modelpms_Quotation_Info.工装信息.ToString().Trim();

            tbxChar.Text = modelpms_Quotation_Info.加工费用.ToString().Trim();

            tbxTest.Text = modelpms_Quotation_Info.检测费用.ToString().Trim();
            tbxTrans.Text = modelpms_Quotation_Info.运输费用.ToString().Trim();
            tbxKnife.Text = modelpms_Quotation_Info.刀具费用.ToString().Trim();
            tbxTool.Text = modelpms_Quotation_Info.工装费用.ToString().Trim(); 

            lbPrice1.Text = (Convert.ToDecimal(tbxChar.Text) + Convert.ToDecimal(tbxPack.Text) + Convert.ToDecimal(tbxTest.Text) +
                            Convert.ToDecimal(tbxTrans.Text)).ToString();
            tbxPrice.Text = Math.Round((Convert.ToDecimal(lbPrice1.Text) / Convert.ToDecimal(lbPrice0.Text)-1) * 100, 0).ToString();
            lbPriceOnce0.Text = (Convert.ToDecimal(lbTool0.Text) + Convert.ToDecimal(lbKnife0.Text)).ToString();
            lbPriceOnce1.Text = (Convert.ToDecimal(tbxKnife.Text) + Convert.ToDecimal(tbxTool.Text)).ToString();
            lbUPrice0.Text = Math.Round(Convert.ToDecimal(lbPrice1.Text) / modelpms_Quotation_Info.净重,0).ToString();

            //绑定表格  
            BindGrid();

            //父窗口向子窗口传值
            string BatchId = lbBatchID.Text.ToString().Trim();
          //  btnNew.OnClientClick = Window1.GetSaveStateReference(tbxCharge.ClientID) + Window1.GetShowReference("~/pms_Quotation_Info_new.aspx?id=" + BatchId, "添加机床");
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

        protected void Window1_Close(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            SaveProductType();
            if (uid == "4") { sendMail_App(); }
            else { sendMail_Final(); }
            
            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript(ActiveWindow.GetHidePostBackReference());
        }

        private void SaveProductType()
        {
            var cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string uid = ticket.UserData;
            TSM.Model.pms_Approval_Info modelpms_Approval_Info = new TSM.Model.pms_Approval_Info();
            modelpms_Approval_Info.QuotationInfoID = int.Parse(lbBatchID.Text);
            modelpms_Approval_Info.UserInfoID = int.Parse(uid);
            modelpms_Approval_Info.QuotationRate = int.Parse(tbxChar.Text);
            modelpms_Approval_Info.TransportRate = int.Parse(tbxTrans.Text);
            modelpms_Approval_Info.TestingRate = int.Parse(tbxTest.Text);
            modelpms_Approval_Info.PackingRate = int.Parse(tbxPack.Text);
            modelpms_Approval_Info.KnifeRate = int.Parse(tbxKnife.Text);
            modelpms_Approval_Info.ToolRate = int.Parse(tbxTool.Text);
            modelpms_Approval_Info.ApprovalDate = DateTime.Now.Date;
            modelpms_Approval_Info.Remarks = tbxRemark.Text;

            m_bllpms_Approval_Info.Add(modelpms_Approval_Info);

            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = new TSM.Model.pms_Quotation_Info();
            modelpms_Quotation_Info.QuotationInfoID = int.Parse(lbBatchID.Text);
            if (uid == "4") { modelpms_Quotation_Info.ApprovalStatus = "待公司领导审批"; }
            else { modelpms_Quotation_Info.ApprovalStatus = "审批通过"; }
            
            m_bllpms_Quotation_Info.UpdateStatus(modelpms_Quotation_Info);
        }

        protected void tbxChar_Click(object sender, EventArgs e)
        {
            int id = GetQueryIntValue("id");
            TSM.Model.pms_Quotation_Info modelpms_Quotation_Info = m_bllpms_Quotation_Info.GetModel2(id); 
            lbPrice1.Text = (Convert.ToDecimal(tbxChar.Text) + Convert.ToDecimal(tbxPack.Text) + Convert.ToDecimal(tbxTest.Text) +
                Convert.ToDecimal(tbxTrans.Text)).ToString();
            tbxPrice.Text = Math.Round((Convert.ToDecimal(lbPrice1.Text) / Convert.ToDecimal(lbPrice0.Text)-1) * 100, 0).ToString();
            lbPriceOnce1.Text = (Convert.ToDecimal(tbxKnife.Text) + Convert.ToDecimal(tbxTool.Text)).ToString();
            lbUPrice0.Text = Math.Round(Convert.ToDecimal(lbPrice1.Text) / modelpms_Quotation_Info.净重, 0).ToString();
        }

       private void sendMail_App()
        {
            var uname = HttpUtility.UrlEncode("杨保");
            var url1 = "http://192.168.0.6/pms/pms_Processing_Approval_Info.aspx?uname=" + uname + "&uid=7";
            //var url1 = "http://localhost:2840/pms_Processing_Approval_Info.aspx?uname=" + uname + "&uid=7";
            int ProID = GetQueryIntValue("id1"); 
            TSM.Model.pms_Product_Info modelpms_Product_Info = m_bllpms_Product_Info.GetViewModel(ProID);
            decimal UnitPrice = Math.Round(Convert.ToDecimal(lbPrice1.Text) / Convert.ToDecimal(modelpms_Product_Info.净重), 0);
            /********发送审批结果通知邮件***/
            MailMessage mmsg2 = new MailMessage();
            mmsg2.From = new MailAddress("kp.ccz@kocel.com", "生产管理系统", Encoding.UTF8);
            mmsg2.CC.Add(new MailAddress("kmc.ll@kocel.com"));
            mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.报价邮箱));
            mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.营销员邮箱));
            mmsg2.To.Add(new MailAddress("kmc.yb@kocel.com"));
            mmsg2.To.Add(new MailAddress("kp.ccz@kocel.com"));
            mmsg2.Subject = modelpms_Product_Info.图号 + "-" + modelpms_Product_Info.产品名称 + "-审批通知";
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
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>" + modelpms_Product_Info.产品名称
                    + "</td><td>" + modelpms_Product_Info.图号 + "</td><td>" + modelpms_Product_Info.净重 + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>序号</td><td>项目</td><td>报价(元)</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>1</td><td>加工费用</td><td>" + tbxChar.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>2</td><td>运输费用</td><td>" + tbxTrans.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>3</td><td>检测费用</td><td>" + tbxTest.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>4</td><td>包装费用</td><td>" + tbxPack.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>合计单价</td><td></td><td>" + lbPrice1.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>吨单价</td><td></td><td>" + UnitPrice + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>其它</td><td>特殊刀具</td><td>" + tbxKnife.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>其它</td><td>特殊工装</td><td>" + tbxTool.Text + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center ""><td colspan= 3 >杨部长您好,请您<a href=" + url1 + @"><span style="" font-weight:bolder; color:Red"">登录系统</span></a>进行报价审批!</td></tr>
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

       private void sendMail_Final()
       {
           int ProID = GetQueryIntValue("id1");
           TSM.Model.pms_Product_Info modelpms_Product_Info = m_bllpms_Product_Info.GetViewModel(ProID);
           decimal UnitPrice = Math.Round(Convert.ToDecimal(lbPrice1.Text) / Convert.ToDecimal(modelpms_Product_Info.净重), 0);
           /********发送审批结果通知邮件***/
           MailMessage mmsg2 = new MailMessage();
           mmsg2.From = new MailAddress("kp.ccz@kocel.com", "生产管理系统", Encoding.UTF8);
           mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.报价邮箱));
           mmsg2.CC.Add(new MailAddress(modelpms_Product_Info.营销员邮箱));
           mmsg2.CC.Add(new MailAddress("kmc.ll@kocel.com"));
           mmsg2.CC.Add(new MailAddress("kmc.yb@kocel.com"));
           mmsg2.To.Add(new MailAddress(modelpms_Product_Info.商务联系邮箱));
           mmsg2.To.Add(new MailAddress("kp.ccz@kocel.com"));
           mmsg2.Subject = modelpms_Product_Info.图号 + "-" + modelpms_Product_Info.产品名称 + "-报价单";
           mmsg2.Body = @"
                    <BODY style= margin:10px; width:1200px; height:900px>
                    <table style= width:1200px; height:900px>
                    <tr>
                    <td colspan=2 style= height:90px>
                    <img src=http://192.168.0.6/pms/res/images/bg_lft.gif alt=12 />
                    </td>
                    </tr>
                    <tr>
                    <td rowspan=2><img src= http://192.168.0.6/pms/res/images/bg_lft1.gif alt=22 />
                    <table style= ""width:570px; height:432px;"">
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>产品名称</td><td>图号</td><td>单重(T)</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>" + modelpms_Product_Info.产品名称
                   + "</td><td>" + modelpms_Product_Info.图号 + "</td><td>" + modelpms_Product_Info.净重 + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#FFB90F; font-weight:bolder; text-align:center ""><td>序号</td><td>项目</td><td>报价(元)</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>1</td><td>加工费用</td><td>" + tbxChar.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>2</td><td>运输费用</td><td>" + tbxTrans.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>3</td><td>检测费用</td><td>" + tbxTest.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>4</td><td>包装费用</td><td>" + tbxPack.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>合计单价</td><td></td><td>" + lbPrice1.Text + @"</td></tr>
                    <tr style="" background-color:#EEEED1; text-align:center; font-weight:bold ""><td>其它</td><td>特殊刀具</td><td>" + tbxKnife.Text + @"</td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center; font-weight:bold ""><td>其它</td><td>特殊工装</td><td>" + tbxTool.Text + @"</td></tr>
                    <tr style="" background-color:#FFFFFF; text-align:center; font-weight:bold ""><td></td><td></td><td></td></tr>
                    <tr style="" background-color:#D1EEEE; text-align:center ""><td>说明</td><td colspan= 2 >本次报价有效期3个月,过期则需重新评估报价</td></tr>
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

        
        protected void btnDownload_Click(object sender, EventArgs e)
       {
           int id = GetQueryIntValue("id1");
           TSM.Model.pms_Attachment modelpms_Attachment = m_bllpms_Attachment.GetModel2(id);
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
         
        #endregion
    }
}