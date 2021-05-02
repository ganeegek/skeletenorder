using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OrderListaspx : System.Web.UI.Page
{
    DataTable table = new DataTable();
    private SqlConnection con;
    List<OrderModal> myOrder = new List<OrderModal>();
    OrderModal modal = new OrderModal();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
            con = new SqlConnection(constring);

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
        }

       
    }

    public List<OrderModal> GetOrderItem(string name)
    {
        List<OrderModal> orderList = new List<OrderModal>();

        SqlCommand cmd = new SqlCommand("GetOrder", con);
        cmd.CommandType = CommandType.StoredProcedure;
       // cmd.Parameters.AddWithValue("@name", name);
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

    protected void TextBox1_TextChanged(object sender, EventArgs e)
    {
        table.Columns.Add("Product");
        table.Columns.Add("Quantity");
        table.Columns.Add("Price Per Unit");
        table.Columns.Add("Total Price");


        var data = TextBox1.Text;
        var CapData = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(data);

        //
        var orderItem = OrderSort(CapData);
        for (int i = 0; i < orderItem.Count; i++)
        {
            table.Rows.Add(orderItem[i].Product, orderItem[i].ProductQty, orderItem[i].price, orderItem[i].Total);
        }


        DataGrid1.DataSource = table;
        DataGrid1.DataBind();
    }
    public List<OrderModal> OrderSort(string name)
    {
        string constring = ConfigurationManager.ConnectionStrings["studentconn"].ToString();
        con = new SqlConnection(constring);
        List<OrderModal> orderList = new List<OrderModal>();

        SqlCommand cmd = new SqlCommand("OrderSort", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@product", name);
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
}

public class OrderModal
{
    public string Name { get; set; }
    public string Product { get; set; }
    public string price { get; set; }
    public string ProductQty { get; set; }
    public string Total { get; set; }
}