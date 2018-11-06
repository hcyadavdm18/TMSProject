using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogiclayer;
using BusinessObject;
using System.Data;
using System.Data.SqlClient;
namespace PresentationLayer.Adminfolder
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        BusinessLogiclayer.state objbllstate = new BusinessLogiclayer.state();
        BusinessLogiclayer.Country objbllcountry = new BusinessLogiclayer.Country();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        BusinessObject.state objbostate = new BusinessObject.state();
        public void Fillddlconbindddl()
        {
           
            DataSet ds = new DataSet();
            ds = objbllstate.Fillddlconbind();
            ddlselectcon.DataSource = ds;

            ddlselectcon.DataTextField = "coname";
            ddlselectcon.DataValueField = "coid";
            ddlselectcon.DataBind();
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Fillddlconbindddl();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            objbostate.statename = txtstate.Text;
            objbocountry.CountryId = ddlselectcon.SelectedValue;
         
            int i = objbllstate.AddState(objbostate,objbocountry);
            if (i == 1)
            {
                lblmsgstate.Text = "record is inserted";
            }
            else
            {
                lblmsgstate.Text = "Failed";
            }

        }

       


    }
}