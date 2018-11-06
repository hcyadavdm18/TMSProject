using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessObject;
using BusinessLogiclayer;

namespace PresentationLayer.Adminfolder
{
    public partial class VViewDevolopementCenture : System.Web.UI.Page
    {
        BusinessLogiclayer.DevolopementCenture objblldevc = new BusinessLogiclayer.DevolopementCenture();
        BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
        BusinessObject.City objbocity = new BusinessObject.City();
       // BusinessLogiclayer.DevolopementCenture objbodevc = new BusinessLogiclayer.DevolopementCenture();
        public void Fillgrid()
        {
            DataSet ds = objblldevc.Bindgridbydevc();
                
            Gridfordevcenture.DataSource = ds;
            Gridfordevcenture.DataBind();

        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
        
        
           if(IsPostBack==false)
           {
               Fillgrid();
           }
        }

        

        protected void Gridfordevcenture_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Gridfordevcenture.PageIndex = e.NewPageIndex;
            Fillgrid();
        }

        protected void Gridfordevcenture_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row=Gridfordevcenture.Rows[e.RowIndex];
            Control c1=row.FindControl("Label1");
            Label l1=(Label)c1;
            objbodevc.Devcid = l1.Text;
            int i = objblldevc.DeleteLoc(objbodevc);
            if (i == 1)
            { lblmsggriddevc.Text = "Record Deleted successfully."; }
            else { lblmsggriddevc.Text = "Failed"; }
            Fillgrid();
        }

        protected void Gridfordevcenture_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row=Gridfordevcenture.Rows[e.RowIndex];
            Control c1 = row.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            Control c2 = row.FindControl("TextBox2");
            TextBox t2 = (TextBox)c2;
            Control c3 = row.FindControl("TextBox3");
            TextBox t3 = (TextBox)c3;
            objbodevc.Devcid = t1.Text;
            objbodevc.Devcname = t2.Text;
            objbocity.cityid = t3.Text;
            int i = objblldevc.UpdateLoc(objbodevc,objbocity);
            if (i == 1)
            {
                lblmsggriddevc.Text = "Record updated successsfully.";

            }
            else
            { lblmsggriddevc.Text = "Failed"; }
           Gridfordevcenture.EditIndex = -1;
            Fillgrid();
        }

        protected void Gridfordevcenture_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Gridfordevcenture.EditIndex = -1;
        }

        protected void Gridfordevcenture_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Gridfordevcenture.EditIndex = -1;
            Fillgrid();
        }
    }
}