using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace EmptyProjectNet20
{
    public partial class pms_Machine_Info_new : System.Web.UI.Page
    {
        private TSM.BLL.pms_Machine_Price m_bllpms_Machine_Price = new TSM.BLL.pms_Machine_Price();


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
            TSM.Model.pms_Machine_Price modelpms_Machine_Price = new TSM.Model.pms_Machine_Price();
            modelpms_Machine_Price.DeviceType = tbxName.Text.Trim();
            modelpms_Machine_Price.DeviceDescript = tbxDesc.Text.Trim();
            modelpms_Machine_Price.InternalCost = int.Parse(tbxCost.Text.Trim());
            modelpms_Machine_Price.InternalPrice = int.Parse(tbxPrice.Text.Trim());
            m_bllpms_Machine_Price.Add(modelpms_Machine_Price);

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