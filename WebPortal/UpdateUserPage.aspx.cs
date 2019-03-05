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
            UsernameTextBox.Text = user.UserName;
            PasswordTextBox.Text = user.Password;
            if (user.Enabled)
            {
                EnabledAndDisabledRadioList.SelectedIndex = 0;
            }
            else
            {
                EnabledAndDisabledRadioList.SelectedIndex = 1;
            }
        }
    }

    protected void UpdateUserbtn_Click(object sender, EventArgs e)
    {
        User user = dbService.DBOperations.GetUserByUsername(oldUserName);
        if (user != null)
        {
            if (!IsPostBack)
            {
                HtmlInputText htmlInputText;
                htmlInputText = FindControl("UsernameTextBox") as HtmlInputText;
                user.UserName = htmlInputText.Value;
                htmlInputText = FindControl("PasswordTextBox") as HtmlInputText;
                user.Password = htmlInputText.Value;
                RadioButtonList radioButtonList = FindControl("EnabledAndDisabledRadioList") as RadioButtonList;
                user.Enabled = radioButtonList.SelectedValue.Equals("Enabled") ? true : false;
            }
            dbService.DBOperations.UpdateUser(user, oldUserName);
        }
        Response.Redirect("HomePage.aspx");
    }
}