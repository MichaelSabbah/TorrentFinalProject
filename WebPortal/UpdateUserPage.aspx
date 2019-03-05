<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UpdateUserPage.aspx.cs" Inherits="UpdateUserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UpdateUserPage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Update User Page</h1>
    <form id="updateUserForm" runat="server">
        <div id="UserDetails">
        </div>
        <div class="formContent" id="UpdateUserFormContent" >
            <asp:Table ID="UserDetailsTable" runat="server">
                <asp:TableRow>
                    <asp:TableCell BorderWidth="0">UserName:</asp:TableCell>
                    <asp:TableCell BorderWidth="0" ID="UserNameValue">UserName</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell BorderWidth="0" >Password:</asp:TableCell>
                    <asp:TableCell BorderWidth="0" ID="PasswordValue">UserName</asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell BorderWidth="0">Status:</asp:TableCell>
                    <asp:TableCell BorderWidth="0" ID="EnabledDisabledValue">UserName</asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:TextBox ID="UsernameTextBox" runat="server" placeholder="Username"></asp:TextBox>
            <asp:TextBox ID="PasswordTextBox" runat="server" placeholder="Password"></asp:TextBox>
            <br /><br /><br /><br />
            <asp:RadioButtonList ID="EnabledAndDisabledRadioList" runat="server">
                <asp:ListItem Text="Enabled" Value="Enabled" Selected="True"></asp:ListItem>
                <asp:ListItem Text="Disabled" Value="Disabled"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:Button class="button" ID="UpdateUserbtn" runat="server" Text="Update" OnClick="UpdateUserbtn_Click" />
        </div>
    </form>
</body>
</html>
