<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrderListaspx.aspx.cs" Inherits="OrderListaspx" %>

<!DOCTYPE html>



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <caption style="margin-left:-400px" class="style1">  
                    <strong>PRODUCT LIST FORM</strong>  
        </caption>  <br /><br />
        <div>
           <asp:Label ID="Label2" Text="Search By Product: " runat="server" ></asp:Label> 
            <asp:TextBox ID="TextBox1" runat="server" Visible="true" MaxLength="10" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>  

            <br />
            <br />
            <asp:DataGrid ID="DataGrid1" runat="server">  
            </asp:DataGrid>  
        </div>
    </form>
</body>
</html>
