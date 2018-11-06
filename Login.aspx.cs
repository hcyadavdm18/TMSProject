using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogiclayer;
using BusinessObject;

namespace PresentationLayer
{
    public partial class Login : System.Web.UI.Page
    {
        BusinessLogiclayer.Login objblllogin = new BusinessLogiclayer.Login();
        BusinessObject.Login objbologin = new BusinessObject.Login();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            objbologin.UserName = txtusername.Text;
            objbologin.Password = txtloginpwd.Text;
            objbologin.UserType = DropDownList1.SelectedValue;
            int i = objblllogin.CheckLogin(objbologin);
            if (i == 1)
            {

                Response.Redirect("/Adminfolder/HomeAdmin.aspx");
            }
            else if (i == 2)
            {
                Response.Redirect("/HRFolder/HrHomepage.aspx");

            }
            else
            {
                Console.Write("Invalid user");
            }
            
        }

        protected void Btnregister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

       

       
       
       
     

       
    }
}