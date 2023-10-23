using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;

namespace Services
{
    public partial class Srv_SMO
    {
        private Srv_MessageBus G_Srv_MessageBus;
        private DB.Srv_DB G_Srv_DB;
        private DB.ProjectInfo G_ProjectInfo;
        private Srv_Progress G_Srv_Progress;

        private SqlConnection G_SqlConnection;
        private Server G_Server;
        private Database G_Database;
        private Scripter G_Scripter;

        StringBuilder G_ScriptBuilder = new StringBuilder();

        const string G_DependenciesOrderFileName = "DependenciesOrder.txt";

        bool G_IsServerUp = false;

        bool G_DoCancel = false;

        public Srv_SMO(Srv_MessageBus P_Srv_MessageBus, DB.Srv_DB P_Srv_DB, DB.ProjectInfo P_ProjectInfo)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Srv_DB = P_Srv_DB;
            G_ProjectInfo = P_ProjectInfo;

            _Init();
        }

        private void _Init()
        {
            G_DoCancel = false;
            
            _Set_Server();
            _Set_Database();
            _Set_Scripter();

            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.Cancel_Job, (P_Message) =>
            {
                G_DoCancel = true;
                G_Srv_Progress._Cancel();
            });
        }

        //public void _CancelMe()
        //{
        //    G_DoCancel = true;
        //}

        private void _Set_Database()
        {
            if (G_IsServerUp == true)
            {
                G_Database = G_Server.Databases[G_ProjectInfo.DBName];
            }
        }

        private void _Set_Scripter(bool P_IsData = false)
        {
            if (G_IsServerUp == true)
            {
                G_Scripter = new Scripter(G_Server)
                {
                    Options =
                    {
                        Indexes                         = true,
                        Triggers                        = true,
                        ScriptData                      = P_IsData,
                        ScriptDrops                     = false,
                        ScriptSchema                    = !P_IsData,
                        WithDependencies                = false,
                        DriAllConstraints               = true,
                        ExtendedProperties              = true,
                        TargetServerVersion             = _Get_Target_Version(G_ProjectInfo),
                        IncludeDatabaseRoleMemberships  = true,
                        NoIdentities                    = P_IsData,
                    }
                };
            }
        }
    }

    public enum Srv_SMO_Type
    {
        Schema,
        User,
        Table,
        View,
        Proc,
        Func,
        Syn,
        Trig,
        Data,
        Contraints,
    }
}
