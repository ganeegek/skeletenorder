<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersLogin.aspx.cs" Inherits="_1_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div >                        
            <table style="width:50%;">  
                <caption style="margin-left:-400px" class="style1">  
                    <strong>LOGIN FORM</strong>  
                </caption>  
                <tr>  
                    <td class="style2">  
 </td>  
                    <td>  
 </td>  
                    <td>  
 </td>  
                </tr>  
                <tr>  
                    <td class="style2">  
Username:</td>  
                    <td>  
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>  
                    </td>  
                    <td>  
                       <asp:Label runat="server" ID="usernameError"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="style2">  
Password:</td>  
                    <td>  
                        <asp:TextBox ID="TextBox2"  runat="server" ></asp:TextBox>  
                    </td>  
                    <td>  
                        <asp:Label runat="server" ID="passwordError"></asp:Label>
                    </td>  
                </tr>  
                <tr>  
                    <td class="style2">  
 </td>  
                    <td>  
 </td>  
                    <td>  
 </td>  
                </tr>  

                <tr>
                    <td>

                    </td>
                    <td>
                        <asp:Label runat="server" ID="loginError"></asp:Label>
                    </td>
                </tr>

            </table>            
        </div>
        <div>
        <p>
                         <asp:Button ID="Button1" runat="server" Text="Log In" onclick="Button1_Click" />  
        </p>
        <p>
             <asp:Label ID="Label2" Text="If you havn't no account" runat="server" on></asp:Label>  
            
             <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="OrdersSignup.aspx">SignIn</asp:HyperLink>
            
        </p>
            </div>
    </form>
</body>
</html>
