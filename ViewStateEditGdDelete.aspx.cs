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
    public partial class ViewStateEditGdDelete : System.Web.UI.Page
    {
        BusinessLogiclayer.state objbllstate = new BusinessLogiclayer.state();
        BusinessObject.state objbostate = new BusinessObject.state();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public void FillGdbystate()
        {
            DataSet ds = objbllstate.Takegdvalu();
            gridstaate.DataSource = ds;
            gridstaate.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack==false)
            {
                FillGdbystate();
            }

        }

    

        protected void gridstaate_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridstaate.EditIndex = -1;
        }

        protected void gridstaate_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridstaate.EditIndex = -1;
            FillGdbystate();
        }

        protected void gridstaate_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            GridViewRow row = gridstaate.Rows[e.RowIndex];
            Control c1 = row.FindControl("Label1");
            Label l1 = (Label)c1;
           objbostate.stateid = l1.Text;
            int i = objbllstate.Deletestate(objbostate);
            FillGdbystate();
            if (i == 1)
            {
                lblmasgsataegriddelete.Text = "record is deleted";

            }
            else
            { lblmasgsataegriddelete.Text = "Failed"; }
        }

        protected void gridstaate_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row=gridstaate.Rows[e.RowIndex];
            Control c1=row.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            Control c2=row.FindControl("TextBox2");
            TextBox t2=(TextBox)c2;
         /* Control c3=row.FindControl("TextBox3");
            TextBox t3=(TextBox)c3;
            Control c4=row.FindControl("TextBox4");
            TextBox t4=(TextBox)c4;*/
            objbostate.stateid=t1.Text;
            objbostate.statename=t2.Text;
            //objbocountry.CountryId = t3.Text;

            int i = objbllstate.Updatestate(objbostate);
            if (i == 1)
            { lblmasgsataegriddelete.Text = "Record is updated"; }
            else { lblmasgsataegriddelete.Text = "Failed"; }
            gridstaate.EditIndex = -1;
            FillGdbystate();
        }

      
    }
}