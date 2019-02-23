using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DBService
/// </summary>
public class DBService
{
    private static DBService dbService;

    public DBOperations DBOperations
    {
        get;
    }

    private DBService()
    {
        DBOperations = new DBOperations();
    }

    public static DBService getInstance()
    {
        if (dbService == null)
            dbService = new DBService();

        return dbService;
    }
}