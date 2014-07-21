using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;
using System.Data;
using System.Web.Security;

namespace EmptyProjectNet20
{
    public partial class pms_Quotation_Info_new : System.Web.UI.Page
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

        }

        #endregion

        #region Events

        private void SaveProductType()
        {

            TSM.Model.pms_Quotation_Details modelpms_Quotation_Details = new TSM.Model.pms_Quotation_Details();
            modelpms_Quotation_Details.QuotationInfoID = GetQueryIntValue("id");
            modelpms_Quotation_Details.MachinePriceID = int.Parse(ddlMec.SelectedValue);
            modelpms_Quotation_Details.WorkingHour = Convert.ToDecimal(tbxHour.Text);

            m_bllpms_Quotation_Details.Add(modelpms_Quotation_Details);     
        }

        protected void btnSaveClose_Click(object sender, EventArgs e)
        {
            SaveProductType();

            Alert.Show("添加成功！", String.Empty, ActiveWindow.GetHidePostBackReference());
            PageContext.RegisterStartupScript("parent.__doPostBack('','pms_Product_Info');");
            
        }

        protected void tbxHour_Changed(object sender, EventArgs e)
        {
            tbxPeriod.Text = Math.Round(int.Parse(tbxHour.Text)/0.52,0).ToString();
        }

        protected void tbxPeriod_Changed(object sender, EventArgs e)
        {
            tbxHour.Text = Math.Round(int.Parse(tbxPeriod.Text) * 0.52, 0).ToString();
        }
        #endregion
    }
}