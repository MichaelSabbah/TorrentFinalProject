<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchAnsInformationWebForm.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SearchAndInformation</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Search And Information Page</h1>
    <form id="form1" runat="server">
    <div class="formContent">
        <span><asp:Label ID="AllFileslbl" runat="server" Text="All Files"></asp:Label></span>
        <table style="width:100%;">
            <thead>
                <tr>
                    <td>Name</td>
                    <td>Size</td>
                    <td>Users</td>
                </tr>
            </thead>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
        <asp:TextBox ID="Searchtxt" runat="server" OnTextChanged="TextBox2_TextChanged" placeholder="File name"></asp:TextBox>
        <asp:Button class="button" ID="Searchbtn" runat="server" Text="search file" />
    
    </div>
        <p>
            <asp:Label ID="TotalUserslbl" runat="server" Text="total Users"></asp:Label>
            <asp:Label ID="TotalFileslbl" runat="server" Text="total files"></asp:Label>
            <asp:Label ID="Activeserslbl" runat="server" Text="active users"></asp:Label>
        </p>
    </form>
</body>
</html>
