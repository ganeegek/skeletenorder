using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _1Viewer : System.Web.UI.Page
{
    DataTable table = new DataTable();
    List<OrderModal> myOrder = new List<OrderModal>();
    OrderModal modal = new OrderModal();
    private SqlConnection con;

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["UserName"] == null)
        {
            Response.Redirect("OrdersLogin.aspx");
        }
        else
        {
            TextBox2.Text = Session["UserName"].ToString();
        }

        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);

        //SqlConnection con = new SqlConnection(str);

        //TextBox2.Text = "Navdeep";
        if (!this.IsPostBack)
        {

            table.Columns.Add("Product");
            table.Columns.Add("Quantity");
            table.Columns.Add("Price Per Unit");
            table.Columns.Add("Total Price");


            var orderItem = GetOrderItem(Session["UserName"].ToString());
            for (int i = 0; i < orderItem.Count; i++)
            {
                table.Rows.Add(orderItem[i].Product, orderItem[i].ProductQty, orderItem[i].price, orderItem[i].Total);
            }


            DataGrid1.DataSource = table;
            DataGrid1.DataBind();

            string com = "Select Name from Product";
            SqlDataAdapter adpt = new SqlDataAdapter(com, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "Name";
            DropDownList1.DataValueField = "Name";
            DropDownList1.DataBind();
        }
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        table.Columns.Add("Product");
        table.Columns.Add("Quantity");
        table.Columns.Add("Price Per Unit");
        table.Columns.Add("Total Price");
        DataGrid1.DataSource = table;
        DataGrid1.DataBind();

        var script = String.Format("alert('{0} Thankyou for purchase! ')", Session["Name"].ToString());
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);

        //string confirmValue = Request.Form["confirm_value"];
        //if (confirmValue == "Yes")
        //{
        //    //  this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked YES!')", true);
        //    var script = String.Format("alert('{0} Thankyou for purchase! ')", Session["Name"].ToString());
        //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);
        //    ClearGrid();
        //}
        //else
        //{
        //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You clicked NO!')", true);
        //}
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        var listProduct = GetProduct(DropDownList1.SelectedItem.Value);
        modal.Product = DropDownList1.SelectedValue;
        modal.price = listProduct[0].Price;
        modal.ProductQty = quantity_txt.Text;
        if(quantity_txt.Text.Length > 0)
        {

            clsOrder clsOrder = new clsOrder();
            var result =  clsOrder.CheckQuantityValid(quantity_txt.Text);

            if (result)
            {
                var total = int.Parse(listProduct[0].Price) * int.Parse(quantity_txt.Text.ToString());
                modal.Total = total.ToString();
                modal.Name = Session["UserName"].ToString();

                string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
                con = new SqlConnection(constring);

                var listCustomer = AddOrderItem(modal);

                if (listCustomer)
                {
                    var orderItem = GetOrderItem(modal.Name);
                    table.Columns.Add("Product");
                    table.Columns.Add("Quantity");
                    table.Columns.Add("Price Per Unit");
                    table.Columns.Add("Total Price");
                    for (int i = 0; i < orderItem.Count; i++)
                    {

                        table.Rows.Add(orderItem[i].Product, orderItem[i].ProductQty, orderItem[i].price, orderItem[i].Total);
                    }

                    DataGrid1.DataSource = table;
                    DataGrid1.DataBind();
                }


                //product_txt.Text = "";
                quantity_txt.Text = "";
                //total_txt.Text = "" ;
            }
            else
            {
                var script = String.Format("alert('{0} Please Using Digit Value Only for Quantity ')", Session["Name"].ToString());
                this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);
            }

        }
        else
        {
            var script = String.Format("alert('{0} Please Enter some Quantity ')", Session["Name"].ToString());
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);
        }

        


    }

    public List<OrderModal> GetOrderItem(string name)
    {
        List<OrderModal> orderList = new List<OrderModal>();

        SqlCommand cmd = new SqlCommand("OrderItems", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", name);
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        con.Open();
        sd.Fill(dt);
        con.Close();

        foreach (DataRow dr in dt.Rows)
        {
            orderList.Add(
                new OrderModal
                {
                    Product = Convert.ToString(dr["Product"]),
                    ProductQty = Convert.ToString(dr["Product_Qty"]),
                    price = Convert.ToString(dr["Price"]),
                    Total = Convert.ToString(dr["Total"]),
                });
        }
        return orderList;
    }

    public bool AddOrderItem(OrderModal smodel)
    {

        SqlCommand cmd = new SqlCommand("AddItem", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@name", smodel.Name);
        cmd.Parameters.AddWithValue("@product", smodel.Product);
        cmd.Parameters.AddWithValue("@price", smodel.price);
        cmd.Parameters.AddWithValue("@product_qty", smodel.ProductQty);
        cmd.Parameters.AddWithValue("@total", smodel.Total);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();

        if (i >= 1)
            return true;
        else
            return false;
    }

    public bool DeleteItem(OrderModal smodel)
    {
        SqlCommand cmd = new SqlCommand("DeleteItem", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", smodel.Name);

        con.Open();
        int i = cmd.ExecuteNonQuery();
        con.Close();
        if (i >= 1)
            return true;
        else
            return false;
    }

    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderProfile.aspx");

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        modal.Name = Session["UserName"].ToString();

        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);

        var listCustomer = DeleteItem(modal);

        table.Columns.Add("Product");
        table.Columns.Add("Quantity");
        table.Columns.Add("Price Per Unit");
        table.Columns.Add("Total Price");
        DataGrid1.DataSource = table;
        DataGrid1.DataBind();

        // product_txt.Text = "";
        quantity_txt.Text = "";
    }

    public void ClearGrid()
    {
        modal.Name = Session["UserName"].ToString();

        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);

        var listCustomer = DeleteItem(modal);

        table.Columns.Add("Product");
        table.Columns.Add("Quantity");
        table.Columns.Add("Price Per Unit");
        table.Columns.Add("Total Price");
        DataGrid1.DataSource = table;
        DataGrid1.DataBind();

        // product_txt.Text = "";
        quantity_txt.Text = "";
    }

    public List<Product> GetProduct(string productName)
    {
        List<Product> productlist = new List<Product>();

        SqlCommand cmd = new SqlCommand("ProductDetail", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", productName);
        SqlDataAdapter sd = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();

        con.Open();
        sd.Fill(dt);
        con.Close();

        foreach (DataRow dr in dt.Rows)
        {
            productlist.Add(
                new Product
                {
                    Name = Convert.ToString(dr["Name"]),
                    Price = Convert.ToString(dr["Price"])
                });
        }
        return productlist;
    }

    protected void Button4_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text.Length > 9)
        {
            TextBox1.Visible = false;
            Button4.Visible = false;

            var script = String.Format("alert('{0} Thankyou for purchase! ')", Session["Name"].ToString());
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);
        }
        else
        {
            TextBox1.Visible = true;
            Button4.Visible = true;

            var script = String.Format("alert('{0} Please check your Account No. ')", Session["Name"].ToString());
            this.Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", script.ToString(), true);
        }


    }

}

public class OrderModal
{
    public string Name { get; set; }
    public string Product { get; set; }
    public string price { get; set; }
    public string ProductQty { get; set; }
    public string Total { get; set; }
}

public class Product
{
    public string Name { get; set; }
    public string Price { get; set; }
}