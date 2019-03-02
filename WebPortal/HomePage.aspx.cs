using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomePage : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        DBService dbService = DBService.getInstance();
        dbService.DBOperations.ClearAll();
    }

    protected void RegistrationBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistrationPage.aspx");
    }

    protected void UsersBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }

    protected void FilesBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("searchAndInformationWebForm.aspx");
    }
}