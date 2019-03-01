using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UpdateUserPage : System.Web.UI.Page
{
    private DBService dbService = DBService.getInstance();
    private string oldUserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        //oldUserName = Request.QueryString["username"];
        //User user = dbService.DBOperations.GetUserByUsername(oldUserName);
        //UsernameTextBox.Text = user.UserName;
        //PasswordTextBox.Text = user.Password;
    }

    protected void UpdateUserbtn_Click(object sender, EventArgs e)
    {
        User user = dbService.DBOperations.GetUserByUsername(oldUserName);
        user.UserName = UsernameTextBox.Text;
        user.Password = PasswordTextBox.Text;
        dbService.DBOperations.RemoveUser(oldUserName);
        //dbService.DBOperations.AddUser(user);
    }
}