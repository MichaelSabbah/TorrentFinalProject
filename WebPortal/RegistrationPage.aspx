<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistrationPage.aspx.cs" Inherits="Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>RegistrationPage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Registration Page</h1>
    <form id="form1" runat="server">

        <div class="formContent">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Username"></asp:TextBox>
        </div>
        <p>
            <asp:TextBox ID="TextBox2" runat="server" placeholder="Password"></asp:TextBox>
        </p>
        <asp:Button class="button" ID="Button1" runat="server" Text="Register"/>
    </form>
</body>
</html>
