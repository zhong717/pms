using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;

namespace EmptyProjectNet20
{
    public partial class pms_Quotation_Info_edit : System.Web.UI.Page
    {
        private TSM.BLL.pms_Machine_Price m_bllpms_Machine_Price = new TSM.BLL.pms_Machine_Price();
        private TSM.BLL.pms_Quotation_Details m_bllpms_Quotation_Details = new TSM.BLL.pms_Quotation_Details();



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
            DataSet dsMec = m_bllpms_Machine_Price.GetList("");
            ddlMec.DataValueField = "MachinePriceID";
            ddlMec.DataTextField = "DeviceType";
            ddlMec.DataSource = dsMec.Tables[0];
            ddlMec.DataBind();

            int id = GetQueryIntValue("id");
            TSM.Model.pms_Quotation_Details modelpms_Quotation_Details = m_bllpms_Quotation_Details.GetModel(id);
            if (modelpms_Quotation_Details == null)
            {
                // 参数错误，首先弹出Alert对话框然后关闭弹出窗口
                Alert.Show("参数错误！", String.Empty, ActiveWindow.GetHideReference());
                return;
            }
            ddlMec.SelectedValue = modelpms_Quotation_Details.MachinePriceID.ToString().Trim();
            tbxHour.Text = modelpms_Quotation_Details.WorkingHour.ToString().Trim();
            lbQua.Text = modelpms_Quotation_Details.QuotationInfoID.ToString().Trim();
            lbDet.Text = modelpms_Quotation_Details.QuotationDetailsID.ToString().Trim();
        }

        #endregion

        #region Events

        private void SaveProductType()
        {

            TSM.Model.pms_Quotation_Details modelpms_Quotation_Details = new TSM.Model.pms_Quotation_Details();
            modelpms_Quotation_Details.QuotationInfoID = int.Parse(lbQua.Text);
            modelpms_Quotation_Details.MachinePriceID = int.Parse(ddlMec.SelectedValue);
            modelpms_Quotation_Details.WorkingHour = Convert.ToDecimal(tbxHour.Text);
            modelpms_Quotation_Details.QuotationDetailsID = int.Parse(lbDet.Text);

            m_bllpms_Quotation_Details.Update(modelpms_Quotation_Details);


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