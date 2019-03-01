<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>AdminPage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Admin Page</h1>
    <form id="form1" runat="server">
        <div class="formContent">
            <asp:TextBox class="input" ID="UserNametxt" runat="server" OnTextChanged="UserNametxt_TextChanged" placeholder="Username"></asp:TextBox>
            <div class="buttonsDiv usersManagementDiv">
                <asp:Button class="button" ID="Enablebtn" runat="server" Text="Enable" OnClick="Enablebtn_Click" />
                <asp:Button class="button" ID="Disablebtn" runat="server" Text="Disable" OnClick="Disablebtn_Click" />
                <asp:Button class="button" ID="Updatebtn" runat="server" Text="Update" OnClick="Updatebtn_Click" />
                <asp:Button class="button" ID="Deletebtn" runat="server" Text="Delete" OnClick="Deletebtn_Click" />
            </div>
        </div>
    </form>
</body>
</html>
