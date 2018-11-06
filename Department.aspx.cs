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
    public partial class Department : System.Web.UI.Page
    {
        BusinessLogiclayer.Department objblldept = new BusinessLogiclayer.Department();
        BusinessObject.Department objbodept = new BusinessObject.Department();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnaddd_Click(object sender, EventArgs e)
        {
            objbodept.DeptName = txtdeptname.Text;
            int i = objblldept.InsertDept(objbodept);
            if (i == 1)
            { lblmsgdept.Text = "Department name and Department id added successfully."; }
            else
            { lblmsgdept.Text = "Failed"; }
        }
    }
}