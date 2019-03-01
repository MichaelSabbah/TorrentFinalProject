<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUserPage.aspx.cs" Inherits="UpdateUserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UpdateUserPage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Update User Page</h1>
    <form id="form1" runat="server">
        <div class="formContent">
            <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="PasswordTextBox" runat="server" placeholder="Password"></asp:TextBox>
            <div class="radioButtonsGroup"style="display:block;">
                <input runat="server" id="EnabledRadioButton" value="Enabled" type="radio" /> Enabled
                <input runat="server" id="DisabledRadioButton" value="Disabled" type="radio" /> Disabled
            </div>
            <asp:Button class="button" ID="UpdateUserbtn" runat="server" Text="Update" OnClick="UpdateUserbtn_Click" />
        </div>
    </form>
</body>
</html>
