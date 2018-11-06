using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogiclayer;
using BusinessObject;
using System.Data;

namespace PresentationLayer.Adminfolder
{
    public partial class viewdeleteeditcity : System.Web.UI.Page
    {
        BusinessLogiclayer.city objbllcity = new BusinessLogiclayer.city();
        BusinessObject.City objbocity = new BusinessObject.City();
        BusinessObject.state objbostate = new BusinessObject.state();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public void Fillgridbycity()
        {
            DataSet ds = objbllcity.Fillgridbycity();
            gridtoshowcity.DataSource = ds;
            gridtoshowcity.DataBind();

        
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Fillgridbycity();
            }

        }

      

        protected void gridtoshowcity_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gridtoshowcity.EditIndex = -1;
        }

        protected void gridtoshowcity_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gridtoshowcity.Rows[e.RowIndex] ;
            Control c1 = row.FindControl("Label1");
            Label l1 = (Label)c1;
            objbocity.cityid = l1.Text;
            int i = objbllcity.Deletecity(objbocity);
            if (i == 1)
            { lblmsggdofcity.Text = "Record is Deleted"; }
            else
            { lblmsggdofcity.Text = "failed"; }
            Fillgridbycity();

        }

       

        protected void gridtoshowcity_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridtoshowcity.EditIndex = -1;
            Fillgridbycity();
        }

        protected void gridtoshowcity_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gridtoshowcity.Rows[e.RowIndex];
            Control c1 = row.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            Control c2 = row.FindControl("TextBox2");
            TextBox  t2=(TextBox)c2;
            Control c3 = row.FindControl("TextBox3");
            TextBox t3 = (TextBox)c3;
            Control c4 = row.FindControl("TextBox4");
            TextBox t4 = (TextBox)c4;
            objbocity.cityid = t1.Text;
            objbocity.cityname = t2.Text;
            objbocountry.CountryId = t4.Text;
            objbostate.stateid = t3.Text;

            int i = objbllcity.Updatecity(objbocity,objbocountry,objbostate);
            if (i == 1)
            { lblmsggdofcity.Text = "Record is Updated"; }
            else
            { lblmsggdofcity.Text = "failed"; }
            gridtoshowcity.EditIndex = -1;
            Fillgridbycity();
        }
    }
}