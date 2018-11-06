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
   
    public partial class ViewDesignation : System.Web.UI.Page
    {
        BusinessLogiclayer.Designation objblldeg = new BusinessLogiclayer.Designation();
        BusinessObject.Designation objbodeg = new BusinessObject.Designation();
        public void Fillgridbydeg()
        {
            DataSet ds = objblldeg.BindGridbydeg();
            gridfordeg.DataSource = ds;
            gridfordeg.DataBind();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            { Fillgridbydeg(); }

        }


        protected void gridfordeg_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row=gridfordeg.Rows[e.RowIndex];
            Control c1 =row.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            
            Control c2 = row.FindControl("TextBox2");
            TextBox t2=(TextBox)c2;
           
            objbodeg.degid = t1.Text;
            objbodeg.degname = t2.Text;
            int i = objblldeg.Updatedeg(objbodeg);
            if (i == 1)
            { lblmsgdeg.Text = "Record Updated successfully."; }
            else
            { lblmsgdeg.Text = "Failed"; }
            gridfordeg.EditIndex = -1;
            Fillgridbydeg();


        }

        protected void gridfordeg_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridfordeg.EditIndex = -1;
        }

        protected void gridfordeg_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridfordeg.EditIndex = -1;
            Fillgridbydeg();
        }

        protected void gridfordeg_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row=gridfordeg.Rows[e.RowIndex];
            Control c1 = row.FindControl("Label1");
            Label l1=(Label)c1;
            objbodeg.degid = l1.Text;
            int i = objblldeg.DeleteDeg(objbodeg);
            if (i == 1)
            {
                lblmsgdeg.Text = "Record Deleted successfully.";
            }
            else
            { lblmsgdeg.Text = "Failed"; }
            gridfordeg.EditIndex = -1;
            Fillgridbydeg();

            
        }
    }
}