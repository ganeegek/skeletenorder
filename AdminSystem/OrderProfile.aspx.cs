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

public partial class OrderProfile : System.Web.UI.Page
{
    private SqlConnection con;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            if (Session["UserName"] == null)
            {
                Response.Redirect("OrdersLogin.aspx");
            }
            var username = Session["UserName"].ToString();
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(constring);
            var listCustomer = GetStudent(username);
            if (listCustomer.Count > 0)
            {
                txt_Nametxt.Text = listCustomer[0].Name;
                txt_Addresstxt.Text = listCustomer[0].Address;
                txt_Citytxt.Text = listCustomer[0].City;
                txt_Postcodetxt.Text = listCustomer[0].Postcode;
                txt_Mobiletxt.Text = listCustomer[0].Mobile;
                txt_Emailtxt.Text = listCustomer[0].Email;
                txt_Passwordtxt.Text = listCustomer[0].Password;
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);

        // var value  = text1.Text; 


        Customer customer = new Customer();
        customer.Name = txt_Nametxt.Text.ToString();
        customer.Address = txt_Addresstxt.Text.ToString();
        customer.City = txt_Citytxt.Text.ToString();
        customer.Postcode = txt_Postcodetxt.Text.ToString();
        customer.Mobile = txt_Mobiletxt.Text.ToString();
        customer.Email = txt_Emailtxt.Text.ToString();
        customer.Password = txt_Passwordtxt.Text.ToString();

        clsOrder order = new clsOrder();
        var data = order.RegisterValid(customer.Name, customer.Address, customer.City, customer.Postcode, customer.Mobile, customer.Email, customer.Password);

        if (data == "")
        {

            var nameValid = order.RegName(customer.Name);
            var addressValid = order.RegAddress(customer.Address);
            var cityValid = order.RegCity(customer.City);
            var postcodeValid = order.RegPostCode(customer.Postcode);
            var emailValid = order.RegEmail(customer.Email);
            var mobileValid = order.RegMobile(customer.Mobile);
            var passValid = order.RegPassword(customer.Password);


            nameError.Text = nameValid;
            addressError.Text = addressValid;
            cityError.Text = cityValid;
            postcodeError.Text = postcodeValid;
            emailError.Text = emailValid;
            mobileError.Text = mobileValid;
            passwordError.Text = passValid;

            if (nameValid == "" && addressValid == "" && cityValid == "" && postcodeValid == "" && emailValid == "" && mobileValid == "" && passValid == "")
            {
                var response = UpdateCustomer(customer);
                if (response)
                {
                    Response.Redirect("OrdersLogin.aspx");
                }
            }
        }
        else
        {
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

    public bool UpdateCustomer(Customer smodel)
    {

        SqlCommand cmd = new SqlCommand("UpdateCustomer", con);
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
    public List<Customer> GetStudent(string email)
    {
        List<Customer> studentlist = new List<Customer>();

        SqlCommand cmd = new SqlCommand("CustomerDetail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@email", email);
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        con.Open();
        sd.Fill(dt);
        con.Close();

        foreach (DataRow dr in dt.Rows)
        {
            studentlist.Add(
                new Customer
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = Convert.ToString(dr["Name"]),
                    City = Convert.ToString(dr["City"]),
                    Address = Convert.ToString(dr["Address"]),
                    Password = Convert.ToString(dr["Password"]),
                    Email = Convert.ToString(dr["Email"]),
                    Mobile = Convert.ToString(dr["Mobile"]),
                    Postcode = Convert.ToString(dr["Postcode"])
                });
        }
        return studentlist;
    }
}

public class Customer
{
    [Display(Name = "Id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "First name is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "City is required.")]
    public string City { get; set; }

    [Required(ErrorMessage = "Address is required.")]
    public string Address { get; set; }

    [Required(ErrorMessage = "Postcode is required.")]
    public string Postcode { get; set; }

    [Required(ErrorMessage = "Email is required.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "Mobile is required.")]
    public string Mobile { get; set; }

    [Required(ErrorMessage = "Password is required.")]
    public string Password { get; set; }
}