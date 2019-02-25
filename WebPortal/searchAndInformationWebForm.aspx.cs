using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    DBService db = DBService.getInstance();
    protected void Page_Load(object sender, EventArgs e)
    {
        List<File> filesList = db.DBOperations.getAllFiles();
        foreach(File f in filesList)
        {
            TableRow tempRow = new TableRow();
            TableCell nameCell = new TableCell();
            TableCell sizeCell = new TableCell();
            TableCell usersCell = new TableCell();
            nameCell.Text = f.FileName;
            sizeCell.Text = f.Size+"";
            tempRow.Cells.Add(nameCell);
            tempRow.Cells.Add(sizeCell);
            FilesTable.Rows.Add(tempRow);
        }
        TotalUserslbl.Text += "  " + db.DBOperations.getAmountOfUsers();
        TotalFileslbl.Text += "  " + db.DBOperations.getAmountOfFiles();
        Activeserslbl.Text += "  " + db.DBOperations.getAmountOfActiveUsers(); 
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    }

    protected void Searchbtn_Click(object sender, EventArgs e)
    {

        File file = db.DBOperations.getFileByName(Searchtxt.Text);
        if (file.FileName != "")
        {
            FilesTable.Rows.Clear();
            TableRow tempRow = new TableRow();
            TableCell nameCell = new TableCell();
            TableCell sizeCell = new TableCell();
            nameCell.Text = file.FileName;
            sizeCell.Text = file.Size.ToString();
            tempRow.Cells.Add(nameCell);
            tempRow.Cells.Add(sizeCell);
            FilesTable.Rows.Add(tempRow);
        }
        else
            Response.Write("<script>alert('file not found')</script>");
    }
}