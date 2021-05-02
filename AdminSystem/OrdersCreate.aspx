<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersCreate.aspx.cs" Inherits="_1Viewer" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="margin-top:30px;margin-left:100px">
            <asp:Label runat="server" Font-Size="24" >Online Game Store</asp:Label><br />
            <asp:Label runat="server" Font-Size="24">Order Processing</asp:Label><br /><br />
            </div>

            <table>
                <tr>
                    <td class="style2"> Customer</td>
                    <td class="style2" > <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>  </td>
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="OrderProfile.aspx">Edit Profile</asp:HyperLink> <br>
                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="OrderListaspx.aspx">Order List</asp:HyperLink>

                </tr>
            </table>
            
        </div>
        
        <br />
        <asp:Label runat="server" ID="errorText" />
        <br />

        <div style="border: 1px solid gray; width:280px">
            <table>
                <caption style="margin-left:-400px" class="style1">  
                    <strong>Detail Form</strong>  
                </caption>  
                <tr>  
                    <td class="style2">  
 </td>  
                    <td>  
 </td>  
                </tr>  
                <tr>  
                    <td class="style2">  
Select Product:</td>  
                    <td>  
                       <%-- <asp:TextBox ID="product_txt" runat="server"></asp:TextBox>  --%>
                        <asp:DropDownList ID="DropDownList1" runat="server">  
        </asp:DropDownList>
                    </td>                     
                </tr>  

                   <tr>  
                    <td class="style2">  
Quantity:</td>  
                    <td>  
                        <asp:TextBox ID="quantity_txt" runat="server" ></asp:TextBox>  
                    </td>                     
                </tr>  

                  <%-- <tr>  
                    <td class="style2">  
Price Per Unit:</td>  
                    <td>  
                        <asp:TextBox ID="price_txt" runat="server"></asp:TextBox>  
                    </td>                     
                </tr>  --%>
<%--                <tr>  
                    <td class="style2">  
Total Price:</td>  
                    <td>  
                        <asp:TextBox ID="total_txt" runat="server"></asp:TextBox>  
                    </td>                     
                </tr>  --%>

            </table>

            <br />
            <br />
        </div>

        <div  style="border: 1px solid gray;width:150px;margin-top:-150px;margin-left:400px">

           
        <p >
            <asp:Button ID="Button1" runat="server"  Text="Add" Width="120px" onclick="Button1_Click" />
        </p>
        <p >
            <asp:Button ID="Button2" runat="server"  Text="Clear" Width="120px" onclick="Button2_Click"/>
        </p>
        
        </div>


        <div style="margin-top:50px; display:inline-flex;">       
        <p >
           <%-- <asp:Button ID="Button3" runat="server"  Text="Create Order" Width="120px"  OnClick="Button3_Click"  OnClientClick="Confirm()" />--%>
            <asp:Button ID="Button3" runat="server"  Text="Create Order" Width="120px"  OnClick="Button3_Click" OnClientClick ="Confirm()" />

            
            <asp:TextBox ID="TextBox1" runat="server" Visible="false" MaxLength="10"></asp:TextBox>  
            <asp:Button ID="Button4" runat="server"  Text="Paid" Width="120px" OnClick="Button4_Click" Visible="false"/>




        </p>
        </div>




        <div>
            <asp:DataGrid ID="DataGrid1" runat="server">  
            </asp:DataGrid>  


        </div>
    </form>
</body>
</html>
