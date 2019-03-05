using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using Entities;

public partial class Registration : System.Web.UI.Page
{
    private DBService dbService = DBService.getInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        UserAddedSuccessfullyLabel.Visible = false;
        UserAddedUnSuccessfullyLabel.Visible = false;
    }

    protected void Registerbtn_Click(object sender, EventArgs e)
    {
        string username = UserNametxt.Text;
        string password = Passwordtxt.Text;
        try
        {
            User user = new User();
            user.UserName = username;
            user.Password = password;
            user.Enabled = true;
            user.Connected = false;
            user.IP = "";
            user.Port = "";
            dbService.DBOperations.AddUser(user);
            Console.WriteLine("User added successfully");
            UserAddedSuccessfullyLabel.Visible = true;
        }
        catch(Exception)
        {
            Console.WriteLine("Error while add user");
            UserAddedUnSuccessfullyLabel.Visible = true;
        }
    }
}
