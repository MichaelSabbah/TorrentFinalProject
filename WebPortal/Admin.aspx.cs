using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    private DBService dbService = DBService.getInstance();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void UserNametxt_TextChanged(object sender, EventArgs e)
    {

    }

    protected void Enablebtn_Click(object sender, EventArgs e)
    {
        string userName = UserNametxt.Text;
        User existingUser = dbService.DBOperations.GetUserByUsername(userName);
        existingUser.Enabled = true;
        dbService.DBOperations.UpdateUser(existingUser,userName);
    }

    protected void Disablebtn_Click(object sender, EventArgs e)
    {
        string userName = UserNametxt.Text;
        User existingUser = dbService.DBOperations.GetUserByUsername(userName);
        existingUser.Enabled = false;
        dbService.DBOperations.UpdateUser(existingUser,userName);
    }

    protected void Updatebtn_Click(object sender, EventArgs e)
    {
        string userName = UserNametxt.Text;
        Response.Redirect("UpdateUserPage.aspx?username="+userName);
    }

    protected void Deletebtn_Click(object sender, EventArgs e)
    {
        string userName = UserNametxt.Text;
        dbService.DBOperations.RemoveUser(userName);
    }
}