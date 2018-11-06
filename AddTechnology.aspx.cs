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
    public partial class AddTechnology : System.Web.UI.Page
    {
        BusinessLogiclayer.Technology objbllltech = new BusinessLogiclayer.Technology();
        BusinessObject.Technology objbotech = new BusinessObject.Technology();
        public void Filltxtid()
        {
            string i= objbllltech.AutogenerateId();
            string[] a = i.Split('_');
            int k = int.Parse(a[1]);
            k++;
            string t = "tech_"+k.ToString();
           
            
            txttechid.Text =t;

        
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            { Filltxtid(); }

        }

        protected void btnaddoftech_Click(object sender, EventArgs e)
        {
            objbotech.techid = txttechid.Text;
            objbotech.techname = txttechname.Text;
            int i = objbllltech.AddTech(objbotech);
            if (i == 1)
            {
                lblmsgoftech.Text = "Record added successfully.";
            }
            else
            { lblmsgoftech.Text = "Failed."; }
            Filltxtid();
        }
    }
}