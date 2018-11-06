using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogiclayer;
using BusinessObject;

namespace PresentationLayer.Adminfolder
{
    public partial class DevolopementCenture : System.Web.UI.Page
    {
        BusinessLogiclayer.DevolopementCenture objblldevc = new BusinessLogiclayer.DevolopementCenture();
        BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
       // BusinessObject.City objbocity = new BusinessObject.City();
        BusinessObject.Location objboloc = new BusinessObject.Location();
        public void Fillddlcity()
        {
            DataSet ds = objblldevc.Fillddlbycity();
            ddlselectcitydc.DataSource = ds;
            ddlselectcitydc.DataTextField = "locname";
            ddlselectcitydc.DataValueField = "locid";
            ddlselectcitydc.DataBind();


        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { Fillddlcity(); }

        }

        protected void btnadddevcent_Click(object sender, EventArgs e)
        {
            objboloc.LocationId = ddlselectcitydc.SelectedValue;
           objbodevc.Devcname = txtdevcenture.Text;
            int i = objblldevc.AddDevCenture(objbodevc, objboloc);
            if (i == 1)
            { lblmsgdevc.Text = "Devolopement Centure name  and id added successfully."; }
            else
            {
                lblmsgdevc.Text = "Failed";
            }
            
        }
    }
}
