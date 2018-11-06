using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessObject
{
    public class Empregister {
        public string EmployeeId { set; get; }
        public string EmpName { set; get; }
        public string EmpFname { set; get; }
        public string Gender { set; get; }
        public string Age { set; get; }
        public string MobilNo{ set; get; }
        public string AltMobile { set; get; }
        public string EmailAddress { set; get; }
        public string Dob { set; get; }
        public string Religions { set; get; }
        public string  LocalAddress { set; get; }
        public string PermanentAddress { set; get; }
        
    }
    public class Login
    {
        public string UserName { set; get; }
        public string Password { set; get; }
        public string UserType { set; get; }
    }
    public class Country
    {
        public string CountryName { set; get; }
        public string CountryId { set; get; }
     }
    public class state
    {
        public string stateid { set; get; }
        public string statename { set; get; }
    
    }
    public class City
    {
        public string cityid { set; get; }
        public string cityname { set; get; }
    }
    public class Department
    {
        public string Deptid { set; get; }
        public string DeptName { set; get; }
    
    }
    public class Location
    {
        public string LocationId { set; get; }
        public string LocationName { set; get; }
    }
    public class DevolopementCenture
    {
        public string Devcid { set; get; }
        public string Devcname { set; get; }
    
    }
    public class Designation
    {
        public string degid { set; get; }
        public string degname { set; get; }
       // public string Identity { set; get; }
    }
    public class Technology
    {
        public string techid { set; get; }
        public string techname { set; get; }
    }
    public class Employee
    {
        public string empno { set; get; }
        public string empname { set; get; }
        public string salary { set; get; }
        public string gender { set; get; }
    }
    public class HrPart
    {
        public string sessionid { set; get; }
        public string timing { set; get;}
        public string topic { set; get; }
        public string sdate { set; get; }
        public string id { set; get; }

    }
   

}
