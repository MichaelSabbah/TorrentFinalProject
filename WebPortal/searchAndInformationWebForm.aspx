﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="searchAndInformationWebForm.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SearchAndInformation</title>
    <link rel = "stylesheet" type = "text/css" href = "Style.css"/>
</head>
<body>
    <h1>Search And Information Page</h1>
    <form id="form1" runat="server">
        <h3 id="AllFilesHeader">All Files</h3>
        <div class="formContent">
            <asp:Table ID="FilesTable" runat="server" style="width:100%;">
                <asp:TableHeaderRow>
                        <asp:TableCell>Name</asp:TableCell>
                        <asp:TableCell>Size</asp:TableCell>
                        <asp:TableCell>Users</asp:TableCell>
                </asp:TableHeaderRow>
            </asp:Table>

            <asp:TextBox ID="Searchtxt" runat="server" OnTextChanged="TextBox2_TextChanged" placeholder="File name"></asp:TextBox>
            <asp:Button class="button" ID="Searchbtn" runat="server" Text="search file" OnClick="Searchbtn_Click" />
        </div>
        <div class="totalInformation">
            <asp:Label class="leftFloatedLabel" ID="TotalUserslbl" runat="server" Text="Total Users: "></asp:Label>
            <asp:Label class="leftFloatedLabel" ID="TotalFileslbl" runat="server" Text="Total Files: "></asp:Label>
            <asp:Label class="leftFloatedLabel" ID="Activeserslbl" runat="server" Text="Active Users: "></asp:Label>
        </div>
    </form>
</body>
</html>
