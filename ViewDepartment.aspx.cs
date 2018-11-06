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
    public partial class ViewDepartment : System.Web.UI.Page
    {
        BusinessLogiclayer.Department objblldept = new BusinessLogiclayer.Department();
        BusinessObject.Department objbodept = new BusinessObject.Department();
        public void  FillGrid()
        {
            DataSet ds = objblldept.FillGrid();
            griddept.DataSource = ds;
            griddept.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                FillGrid();
            }
        }

       

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow rowofgrid=griddept.Rows[e.RowIndex];
            Control c1 = rowofgrid.FindControl("TextBox1");
            TextBox t1=(TextBox)c1;
            Control c2 = rowofgrid.FindControl("TextBox2");
            TextBox t2=(TextBox)c2;
            objbodept.Deptid = t1.Text;
            objbodept.DeptName = t2.Text;
            int i = objblldept.UpdateDepartment(objbodept);
            if (i == 1)
            { lblmsgDept.Text = "Department Updated successfully."; }
            else
            { lblmsgDept.Text = "Failed."; }
            griddept.EditIndex = -1;
            FillGrid();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            griddept.EditIndex = -1;
           // FillGrid();

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
           GridViewRow row=griddept.Rows[e.RowIndex];
           Control c1 = row.FindControl("Label1");
               Label l1=(Label)c1;
               objbodept.Deptid = l1.Text;

               int i = objblldept.DeleteDept(objbodept);
               if (i == 1)
               { lblmsgDept.Text = "Department deleted successfully."; }
               else
               { lblmsgDept.Text = "Failed"; }

        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            griddept.EditIndex = -1;
            FillGrid();
          

        }
    }
}