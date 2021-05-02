using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1_DataEntry : System.Web.UI.Page
{
    private SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('hello')", true);
        // Response.Redirect("Login.aspx");
        //if (Mobiletxt.Text.GetType() == typeof(int))
        //{
           
        //}
        //else
        //{
        //    errorText.Text = "Please Enter Mobile as a Integer";
        //    return;
        //}

        //if (Pincodetxt.Text.GetType() == typeof(int))
        //{

        //}
        //else
        //{
        //    errorText.Text = "Please Enter Pincode as a Integer";
        //    return;
        //}

        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);

        Customer customer = new Customer();
        customer.Name = Nametxt.Text.ToString();
        customer.Address = Addresstxt.Text.ToString();
        customer.City = Citytxt.Text.ToString();
        customer.Postcode = Postcodetxt.Text.ToString();
        customer.Mobile = Mobiletxt.Text.ToString();
        customer.Email = Emailtxt.Text.ToString();
        customer.Password = Passwordtxt.Text.ToString();

        errorText.Text = "";
        clsOrder order = new clsOrder();
        var data = order.RegisterValid(customer.Name,customer.Address,customer.City,customer.Postcode,customer.Mobile,customer.Email,customer.Password);

        if (data == "")
        {

            var nameValid = order.RegName(customer.Name);
            var addressValid = order.RegAddress(customer.Address);
            var cityValid = order.RegCity(customer.City);
            var postcodeValid = order.RegPostCode(customer.Postcode);
            var emailValid = order.RegEmail(customer.Email);
            var mobileValid = order.RegMobile(customer.Mobile);
            var passValid = order.RegPassword(customer.Password);


            nameError.Text =  nameValid;
            addressError.Text = addressValid;
            cityError.Text = cityValid;
            postcodeError.Text = postcodeValid;
            emailError.Text = emailValid;
            mobileError.Text = mobileValid;
            passwordError.Text = passValid;
    
            if(nameValid == "" && addressValid == "" && cityValid == "" && postcodeValid == "" && emailValid == "" && mobileValid == "" && passValid == "")
            {
                var response = AddCustomer(customer);
                if (response)
                {
                    Response.Redirect("OrdersLogin.aspx");
                }
            }           
        }
        else{
            if (data == "Please Enter Your Credentials")
            {
                errorText.Text = data;
            }
            else
            {
                errorText.Text = data;
            }
        }


    }

    public bool AddCustomer(Customer smodel)
    {

        SqlCommand cmd = new SqlCommand("AddNewCustomer", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@name", smodel.Name);
        cmd.Parameters.AddWithValue("@city", smodel.City);
        cmd.Parameters.AddWithValue("@address", smodel.Address);
        cmd.Parameters.AddWithValue("@passcode", smodel.Postcode);
        cmd.Parameters.AddWithValue("@mobile", smodel.Mobile);
        cmd.Parameters.AddWithValue("@email", smodel.Email);
        cmd.Parameters.AddWithValue("@password", smodel.Password);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();

        if (i >= 1)
            return true;
        else
            return false;
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
    }
}