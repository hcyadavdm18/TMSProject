using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogiclayer;
using BusinessObject;

namespace PresentationLayer.Adminfolder
{
    public partial class ADD : System.Web.UI.Page
    {
        BusinessLogiclayer.Country objbllcountry = new BusinessLogiclayer.Country();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            objbocountry.CountryName = txtcountryname.Text;
            int i = objbllcountry.Addcountry(objbocountry);
            if (i == 1)
            {
                lbladdcountrymsg.Text = "record is inserted";

            }
            else
            {

                lbladdcountrymsg.Text = "Failed";
            }
        }
    }
}