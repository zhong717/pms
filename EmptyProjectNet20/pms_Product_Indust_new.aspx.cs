using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Indust_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Indust m_bllpms_Product_Indust = new TSM.BLL.pms_Product_Indust();


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


            btnClose.OnClientClick = ActiveWindow.GetHideReference();
        }

        #endregion

        #region Events

        private void SaveProductType()
        {
            TSM.Model.pms_Product_Indust modelpms_Product_Indust = new TSM.Model.pms_Product_Indust();
            modelpms_Product_Indust.ProductIndust = tbxName.Text.Trim();
            m_bllpms_Product_Indust.Add(modelpms_Product_Indust);

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