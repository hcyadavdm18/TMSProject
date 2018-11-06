using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLogiclayer;
using BusinessObject;

namespace PresentationLayer
{
    public partial class Register : System.Web.UI.Page
    {
        BusinessLogiclayer.Employee objbllemp = new BusinessLogiclayer.Employee();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        BusinessObject.state objbostate = new BusinessObject.state();
        BusinessObject.City objbocity = new BusinessObject.City();
        BusinessObject.Location objboloc = new BusinessObject.Location();
        BusinessObject.Technology objbotech = new BusinessObject.Technology();
        BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
        BusinessObject.Designation objbodeg = new BusinessObject.Designation();
        BusinessObject.Department objbodept = new BusinessObject.Department();
        BusinessObject.Employee objboemp = new BusinessObject.Employee();
       
       // BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
       // BusinessObject.Location objboloc = new BusinessObject.Location();
        public void Filltxtempeno()
        {

            string ds = objbllemp.AutoGenEmpno();
            int i = int.Parse(ds);
            i++;
            string s = "eno_" + i;
            txtempno.Text = s;
        }
        public void Fillddldept()
        {
            DataSet ds = objbllemp.BindDept();
            ddlselectdept.DataSource = ds;
            ddlselectdept.Items.Add("--Select Department--");
            ddlselectdept.DataTextField = "deptname";
            ddlselectdept.DataValueField = "deptid";
            
            ddlselectdept.DataBind();

        }
        public void Filldesig()
        {
            DataSet ds = objbllemp.DesignBind();
            ddlselectdeg.DataSource = ds;
            ddlselectdeg.DataTextField = "degname";
            ddlselectdeg.DataValueField = "degid";
            ddlselectdeg.DataBind();

        
        }
        public void Fillcountyun()
        {
            DataSet ds = objbllemp.Bindcountry();
            ddlselectcountry.DataSource=ds;
            ddlselectcountry.DataTextField = "coname";
            ddlselectcountry.DataValueField = "coid";
            ddlselectcountry.DataBind();
        }
     /*   public void Fillstate()
        {
            DataSet ds = objbllemp.Bindstate(objbocountry);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "sname";
            ddlstate.DataValueField = "sid";
            ddlstate.DataBind();
        
        }*/
      /*  public void Fillcity()
        {
            DataSet ds = objbllemp.Bindcity();
            ddlcity.DataSource = ds;
            ddlcity.DataTextField = "cityname";
            ddlcity.DataValueField = "cityid";
            ddlcity.DataBind();

        
        */
      /*  public void Fililocation()
        {
            DataSet ds = objbllemp.Bindlocation();
            ddllocation.DataSource = ds;
            ddllocation.DataTextField = "locname";
            ddllocation.DataValueField = "locid";
            ddllocation.DataBind();
        
        }*/
       /* public void Filldevlopecen()
        {
            DataSet ds = objbllemp.binddevcen();
            ddldevlopementcen.DataSource = ds;
            ddldevlopementcen.DataTextField = "devcname";
            ddldevlopementcen.DataValueField = "devcid";
            ddldevlopementcen.DataBind();
        
        }*/


        public void Filltechnology()
        {
            DataSet ds = objbllemp.BindTech();
            ddltechnology.DataSource = ds;
            ddltechnology.DataTextField = "techname";
            ddltechnology.DataValueField = "techid";
            ddltechnology.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { Filltxtempeno();
            Fillddldept();
            Filldesig();
            Filltechnology();
         //   Fillstate();
           // Fililocation();
           // Filldevlopecen();
            Fillcountyun();
           // Fillcity();
                
            }

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            objboemp.empno = txtempno.Text;
            objboemp.empname = txtempname.Text;
            objboemp.gender = rbtngenderm.Text;
            objboemp.gender = rbtngenderf.Text;


           // objboemp.gender = rbtngender.Text;
            objboemp.salary = txtsalary.Text;
            objbodept.Deptid = ddlselectdept.SelectedValue;
            objbodeg.degid = ddlselectdeg.SelectedValue;
            objbotech.techid = ddltechnology.SelectedValue;
            objbocountry.CountryId = ddlselectcountry.SelectedValue;
            objbostate.stateid = ddlstate.SelectedValue;
            objbocity.cityid = ddlcity.SelectedValue;
            objboloc.LocationId = ddllocation.SelectedValue;
            objbodevc.Devcid = ddldevlopementcen.SelectedValue;
            int i = objbllemp.AddempDetails(objboemp, objbodept, objbodeg, objbotech, objbocountry, objbostate, objbocity, objboloc, objbodevc);
            if (i == 1)
            { lblmsgreg.Text = "Record inserted successfully"; }
            else
            { lblmsgreg.Text = "Failed"; }
            Filltxtempeno();
            txtempname.Text = "";
            txtsalary.Text = "";
          
            
        }

        protected void ddlselectcountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            objbocountry.CountryId = ddlselectcountry.SelectedValue;
           
            DataSet ds = objbllemp.Bindstate(objbocountry);
            ddlstate.DataSource = ds;
            ddlstate.DataTextField = "sname";
            ddlstate.DataValueField = "sid";
            ddlstate.DataBind();
           
        }

        protected void ddlstate_SelectedIndexChanged(object sender, EventArgs e)
        {
            objbostate.stateid = ddlstate.SelectedValue;

            DataSet ds = objbllemp.Bindcity(objbostate);
            ddlcity.DataSource = ds;
            ddlcity.DataTextField = "cityname";
            ddlcity.DataValueField = "cityid";
            ddlcity.DataBind();
        }

        protected void ddlcity_SelectedIndexChanged(object sender, EventArgs e)
        {
            objbocity.cityid = ddlcity.SelectedValue;
            DataSet ds = objbllemp.Bindlocation(objbocity);
            ddllocation.DataSource = ds;
            ddllocation.DataTextField = "locname";
            ddllocation.DataValueField = "locid";
            ddllocation.DataBind();
        }

        protected void ddllocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            objboloc.LocationId = ddllocation.SelectedValue;
            DataSet ds = objbllemp.binddevcen(objboloc);
            ddldevlopementcen.DataSource = ds;
            ddldevlopementcen.Items.Clear();
            ddldevlopementcen.Items.Add("--Select DevoiopeMentC--");
            ddldevlopementcen.DataTextField = "devcname";
            ddldevlopementcen.DataValueField = "devcid";
            ddldevlopementcen.DataBind();
        }
    }
}