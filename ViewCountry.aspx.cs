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
    public partial class ViewCountry : System.Web.UI.Page
    {
        BusinessLogiclayer.Country objbllcountry = new BusinessLogiclayer.Country();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public void Filldata()
        {
            DataSet ds = objbllcountry.ViewCountry();
            GridView1.DataSource = ds;
            GridView1.DataBind();
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                Filldata();
            }
        }


   

        protected void GridView1_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            Filldata();
        }

        protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            Control c1 = row.FindControl("Label1");
            Label l1 = (Label)c1;
            objbocountry.CountryId = l1.Text;
            int i = objbllcountry.DeleteCountry(objbocountry);
            if (i == 1)
            {
                lblmsggdcountry.Text = "record is deleted";
            }
            else
            { lblmsggdcountry.Text = "failed"; }
            Filldata();
        }

        protected void GridView1_RowEditing1(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = -1;
        }

        protected void GridView1_RowUpdating2(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridView1.Rows[e.RowIndex];
            Control c1 = row.FindControl("TextBox1");
            TextBox t1 = (TextBox)c1;
            Control c2 = row.FindControl("TextBox2");
            TextBox t2 = (TextBox)c2;
            objbocountry.CountryId = t1.Text;
            objbocountry.CountryName = t2.Text;
            int i = objbllcountry.UpdateCountry(objbocountry);
            if (i == 1)
            {
                lblmsggdcountry.Text = "Record is Updated";
            }
            else { lblmsggdcountry.Text = "failed"; }
            GridView1.EditIndex = -1;
            Filldata();

        }

        


    }
}