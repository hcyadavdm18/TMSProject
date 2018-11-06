using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessObject;
using System.Data;
using DataAccessLayer;

namespace BusinessLogiclayer
{
    public class Login
    {
        DataAccessLayer.Login objDallogin = new DataAccessLayer.Login();
        public int CheckLogin(BusinessObject.Login objbologin)
        {
            int i = objDallogin.CheckLogin(objbologin);
            return i;
        }

    }
    public class Country
    {
        DataAccessLayer.Country objdalcountry = new DataAccessLayer.Country();
        
        public int Addcountry(BusinessObject.Country objbocountry)
        {
            int i = objdalcountry.Addcountry(objbocountry);
            return i;
        }
        public DataSet ViewCountry()
        {
            DataSet ds = objdalcountry.ViewCountry();
            return ds;
        
        }
        public int DeleteCountry(BusinessObject.Country objbocountry)
        {
            int i = objdalcountry.DeleteCountry(objbocountry);
            return i;
        
        }
        public int UpdateCountry(BusinessObject.Country objbocountry)
        {
            int i = objdalcountry.UpdateCountry(objbocountry);
            return i;
        }
    
    }
    public class state
    {
        DataAccessLayer.state objdalstate = new DataAccessLayer.state();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        BusinessObject.state objbostate = new BusinessObject.state();
        public int AddState(BusinessObject.state objbostate,BusinessObject.Country objbocountry)
        {
            int i = objdalstate.AddState(objbostate,objbocountry);
            return i;
        
        }
        public DataSet Fillddlconbind()
        {
            DataSet ds = objdalstate.Fillddlcon();
            return ds;
        }
        public DataSet Takegdvalu()
        {
            DataSet ds = objdalstate.Fillgd();
            return ds;
        }
        public int Deletestate(BusinessObject.state objbostate)
        {
            int i = objdalstate.DeleteState(objbostate);
            return i;
        }
        public int Updatestate(BusinessObject.state objbostate)
        {
            int i = objdalstate.Updatestate(objbostate);
            return i;
        }
    }
    public class city
    {
        DataAccessLayer.City objdalcity = new DataAccessLayer.City();
        DataAccessLayer.state objdalstate = new DataAccessLayer.state();
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public DataSet FillddlofCountry()
        {
            DataSet ds = objdalcity.FillddlofCountry();
            return ds;
        
        }
        public DataSet Fillstateddl(BusinessObject.Country objbocountry)
        {
            DataSet ds = objdalcity.Fillstateddl(objbocountry);
            return ds;

        }
        public DataSet Fillstateddlbll(BusinessObject.Country objbocountry)
        {
            DataSet ds =objdalcity.Fillstateddl(objbocountry);
            return ds;
        
        }
        public int AddCity(BusinessObject.City objbocity, BusinessObject.state objbostate,BusinessObject.Country objbocountry)
        {
            int i = objdalcity.AddCity(objbocity,objbostate,objbocountry);
            return i;
        }

