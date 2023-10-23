using Microsoft.SqlServer.Management.Smo;
using System.Text;

namespace Services
{
    public partial class Srv_SMO
    {
        public Task _Push_To_DB()
        {
            G_DoCancel = false;
            G_Srv_Progress = new Srv_Progress(G_Srv_MessageBus, 9);
            G_Srv_Progress._ShowProgress();

            Task L_Task = Task.Run(() =>
            {
                if (G_IsServerUp == true && _HaveFiles() == true)
                {
                    _Remake_DB(G_ProjectInfo);
                    _Remake_Schemas(G_ProjectInfo);
                    _Remake_Users(G_ProjectInfo);
                    _Remake_Tables(G_ProjectInfo);
                    _Remake_Objects_By_Dependencies(G_ProjectInfo);
                    _Remake_TableData(G_ProjectInfo);
                    _Remake_TableConstraints(G_ProjectInfo);

                    _Remake_DB_Tracking_Update(G_ProjectInfo);

                    G_Server.ConnectionContext.Disconnect();
                    //G_Server.KillAllProcesses(G_Database.Name);
                    G_SqlConnection.Close();
                    G_SqlConnection.Dispose();
                    
                    G_Srv_Progress._SetProgress(9, "Push to DB completed!");

                    
                }
            });

            return L_Task;
        }

        private bool _HaveFiles()
        {
            return File.Exists(G_DependenciesOrderFileName);
        }

        private void _AppendScript_Start(StringBuilder P_Script)
        {
            P_Script.AppendLine("USE " + G_SqlConnection.Database + ";");
            P_Script.AppendLine("GO");
            P_Script.AppendLine(Environment.NewLine);
        }

        private void _AppendScript_FromFile(StringBuilder P_Script, string P_File)
        {
            P_Script.AppendLine(File.ReadAllText(P_File));
        }


        private void _ExeScript(StringBuilder P_Script)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            try
            {
                G_Server.ConnectionContext.ExecuteNonQuery(P_Script.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

  
}
