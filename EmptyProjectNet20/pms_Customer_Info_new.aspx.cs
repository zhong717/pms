using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EmptyProjectNet20
{
    public partial class pms_Customer_Info_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_Company_Info m_bllpms_Company_Info = new TSM.BLL.pms_Company_Info();


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
            TSM.Model.pms_Company_Info modelpms_Company_Info = new TSM.Model.pms_Company_Info();
            modelpms_Company_Info.CompanyName = tbxName.Text.Trim();
            modelpms_Company_Info.CompanyType = tbxType.Text.Trim();
            m_bllpms_Company_Info.Add(modelpms_Company_Info);

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