using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EmptyProjectNet20
{
    public partial class pms_Product_Struc_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_Product_Struc m_bllpms_Product_Struc = new TSM.BLL.pms_Product_Struc();


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
            TSM.Model.pms_Product_Struc modelpms_Product_Struc = new TSM.Model.pms_Product_Struc();
            modelpms_Product_Struc.ProductStruc = tbxName.Text.Trim();
            m_bllpms_Product_Struc.Add(modelpms_Product_Struc);

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