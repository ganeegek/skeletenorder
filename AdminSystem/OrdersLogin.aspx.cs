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

public partial class _1_List : System.Web.UI.Page
{
    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        var username = TextBox1.Text;
        var password = TextBox2.Text;
        usernameError.Text = "";
        passwordError.Text = "";
        loginError.Text = "";


         clsOrder order = new clsOrder();
         var error = order.LoginValid(username, password);


        if(error == "")
        {
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(constring);

            //if (username == "Admin" && password == "Admin")
            //{
            //    Response.Write("<script>alert('Login Done!')</script>");                
            //    Response.Redirect("Dashboard.aspx");
            //    //ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "ClientScript", "alert('hello')", true);
            //}
            var listCustomer = GetStudent(username);

            if (listCustomer.Count > 0)
            {
                if (listCustomer[0].Email == username && listCustomer[0].Password == password)
                {
                    Session["UserName"] = username;
                    Session["Name"] = listCustomer[0].Name.ToString();
                    Response.Redirect("OrdersCreate.aspx");
                }
                else
                {
                    loginError.Text = "Please Check your Credentials";
                }
            }
            else
            {
                loginError.Text = "User Not Found! Please Check your Credentials or try new Account";
            }
        }

        else
        {
            if(error == "Please Enter you Password")
            {
                passwordError.Text = error;

            }
            if (error == "Please Enter you Email")
            {
                usernameError.Text = error;

            }
            if(error == "Please Enter Your Credentials")
            {
                loginError.Text = "Please Enter your Credentials";
            }
        }


        

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
                    Email = Convert.ToString(dr["Email"])
                });
        }
        return studentlist;
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrdersSignup.aspx");
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