using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObject;
using BusinessLogiclayer;
using System.Data;

namespace PresentationLayer.Adminfolder
{
    public partial class ViewLocationdetals : System.Web.UI.Page
    {
        BusinessLogiclayer.Location objbllloc = new BusinessLogiclayer.Location();
        BusinessObject.Location objboloc = new BusinessObject.Location();
        BusinessObject.City objbocity = new BusinessObject.City();
          public void FillgridbyLocation()
        {
            DataSet ds = objbllloc.Fillgridofloc();
            gridforloc.DataSource = ds;
            gridforloc.DataBind();
        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                FillgridbyLocation();
            }
        }

       

        protected void gridforloc_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row=gridforloc.Rows[e.RowIndex];
            Control c1 = row.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            Control c2 = row.FindControl("TextBox2");
            TextBox t2 = (TextBox)c2;
            Control c3 = row.FindControl("TextBox3");
            TextBox t3= (TextBox)c3;
            objboloc.LocationId = t1.Text;
            objboloc.LocationName = t2.Text;
            objbocity.cityid = t3.Text;
            int i = objbllloc.UpdateLocation(objboloc,objbocity);
            if (i == 1)
            {
                lblmsgloc.Text = "Record Updated successfully";
            }
            else
            { lblmsgloc.Text = "Failed"; }
            gridforloc.EditIndex = -1;
            FillgridbyLocation();
            

        }

        protected void gridforloc_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridforloc.EditIndex = -1;
        }

        protected void gridforloc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridforloc.EditIndex = -1;
            FillgridbyLocation();
        }

        protected void gridforloc_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row=gridforloc.Rows[e.RowIndex];
            Control c1 = row.FindControl("Label1");
            Label l1=(Label)c1;
            objboloc.LocationId = l1.Text;
            int i = objbllloc.DeleteLoc(objboloc);
            if (i == 1)
            { lblmsgloc.Text = "Record deleted successfully."; }
            else { lblmsgloc.Text = "Failed"; }
            gridforloc.EditIndex = -1;
            FillgridbyLocation();
        }
    }
}