# TorrentFinalProject
The whole project is divided to 4 main sub projects:
1) WebPortal - Administrator management system implemented with ASP. Used to add, update and delete users.
   In addition, the web portal provides information about the files shared between users.
2) Mediation Server - WCF Services for handling clients request.
   Used as the system server and provide to the user the ability to sign-in, get file information and sign-out.
3) Client - WPF application for users - P2P client/server GUI that allow to use the system and shared files with other users.
   Every 'client project' works as client and server, using TcpClient and TcpListener.
   The file sharing proccess is done in a separate Tasks.
4) DAL - A class library for DB operations.
   Module to handle all DB operations using EntityFramework and Microsoft SQL Server.
