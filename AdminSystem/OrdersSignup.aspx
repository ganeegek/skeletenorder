<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrdersSignup.aspx.cs" Inherits="_1_DataEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
               <table style="width:50%;">  
                <caption style="margin-left:-400px" class="style1">  
                    <strong>SIGN UP FORM</strong>  
                </caption>  
                <tr>  
                    <td class="style2">  
 </td>  
                    <td>  
 </td>  
                </tr>  
                <tr>  
                    <td class="style2">  
Name:</td>  
                    <td>  
                        <asp:TextBox ID="Nametxt" runat="server" ></asp:TextBox>  
                    </td>    
                    <td>  
                       <asp:Label runat="server" ID="nameError" ></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
Address:</td>  
                    <td>  
                        <asp:TextBox ID="Addresstxt" runat="server"></asp:TextBox>  
                    </td>   
                       <td>  
                       <asp:Label runat="server" ID="addressError"></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
City:</td>  
                    <td>  
                        <asp:TextBox ID="Citytxt" runat="server"></asp:TextBox>  
                    </td>         
                       <td>  
                       <asp:Label runat="server" ID="cityError"></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
PostCode:</td>  
                    <td>  
                        <asp:TextBox ID="Postcodetxt" runat="server"></asp:TextBox>  
                    </td>                     
                       <td>  
                       <asp:Label runat="server" ID="postcodeError"></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
Email:</td>  
                    <td>  
                        <asp:TextBox ID="Emailtxt" runat="server"></asp:TextBox>  
                    </td>             
                       <td>  
                       <asp:Label runat="server" ID="emailError"></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
Mobile:</td>  
                    <td>  
                        <asp:TextBox ID="Mobiletxt" runat="server"></asp:TextBox>  
                    </td>                     
                       <td>  
                       <asp:Label runat="server" ID="mobileError"></asp:Label>
                    </td>  
                </tr>  

                   <tr>  
                    <td class="style2">  
Password:</td>  
                    <td>  
                        <asp:TextBox ID="Passwordtxt" runat="server"></asp:TextBox>  
                    </td>  
                       <td>  
                       <asp:Label runat="server" ID="passwordError"></asp:Label>
                    </td>  
                </tr> 
                   
                    <tr>  

                        <td class="style2"> </td>  
                    <td>  
                       <asp:Label runat="server" ID="errorText"></asp:Label>
                    </td>              
                </tr> 
                </table>

        <p style="margin-left:200px">
            <asp:Button ID="Button1" runat="server" Text="Register" onclick="Button1_Click" />  
        </p>

    </form>
</body>
</html>
