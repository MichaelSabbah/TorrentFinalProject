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
        List<File> filesList = db.DBOperations.GetAllFiles();
        foreach (File f in filesList)
        {
            TableRow tempRow = new TableRow();
            TableCell nameCell = new TableCell();
            TableCell sizeCell = new TableCell();
            TableCell usersCell = new TableCell();
            nameCell.Text = f.FileName;
            sizeCell.Text = f.Size + "";
            tempRow.Cells.Add(nameCell);
            tempRow.Cells.Add(sizeCell);
            FilesTable.Rows.Add(tempRow);
        }
        TotalUserslbl.Text = "Total Users:  " + db.DBOperations.GetAmountOfUsers();
        TotalFileslbl.Text = "Total Files:  " + db.DBOperations.GetAmountOfFiles();
        Activeserslbl.Text = "Active Users:  " + db.DBOperations.GetAmountOfActiveUsers();
    }

    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
    }

    protected void Searchbtn_Click(object sender, EventArgs e)
    {
        List<File> files = db.DBOperations.GetAllFileSharingReferencesByFileName(Searchtxt.Text);
        if (files != null && files.Count > 0)
        {
            FilesTable.Rows.Clear();
            CreateTableHeader();
            TableRow tempRow = new TableRow();
            TableCell nameCell = new TableCell();
            TableCell sizeCell = new TableCell();
            TableCell peersCell = new TableCell();
            nameCell.Text = files[0].FileName;
            sizeCell.Text = files[0].Size.ToString();
            peersCell.Text = files.Count.ToString();
            tempRow.Cells.Add(nameCell);
            tempRow.Cells.Add(sizeCell);
            tempRow.Cells.Add(peersCell);
            FilesTable.Rows.Add(tempRow);
        }
        else
            Response.Write("<script>alert('file not found')</script>");
    }

    private void CreateTableHeader()
    {
        TableHeaderRow tableHeaderRow = new TableHeaderRow();
        TableHeaderCell fileNameCell = new TableHeaderCell();
        TableHeaderCell sizeCell = new TableHeaderCell();
        TableHeaderCell peersCell = new TableHeaderCell();

        fileNameCell.Text = "Name";
        sizeCell.Text = "Size";
        peersCell.Text = "Peers";

        tableHeaderRow.Cells.Add(fileNameCell);
        tableHeaderRow.Cells.Add(sizeCell);
        tableHeaderRow.Cells.Add(peersCell);

        FilesTable.Rows.Add(tableHeaderRow);
    }
}