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
    public partial class Locationdetails : System.Web.UI.Page
    {
        BusinessLogiclayer.Location objbllloc = new BusinessLogiclayer.Location();
        BusinessObject.Location objboloc = new BusinessObject.Location();
        BusinessObject.City objbocity = new BusinessObject.City();
        public void Fillddlbycity()
        {
            DataSet ds = objbllloc.FillCityddl();
            ddlselectcity.DataSource = ds;
            ddlselectcity.DataTextField = "cityname";
            ddlselectcity.DataValueField = "cityid";
            ddlselectcity.DataBind();
        
        }
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Fillddlbycity();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            objbocity.cityid = ddlselectcity.SelectedValue;
            objboloc.LocationName = txtlocation.Text;
            int i = objbllloc.AddLocation(objboloc,objbocity);
            if (i == 1)
            { lblmsglocation.Text = "Locatoin id and name added successfully."; }
            else
            { lblmsglocation.Text = "Failed"; }

        }
    }
}