        public DataSet Fillgridbycity()
        {
            DataSet ds = objdalcity.Fillgridbycity();
            return ds;

        }
        public int Deletecity(BusinessObject.City objbocity)
        {
            int i = objdalcity.Deletecity(objbocity);
            return i;
        }
        public int Updatecity(BusinessObject.City objbocity, BusinessObject.Country objbocountry, BusinessObject.state objbostate)
        {

            int i = objdalcity.Updatecity(objbocity,objbocountry,objbostate);
            return i;
        }
    }
    public class Department
    {
        DataAccessLayer.DpartMent objdaldept = new DataAccessLayer.DpartMent();
        BusinessObject.Department objbodept = new BusinessObject.Department();
        public int InsertDept(BusinessObject.Department objbodept)
        {
            int i = objdaldept.InsertDept(objbodept);
            return i;
        }
        public int DeleteDept(BusinessObject.Department objbodept)
        {
            int i = objdaldept.DeleteDept(objbodept);
            return i;
        
        }
        public DataSet FillGrid()
        {
            DataSet ds = objdaldept.FillGrid();
            return ds;
        }
        public int UpdateDepartment(BusinessObject.Department objbodept)
        {
            int i = objdaldept.UpdateDepartment(objbodept);
            return i;
        }
    }
    public class Location
    {
        DataAccessLayer.Location objdallocation = new DataAccessLayer.Location();
        BusinessObject.Location objboloc = new BusinessObject.Location();
        public DataSet FillCityddl()
        {
            DataSet ds = objdallocation.FillCityddl();
            return ds;
        
        }
        public int AddLocation(BusinessObject.Location objboloc,BusinessObject.City objbocity)
        {
            int i = objdallocation.AddLocation(objboloc,objbocity);
            return i;
        }
        public DataSet Fillgridofloc()
        {
            DataSet ds = objdallocation.Fillgridofloc();
            return ds;

        }
        public int DeleteLoc(BusinessObject.Location objboloc)
        {
            int i = objdallocation.DeleteLoc(objboloc);
            return i;
        }
        public int UpdateLocation(BusinessObject.Location objboloc, BusinessObject.City objbocity)
        {
            int i = objdallocation.UpdateLocation(objboloc,objbocity);
            return i;
        }
    }
    public class DevolopementCenture
    {
        DataAccessLayer.DevolopementCenture objdaldevc = new DataAccessLayer.DevolopementCenture();
        BusinessObject.City objbocity = new BusinessObject.City();
        BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
        public DataSet Fillddlbycity()
        {
            DataSet ds = objdaldevc.Fillddlbycity();
            return ds;
        }
        public int AddDevCenture(BusinessObject.DevolopementCenture objbodevc, BusinessObject.Location objboloc)
        {
            int i = objdaldevc.AddDevCenture(objbodevc,objboloc);
            return i;
        }
        public DataSet Bindgridbydevc()
        {
            DataSet ds = objdaldevc.Bindgridbydevc();
            return ds;
        }
        public int DeleteLoc(BusinessObject.DevolopementCenture objbodevc)
        {

            int i = objdaldevc.DeleteLoc(objbodevc);
            return i;
        }
        public int UpdateLoc(BusinessObject.DevolopementCenture objbodevc,BusinessObject.City objbocity)
        {
            int i = objdaldevc.UpdateLoc(objbodevc,objbocity);
            return i;
           
        }
    }
    public class Designation
    {
        DataAccessLayer.Designation objdaldeg = new DataAccessLayer.Designation();
        public DataSet Fillddlbycityindeg()
        {
            DataSet ds = objdaldeg.Fillddlbycityindeg();
            return ds;
        }
        public string AutogenrateIdofDesig()
        {
            string s = objdaldeg.AutogenrateIdofDesig();
            return s;
        
        }
        public int ADDDesignation(BusinessObject.Designation objbodeg,BusinessObject.Department objbodept)
        {
            int i = objdaldeg.ADDDesignation(objbodeg,objbodept);
            return i;
        }
        public DataSet BindGridbydeg()
        {

            DataSet ds = objdaldeg.BindGridbydeg();
            return ds;
        }
             public int DeleteDeg(BusinessObject.Designation objbodeg)
             {
             
             int i=objdaldeg.DeleteDeg(objbodeg);
                 return i;
             }
             public int Updatedeg(BusinessObject.Designation objbodeg)
             {
                 int i = objdaldeg.Updatedeg(objbodeg);
                 return i;
             }
    }
    public class Technology
    {
        DataAccessLayer.Technology objdaltech = new DataAccessLayer.Technology();
        public string AutogenerateId()
        {
            string  i = objdaltech.AutogenerateId();
            return i;
        }
        public int AddTech(BusinessObject.Technology objbotech)
        {
            int i = objdaltech.AddTech(objbotech);
            return i;
        }
        public DataSet Bindgridbytech()
        {
            DataSet ds = objdaltech.Bindgridbytech();
            return ds;
        }
        public int DeleteTech(BusinessObject.Technology objbotech)
        {
            int i = objdaltech.DeleteTech(objbotech);
            return i;
        }

