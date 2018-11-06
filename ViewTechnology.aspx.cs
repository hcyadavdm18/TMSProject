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
    public partial class ViewTechnology : System.Web.UI.Page
    {
        BusinessLogiclayer.Technology objblltech = new BusinessLogiclayer.Technology();
        BusinessObject.Technology objbotech = new BusinessObject.Technology();
        public void Fillgrid()
        {
            DataSet ds = objblltech.Bindgridbytech();
            gridtechnology.DataSource = ds;
            gridtechnology.DataBind();


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { Fillgrid(); }
        }

        protected void gridtechnology_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gridtechnology_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row=gridtechnology.Rows[e.RowIndex];
            Control c1 = row.FindControl("TextBox1");
            TextBox t1 = (TextBox)c1;
            Control c2 = row.FindControl("TextBox2");
            TextBox t2 = (TextBox)c2;
            objbotech.techid = t1.Text;
            objbotech.techname = t2.Text;
            int i = objblltech.UpdateTech(objbotech);
            if (i == 1)
            { lblmsgtech.Text = "Record Updated Successfully"; }
            else
            { lblmsgtech.Text = "Failed"; }
            gridtechnology.EditIndex = -1;
            Fillgrid();

        }

        protected void gridtechnology_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gridtechnology.EditIndex = -1;

        }

        protected void gridtechnology_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gridtechnology.EditIndex = -1;
            Fillgrid();
        }

        protected void gridtechnology_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gridtechnology.Rows[e.RowIndex];
            Control c1 = row.FindControl("Label1");
            Label l1=(Label)c1;
            objbotech.techid = l1.Text;
            int i = objblltech.DeleteTech(objbotech);
            if (i == 1)
            { lblmsgtech.Text = "Record deleted successfully."; }
            else
            { lblmsgtech.Text = "Failed."; }
            gridtechnology.EditIndex = -1;
            Fillgrid();
        }
    }
}