using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

public partial class Registration : System.Web.UI.Page
{

    private DBService dbService = DBService.getInstance();

    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Registerbtn_Click(object sender, EventArgs e)
    {
        dbService.DBOperations.ClearAll();

        string username = UserNametxt.Text;
        string password = Passwordtxt.Text;
        dbService.DBOperations.AddUser(username, password);
    }
}