        public int UpdateTech(BusinessObject.Technology objbotech)
        {
            int i = objdaltech.UpdateTech(objbotech);
            return i;
        }
    }
    public class Employee
    {
        DataAccessLayer.Employee objdalemp = new DataAccessLayer.Employee();
        public string AutoGenEmpno()
        {
            string ds = objdalemp.AutoGenEmpno();
            return ds;
           
        }
        public DataSet BindDept()
        {
            DataSet ds = objdalemp.BindDept();
            return ds;
        }
        public DataSet DesignBind()
        {
            DataSet ds = objdalemp.DesignBind();
            return ds;
        }
        public DataSet BindTech()
        {
            DataSet ds = objdalemp.BindTech();
            return ds;
        }
        public DataSet Bindcountry()
        {
            DataSet ds = objdalemp.Bindcountry();
            return ds;
        }
        public DataSet Bindstate(BusinessObject.Country objbocountry)
        {
            DataSet ds = objdalemp.Bindstate(objbocountry);
            return ds;

        }
        public DataSet Bindcity(BusinessObject.state objbostate)
        {
            DataSet ds = objdalemp.Bindcity(objbostate);
            return ds;

        
        }
        public DataSet Bindlocation(BusinessObject.City objbocity)
        {
            DataSet ds = objdalemp.Bindlocation(objbocity);
            return ds;
        }
        public DataSet binddevcen(BusinessObject.Location objboloc)
        {
            DataSet ds = objdalemp.Binddevolpementcen(objboloc);
            return ds;
        }

        public int AddempDetails(BusinessObject.Employee objboemp, BusinessObject.Department objbodept, BusinessObject.Designation objbodeg, BusinessObject.Technology objbotech, BusinessObject.Country objbocountry, BusinessObject.state objbostate, BusinessObject.City objbocity, BusinessObject.Location objboloc, BusinessObject.DevolopementCenture objbodevcen)
        {
            int i = objdalemp.AddempDetails(objboemp,objbodept,objbodeg,objbotech,objbocountry,objbostate,objbocity, objboloc,objbodevcen);
            return i;
        }
    }
    public class HrPart
    {
        DataAccessLayer.HrPart objdalhr = new DataAccessLayer.HrPart();
        public DataSet Filltechnology()
        {
            DataSet ds = objdalhr.FillTechnology();
            return ds;

        }
        public int addsessiondetails(BusinessObject.HrPart objbhr, BusinessObject.Technology objbotech, BusinessObject.Country objbocountry, BusinessObject.state objbostate, BusinessObject.City objbocity, BusinessObject.Location objboloc, BusinessObject.DevolopementCenture objbodevc)
        {
            int i = objdalhr.addsessiondetails(objbhr,objbotech,objbocountry,objbostate,objbocity,objboloc,objbodevc);
            return i;

        }
        public string AutoGenSesid()
        {
            string ds = objdalhr.AutoGenSesid();
            return ds;
        }
        public DataSet BindGridofAddses()
        {
            DataSet ds = objdalhr.BindGrid();
            return ds;
        }
        public int DeleteSession(BusinessObject.HrPart objbohr)
        {
            int i = objdalhr.DeleteSession(objbohr);
            return i;
        }
        public int UpdateSession(BusinessObject.HrPart objbohr, BusinessObject.Technology objbotech, BusinessObject.Country objbocountry, BusinessObject.state objbostate, BusinessObject.City objbocity, BusinessObject.Location objboloc, BusinessObject.DevolopementCenture objbodevc)
        {
            int i = objdalhr.UpdateSession(objbohr,objbotech,objbocountry,objbostate,objbocity,objboloc,objbodevc);
            return i;
        }
        public DataSet SearchSession(BusinessObject.HrPart objbohr)
        {
            DataSet i = objdalhr.SearchSession(objbohr);
            return i;
        
        }
        public DataSet BindDdl()
        {
            DataSet ds = objdalhr.BindDDl();
            return ds;
        }
    }
}
