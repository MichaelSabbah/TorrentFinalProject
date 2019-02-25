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
                <asp:TextBox ID="UserNametxt" runat="server" placeholder="Username"></asp:TextBox>
            </div>
            <p>
                <asp:TextBox ID="Passwordtxt" runat="server" placeholder="Password"></asp:TextBox>
            </p>
            <asp:Button class="button" ID="Registerbtn" runat="server" Text="Register" OnClick="Registerbtn_Click"/>
            <span><asp:Label class="successfulLabel indicationLabels" ID="UserAddedSuccessfullyLabel" runat="server" Text="User added successfully"></asp:Label></span>
            <span><asp:Label class="unsuccessfulLabel  indicationLabels" ID="UserAddedUnSuccessfullyLabel" runat="server" Text="Error occured"></asp:Label></span>
        </form>
    </body>
</html>
