using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class UpdateUserPage : System.Web.UI.Page
{
    private DBService dbService = DBService.getInstance();
    private string oldUserName;

    protected void Page_Load(object sender, EventArgs e)
    {
        oldUserName  = Request.Params.Get("userName");
        User user = dbService.DBOperations.GetUserByUsername(oldUserName);
        if(user != null)
        {
            UserNameValue.Text = user.UserName;
            PasswordValue.Text = user.Password;
            if (user.Enabled)
            {
                EnabledDisabledValue.Text = "Enabled";
            }
            else
            {
                EnabledDisabledValue.Text = "Disabled";
            }
        }
    }

    protected void UpdateUserbtn_Click(object sender, EventArgs e)
    {
        User user = dbService.DBOperations.GetUserByUsername(oldUserName);
        if (user != null)
        {
            user.UserName = UsernameTextBox.Text;
            user.Password = PasswordTextBox.Text;
            user.Enabled = EnabledAndDisabledRadioList.SelectedValue.Equals("Enabled") ? true : false;

            dbService.DBOperations.UpdateUser(user, oldUserName);
        }
        Response.Redirect("HomePage.aspx");
    }
}