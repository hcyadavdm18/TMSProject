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
    public partial class AddDesignation : System.Web.UI.Page
    {
        BusinessLogiclayer.Designation objbldeg = new BusinessLogiclayer.Designation();
        BusinessObject.Designation objbodeg = new BusinessObject.Designation();
        BusinessObject.Department objbodept = new BusinessObject.Department();
        public void Fiilldddbydept()
        {
            DataSet ds = objbldeg.Fillddlbycityindeg();
            ddlselectdept.DataSource = ds;
            ddlselectdept.DataTextField = "deptname";
            ddlselectdept.DataValueField = "deptid";
            ddlselectdept.DataBind();

        }
       
        public void Filltxtdegid()
        {
            string s = objbldeg.AutogenrateIdofDesig();
            string[] s1 = s.Split('_');
            int i = int.Parse(s1[1]);
            i++;
            string deid="degid_"+i;
            txtdesgid.Text = deid;


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { Fiilldddbydept();
            Filltxtdegid();
            }

        }

        protected void btnadddesig_Click(object sender, EventArgs e)
        {
            objbodeg.degid = txtdesgid.Text;
            objbodeg.degname = txtdegidname.Text;
            objbodept.Deptid = ddlselectdept.SelectedValue;
           // int j=2;
           // objbodeg.Identity = (j).ToString();
           // j++;
            int i = objbldeg.ADDDesignation(objbodeg,objbodept);
            if (i == 1)
            { lblmsgdegid.Text = "Record Added successfully."; }
            else { lblmsgdegid.Text = "Failed"; }
            Filltxtdegid();
           
        }
       
    }
}