<%@ Page Language="VB" AutoEventWireup="false" CodeFile="HomePage.aspx.vb" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HomePage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Administration Portal</h1>
    <form id="form1" runat="server">
        <div class="buttonsDiv homePageButtons">
            <asp:Button class="button" ID="Button2" runat="server" Text="Registration"/>
            <asp:Button class="button" ID="Button3" runat="server" Text="Users" />
            <asp:Button class="button" ID="Button1" runat="server" Text="Files" />
        </div>
    </form>
</body>
</html>
