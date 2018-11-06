using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using BusinessObject;
using System.Data;


namespace DataAccessLayer
{
   

    public class Login
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        BusinessObject.Login objbologin = new BusinessObject.Login();
        public int CheckLogin(BusinessObject.Login objbologin)
        {
            con.Open();
            string query = "select usertype='"+ objbologin.UserType + "' from login where  userid='" + objbologin.UserName + "' and  password='" + objbologin.Password + "'";
            SqlCommand cmd = new SqlCommand(query,con);
            int i =Convert.ToInt32( cmd.ExecuteScalar());
            con.Close();
            return i;

        }

    }
    public class Country
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());

        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public int Addcountry(BusinessObject.Country objbocountry)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("proc_autogenerateid", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coname",objbocountry.CountryName);
            int i = cmd.ExecuteNonQuery();
            return i;

        
        }
        public DataSet ViewCountry()
        {
            SqlDataAdapter da = new SqlDataAdapter("select coid ,coname from country",con);
            DataSet ds = new DataSet();
            da.Fill(ds,"country");
            return ds;
          }
        public int DeleteCountry(BusinessObject.Country objbocountry)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from country where coid='"+objbocountry.CountryId+"'",con);
            
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        
        }
       public int UpdateCountry(BusinessObject.Country objbocountry)
       { 
           con.Open();
           SqlCommand cmd=new SqlCommand("pro_UpdateCountry",con);
           cmd.CommandType=CommandType.StoredProcedure;
           cmd.Parameters.AddWithValue("@coname",objbocountry.CountryName);
            cmd.Parameters.AddWithValue("@coid",objbocountry.CountryId);
           int i=cmd.ExecuteNonQuery();
           con.Close();
        return i;
       }
    
    }
    public class state
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.state objbostate = new BusinessObject.state();
        public DataSet Fillddlcon()
        {
            SqlDataAdapter da = new SqlDataAdapter("select coid,coname from country",con);
            DataSet ds = new DataSet();
            da.Fill(ds,"country");
            return ds;
            
        }
        public int AddState(BusinessObject.state objbostate,BusinessObject.Country objbocounrty)
    {
        con.Open();
        SqlCommand cmd = new SqlCommand("pro_stateautoidadd ", con);
        cmd.CommandType = CommandType.StoredProcedure;
       // cmd.Parameters.AddWithValue("@sid", objbostate.stateid);
        cmd.Parameters.AddWithValue("@sname", objbostate.statename);
        cmd.Parameters.AddWithValue("@coid", objbocounrty.CountryId);
        int i = cmd.ExecuteNonQuery();
        return i;
    
    }
        public DataSet Fillgd()
        {
            SqlDataAdapter da = new SqlDataAdapter("pro_viewstate", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"state");
            return ds;
        
        }
        public int DeleteState(BusinessObject.state objbostate)
        {
            con.Open();

            SqlCommand cmd = new SqlCommand("pro_deletestate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sid",objbostate.stateid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Updatestate(BusinessObject.state objbostate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_updateState", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sname",objbostate.statename);
            cmd.Parameters.AddWithValue("@sid",objbostate.stateid);
            int i = cmd.ExecuteNonQuery();
            return i;

        }
    }
    public class City
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.Country objbocountry = new BusinessObject.Country();
        public DataSet FillddlofCountry()

        {
            SqlDataAdapter da = new SqlDataAdapter("pro_fillddlcity", con);
            DataSet ds = new DataSet();
            da.Fill(ds,"city");
            return ds;
        }
        public DataSet Fillstateddl(BusinessObject.Country objbocountry)
        {
            con.Open();
            
            SqlCommand cmd = new SqlCommand("pro_fillddlstate", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@coid",objbocountry.CountryId);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
           DataSet ds = new DataSet();
            //SqlDataReader dr = cmd.ExecuteReader();
            da.Fill(ds);
            con.Close();
            return ds;
          
        }
        public int AddCity(BusinessObject.City objbocity,BusinessObject.state objbostate,BusinessObject.Country objbocountry)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_addcity", con);
            cmd.CommandType = CommandType.StoredProcedure;
           
            cmd.Parameters.AddWithValue("@cityname", objbocity.cityname);
            cmd.Parameters.AddWithValue("@sid", objbostate.stateid);
            cmd.Parameters.AddWithValue("@coid", objbocountry.CountryId);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public DataSet Fillgridbycity()
        {
            SqlDataAdapter da = new SqlDataAdapter("pro_showcity", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public int Deletecity(BusinessObject.City objbocity)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_deletecity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityid",objbocity.cityid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public int Updatecity(BusinessObject.City objbocity,BusinessObject.Country objbocountry,BusinessObject.state objbostate)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_updatecity", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@cityname",objbocity.cityname);
            cmd.Parameters.AddWithValue("@cityid",objbocity.cityid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
    
    }
    public class DpartMent
    {
        BusinessObject.Department objbodept = new BusinessObject.Department();
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());   
        public int InsertDept(BusinessObject.Department objbodept)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_Departmentadd", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptname",objbodept.DeptName);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        public DataSet FillGrid()
        {
            SqlCommand cmd = new SqlCommand("pro_fillGrid", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }

        public int  DeleteDept(BusinessObject.Department objbodept)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_deleteDept",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptid",objbodept.Deptid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        
        }
        public int UpdateDepartment(BusinessObject.Department objbodept)
        {
            con.Open();
           
            SqlCommand cmd = new SqlCommand("pro_UpdateDept", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@deptid", objbodept.Deptid);
            cmd.Parameters.AddWithValue("@deptname", objbodept.DeptName);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
    }
    public class Location
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.Location objboloc = new BusinessObject.Location();
        BusinessObject.City objbocity = new BusinessObject.City();
        //DataAccessLayer.Location objbdalloc = new DataAccessLayer.Location();
        public DataSet FillCityddl()
        {
           // con.Open();
           // SqlCommand cmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter("pro_filldddlbycity", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        
        }
        public int AddLocation(BusinessObject.Location objboloc,BusinessObject.City objbocity)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_ADDlocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locname",objboloc.LocationName);
            cmd.Parameters.AddWithValue("@cityid",objbocity.cityid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataSet Fillgridofloc()
        {
            SqlDataAdapter da = new SqlDataAdapter("pro_fillgridbyloc", con);
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public int DeleteLoc(BusinessObject.Location objboloc)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_toDeleteLoc", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locid",objboloc.LocationId);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        
        }
        public int UpdateLocation(BusinessObject.Location objboloc, BusinessObject.City objbocity)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_UpdateLocation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@locid",objboloc.LocationId);
            cmd.Parameters.AddWithValue("@locname",objboloc.LocationName);
            cmd.Parameters.AddWithValue("@cityid",objbocity.cityid);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        
        }
    }
    public class DevolopementCenture
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.DevolopementCenture objbodevc = new BusinessObject.DevolopementCenture();
        public DataSet Fillddlbycity()
        {
            SqlCommand cmd = new SqlCommand("pro_fillddlbycityindev", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int AddDevCenture(BusinessObject.DevolopementCenture objbodevc,BusinessObject.Location objboloc)

        {
            con.Open();
            SqlCommand cmd = new SqlCommand("pro_AddindevCenture",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@devcname",objbodevc.Devcname);
            cmd.Parameters.AddWithValue("@locid",objboloc.LocationId);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;

        
        }
        public DataSet Bindgridbydevc()
        {
            SqlCommand cmd = new SqlCommand("select devcid,devcname from Devlcent", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        public int DeleteLoc(BusinessObject.DevolopementCenture objbodevc)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Devlcent where devcid='"+objbodevc.Devcid+"'", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        
        }
        public int UpdateLoc(BusinessObject.DevolopementCenture objbodevc,BusinessObject.City objbocity)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Devlcent set devcname='"+objbodevc.Devcname+"',cityid='"+objbocity.cityid+"'where devcid='"+objbodevc.Devcid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
    public class Designation
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.Department objbodept = new BusinessObject.Department();
        BusinessObject.Designation objbodeg = new BusinessObject.Designation();
        public DataSet Fillddlbycityindeg()
        {
            SqlDataAdapter da = new SqlDataAdapter("select deptid,deptname from Dept",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public string  AutogenrateIdofDesig()
        {
            con.Open();
           
            string query1 = "select degid from Designation where id in(select max(id) from Designation) ";
            SqlCommand cmd = new SqlCommand(query1,con);
            string s = cmd.ExecuteScalar().ToString();
            con.Close();
            return s;

        
        }
        public int ADDDesignation(BusinessObject.Designation objbodeg,BusinessObject.Department objbodept)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Designation values('" + objbodeg.degid + "','" + objbodeg.degname + "','" + objbodept.Deptid + "')", con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
           

        
        }
        public DataSet BindGridbydeg()
        {
            SqlDataAdapter da = new SqlDataAdapter("select*from Designation",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public int DeleteDeg(BusinessObject.Designation objbodeg)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from Designation where degid='"+objbodeg.degid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int Updatedeg(BusinessObject.Designation objbodeg)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update Designation set degname='"+objbodeg.degname+"' where degid='"+objbodeg.degid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
    public class Technology
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        BusinessObject.Technology objbotech = new BusinessObject.Technology();
        public string AutogenerateId()
        {
            con.Open();
            string query1 = "select techid from technology where id in(select max(id) from technology)";
            SqlCommand cmd = new SqlCommand(query1,con);
            string i = cmd.ExecuteScalar().ToString();
            con.Close();
            return i;
        }
        public int AddTech(BusinessObject.Technology objbotech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into technology values('"+objbotech.techid+"','"+objbotech.techname+"')",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataSet Bindgridbytech()
        {
            SqlDataAdapter da = new SqlDataAdapter("select*from technology",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public int DeleteTech(BusinessObject.Technology objbotech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("delete  from technology where techid='"+objbotech.techid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public int UpdateTech(BusinessObject.Technology objbotech)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("update technology set techname='"+objbotech.techname+"'where techid='"+objbotech.techid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
    }
    public class Employee
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        public string AutoGenEmpno()
        {
            if (con.State == ConnectionState.Open) {
                con.Close();
            }
            con.Open();
            string query1="select isnull(max(id),0) from empregister";
            SqlCommand cmd = new SqlCommand(query1,con);
            string ds = cmd.ExecuteScalar().ToString();
            //con.Close();
            return ds;
           
        }
        public DataSet BindDept()
        {
            SqlCommand cmd = new SqlCommand("select dno,dname from dept",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet DesignBind()
        {
            SqlCommand cmd = new SqlCommand("select desid,desname from designation",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public DataSet BindTech()
        {
            SqlCommand cmd = new SqlCommand("select techid,techname from technology",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
       }
        public DataSet Bindcountry()
        {
            SqlCommand cmd = new SqlCommand("select coid,coname from Country", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public DataSet Bindstate(BusinessObject.Country objbocountry)
        {
            SqlCommand cmd = new SqlCommand("select sid,sname from state where coid='"+objbocountry.CountryId+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public DataSet Bindcity(BusinessObject.state objbostate)
        {
            SqlCommand cmd = new SqlCommand("select cid,cname from city where sid='"+objbostate.stateid+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public DataSet Bindlocation(BusinessObject.City objbocity)
        {
            SqlCommand cmd = new SqlCommand("select lid,locname from location where cityid='"+objbocity.cityid+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public DataSet Binddevolpementcen(BusinessObject.Location  objboloc)
        {
            SqlCommand cmd = new SqlCommand("select devid,devname from DevelopmentCenter where lid='"+objboloc.LocationId+"'", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public int AddempDetails(BusinessObject.Employee objboemp,BusinessObject.Department objbodept,
            BusinessObject.Designation objbodeg,BusinessObject.Technology objbotech,BusinessObject.Country objbocountry,BusinessObject.state objbostate,BusinessObject.City objbocity,BusinessObject.Location objboloc,BusinessObject.DevolopementCenture objbodevcen)
        {
            con.Open();
            string query="insert into empregester values('"+objboemp.empno+"','"+objboemp.empname+"','"+objboemp.gender+"','"+objboemp.salary+"','"+objbodept.Deptid+"','"+objbodeg.degid+"','"+objbotech.techid+"','"+objbocountry.CountryId+"','"+objbostate.stateid+"','"+objbocity.cityid+"','"+objboloc.LocationId+"','"+objbodevcen.Devcid+"') ";
            SqlCommand cmd = new SqlCommand(query,con);
            int i = cmd.ExecuteNonQuery();
            return i;
        }
    }
    public class HrPart
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ToString());
        
        public DataSet FillTechnology()
        {
            SqlDataAdapter da = new SqlDataAdapter("select techid,techname from technology",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        
        }
        public int addsessiondetails(BusinessObject.HrPart objbhr, BusinessObject.Technology objbotech, BusinessObject.Country objbocountry, BusinessObject.state objbostate, BusinessObject.City objbocity, BusinessObject.Location objboloc, BusinessObject.DevolopementCenture objbodevc)
        {
            con.Open();
            string q = "insert into addsessiondetails values('" + objbhr.sessionid + "','" + objbotech.techid + "','" + objbhr.sdate + "','" + objbocountry.CountryId + "','" + objbostate.stateid + "','" + objbocity.cityid + "','" + objboloc.LocationId + "','" + objbodevc.Devcid + "','" + objbhr.topic + "','" + objbhr.timing + "')";
            SqlCommand cmd = new SqlCommand(q,con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public string AutoGenSesid()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
            string query1 = "select isnull(max(id),0) from session";
            SqlCommand cmd = new SqlCommand(query1, con);
            string ds = cmd.ExecuteScalar().ToString();
            //con.Close();
            return ds;

        }
        public DataSet BindGrid()
        {
            SqlDataAdapter da = new SqlDataAdapter("select*from session",con);
            DataSet ds = new DataSet();
            da.Fill(ds,"session");
            return ds;
        }
        public int DeleteSession(BusinessObject.HrPart objbohr)
        {
            if (con.State == ConnectionState.Open)
            { con.Close(); }
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from session where sid='"+objbohr.sessionid+"'",con);
            int i = cmd.ExecuteNonQuery();
            con.Close();
            return i;

        }
        public int UpdateSession(BusinessObject.HrPart objbhr, BusinessObject.Technology objbotech, BusinessObject.Country objbocountry, BusinessObject.state objbostate, BusinessObject.City objbocity, BusinessObject.Location objboloc, BusinessObject.DevolopementCenture objbodevc)
        {
            con.Open();
            SqlCommand cmd =new SqlCommand("Update session set technology='"+objbotech.techid+"', sdate='"+objbhr.sdate+"',country='"+objbocountry.CountryId+"',state='"+objbostate.stateid+"',city='"+objbocity.cityid+"',location='"+objboloc.LocationId+"',devc='"+objbodevc.Devcid+"',topic='"+objbhr.topic+"',timnig='"+objbhr.timing+"' where sesid='"+objbhr.sessionid+"'",con);
            int i=cmd.ExecuteNonQuery();
            con.Close();
            return i;
        }
        public DataSet SearchSession(BusinessObject.HrPart objbohr)
        {
            
            SqlCommand cmd = new SqlCommand("select technology,sdate,country,state,city,location,devc,topic,timnig from session where sid='"+objbohr.sessionid+"'",con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet i = new DataSet();
            da.Fill(i);
            return i;
        }

     
        public DataSet BindDDl()
        {
            SqlDataAdapter da = new SqlDataAdapter("select id, sid from session",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
    }
}
