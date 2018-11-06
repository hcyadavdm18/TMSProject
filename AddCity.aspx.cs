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
    public partial class AddCity : System.Web.UI.Page
    {
        BusinessLogiclayer.city objbllcity = new BusinessLogiclayer.city();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        BusinessLogiclayer.state objbllstate = new BusinessLogiclayer.state();
        BusinessObject.City objbocity = new BusinessObject.City();
        BusinessObject.state objbostate = new BusinessObject.state();
        public void FillddlofCountry()
        {
            DataSet ds = objbllcity.FillddlofCountry();
            ddlselectcountry.DataSource = ds;
            ddlselectcountry.DataTextField = "coname";
            ddlselectcountry.DataValueField = "coid";
            ddlselectcountry.DataBind();
        
        }
       /* public void Fillstateddl(BusinessObject.Country objbocountry)
        {
          
        }*/
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                FillddlofCountry();
                
            
            }
            if (IsPostBack == false)
            {
               // Fillstateddl(objbocountry);
            }

        }

        protected void btnaddcitydeatails_Click(object sender, EventArgs e)
        {
            objbostate.stateid = ddlselectstate.SelectedValue;
            objbocity.cityname = txtentercity.Text;
            objbocountry.CountryId = ddlselectcountry.SelectedValue;
            int i = objbllcity.AddCity(objbocity,objbostate,objbocountry);
            if (i == 1)
            {
                lblmsgofcityadd.Text = "Record is inserted";
            }
            else
            { lblmsgofcityadd.Text = "Failed"; }

        }

        protected void ddlselectcountry_SelectedIndexChanged(object sender, EventArgs e)
        {



            objbocountry.CountryId = ddlselectcountry.SelectedValue;
            DataSet ds = objbllcity.Fillstateddl(objbocountry);
           
            ddlselectstate.DataSource = ds;
           // ddlselectstate.Items.Clear();
            ddlselectstate.Items.Add("--Select State--");
            ddlselectstate.DataTextField = "sname";
            ddlselectstate.DataValueField = "sid";
            ddlselectstate.DataBind();

            
           
        }

    }
}