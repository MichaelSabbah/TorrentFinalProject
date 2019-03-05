<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HomePage.aspx.cs" Inherits="HomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HomePage</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Home Page</h1>
    <form id="HomePageForm" runat="server">
        <div class="buttonsDiv homePageButtons">
            <asp:Button class="button homePageButton" ID="RegistrationBtn" runat="server" Text="Registration" OnClick="RegistrationBtn_Click" />
            <asp:Button class="button homePageButton" ID="UsersBtn" runat="server" Text="Users" OnClick="UsersBtn_Click" />
            <asp:Button class="button homePageButton" ID="FilesBtn" runat="server" Text="Files" OnClick="FilesBtn_Click" />
        </div>
    </form>
</body>
</html>

