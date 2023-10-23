
using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using Services.DB;

namespace Services
{
    public partial class Srv_SMO
    {
        //private bool _IsServerUp()
        //{
        //    Environment.CurrentDirectory = G_ProjectInfo.ScriptFolder;

        //    G_SqlConnection = new SqlConnection(Srv_MSSQL._Get_Connection_String(G_ProjectInfo));

        //    ServerConnection L_ServerConnection = new ServerConnection(G_SqlConnection);

        //    G_Server = new Server(L_ServerConnection);

        //    if (G_Server.Status != ServerStatus.Online)
        //    {
        //        G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Cannot connect to SQL Server. Check connection details and ensure server is online.");
        //        return false;
        //    }

            

        //    G_Server.SetDefaultInitFields(typeof(View), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(User), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(Table), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(Schema), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(Trigger), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");
        //    G_Server.SetDefaultInitFields(typeof(UserDefinedFunction), "IsSystemObject");

            

        //    return true;
        //}


        private void _Set_Server()
        {
            Environment.CurrentDirectory = Srv_ScriptsFolder._Get(G_ProjectInfo);

            G_SqlConnection = new SqlConnection(Srv_MSSQL._Get_Connection_String(G_ProjectInfo));

            ServerConnection L_ServerConnection = new ServerConnection(G_SqlConnection);

            G_Server = new Server(L_ServerConnection);

            if (G_Server.Status != ServerStatus.Online)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Cannot connect to SQL Server. Check connection details and ensure server is online.");
                G_IsServerUp = false;
            }
            else
            {
                G_IsServerUp = true;
                G_Server.SetDefaultInitFields(typeof(View), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(User), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(Table), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(Schema), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(Trigger), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(StoredProcedure), "IsSystemObject");
                G_Server.SetDefaultInitFields(typeof(UserDefinedFunction), "IsSystemObject");
            }
        }
    }

}
