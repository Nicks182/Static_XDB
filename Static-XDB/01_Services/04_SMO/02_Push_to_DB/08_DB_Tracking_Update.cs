
using Microsoft.SqlServer.Management.Smo;
using Services.DB;

namespace Services
{
    public partial class Srv_SMO
    {
        public void _Remake_DB_Tracking_Update(DB.ProjectInfo P_ProjectInfo)
        {
            if (G_DoCancel == true)
            {
                return;
            }
            DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(P_ProjectInfo.Id) == true).FirstOrDefault();

            if (L_Tracking is null)
            {
                L_Tracking = new Tracking();
                L_Tracking.ProjectInfoId = P_ProjectInfo.Id;

            }
            else
            {
                List<DB.Tracking_Object> L_Tracking_Objects = G_Srv_DB.Tracking_Object_GetAll().Find(to => to.TrackingId.Equals(L_Tracking.Id) == true).ToList();

                for (int to = 0; to < L_Tracking_Objects.Count; to++)
                {
                    if (G_DoCancel == true)
                    {
                        return;
                    }
                    G_Srv_DB.Tracking_Object_Delete(L_Tracking_Objects[to]);
                }

                List<DB.Tracking_Data> L_Tracking_Datas = G_Srv_DB.Tracking_Data_GetAll().Find(td => td.TrackingId.Equals(L_Tracking.Id) == true).ToList();

                for (int td = 0; td < L_Tracking_Datas.Count; td++)
                {
                    if (G_DoCancel == true)
                    {
                        return;
                    }
                    G_Srv_DB.Tracking_Data_Delete(L_Tracking_Datas[td]);
                }
            }

            if (G_DoCancel == true)
            {
                return;
            }

            Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, P_ProjectInfo);
            List<Table> L_Tables = L_Srv_SMO._Get_Table_Data();
            Tracking_Data L_Tracking_Data;
            for (int i = 0; i < L_Tables.Count; i++)
            {
                if (G_DoCancel == true)
                {
                    G_DoCancel = false;
                    break;
                }

                L_Tracking_Data = new Tracking_Data();
                L_Tracking_Data.TrackingId = L_Tracking.Id;
                L_Tracking_Data.Changed = 0;
                L_Tracking_Data.TableName = L_Tables[i].Name;
                L_Tracking_Data.LastCheck = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                G_Srv_DB.Tracking_Data_Save(L_Tracking_Data);
            }

            if (G_DoCancel == true)
            {
                return;
            }
            Srv_GIT_Info L_Srv_GIT_Info = Srv_GIT._Get_GIT_Info(P_ProjectInfo);

            L_Tracking.DatePushed       = DateTime.Now.ToString("yyyy/MM/dd/ HH:mm:ss");
            L_Tracking.WithBranch       = L_Srv_GIT_Info.Branch;
            L_Tracking.WithCommit       = L_Srv_GIT_Info.LastCommit;
            L_Tracking.WithCommitMsg    = L_Srv_GIT_Info.LastCommitMsg;
            L_Tracking.WithCommitter    = L_Srv_GIT_Info.Committer;
            L_Tracking.WasObjectsInit   = false; 
            
            G_Srv_DB.Tracking_Save(L_Tracking);
            
            new Srv_Tracking(G_Srv_MessageBus, G_Srv_DB)._Check_DB_Objects(G_ProjectInfo);
        }


        //private void _Remake_DBBranchInfoProc(DB.ProjectInfo P_ProjectInfo)
        //{
        //    G_ScriptBuilder.Clear();

        //    G_Srv_Progress._SetProgress(8, "Remake Branch Info Proc...");

        //    Srv_GIT_Info L_Srv_GIT_Info = Srv_GIT._Get_GIT_Info(G_ProjectInfo);


        //    G_ScriptBuilder.AppendLine("-- ================================================");
        //    G_ScriptBuilder.AppendLine("--This stored procedure is created by the Static-XDB application when the");
        //    G_ScriptBuilder.AppendLine("-- app recreates the DB from source files (Push It->To DB).");
        //    G_ScriptBuilder.AppendLine(Environment.NewLine);
        //    G_ScriptBuilder.AppendLine("--The info in the SELECT is used to know with what branch and commit the");
        //    G_ScriptBuilder.AppendLine("-- DB was created at that moment in time.");
        //    G_ScriptBuilder.AppendLine(Environment.NewLine);
        //    G_ScriptBuilder.AppendLine("-- This procedure is ONLY used to help make the dev aware if the branch they");
        //    G_ScriptBuilder.AppendLine("--are on is different to the branch which was used to create the DB.");
        //    G_ScriptBuilder.AppendLine("-- It is NOT blocking in any way.");
        //    G_ScriptBuilder.AppendLine("-- ================================================");
        //    G_ScriptBuilder.AppendLine("SET ANSI_NULLS ON");
        //    G_ScriptBuilder.AppendLine("GO");
        //    G_ScriptBuilder.AppendLine("SET QUOTED_IDENTIFIER ON");
        //    G_ScriptBuilder.AppendLine("GO");
        //    G_ScriptBuilder.AppendLine(Environment.NewLine);
        //    G_ScriptBuilder.AppendLine("CREATE PROCEDURE[dbo].[__Static_XDB_BranchInfo__]");
        //    G_ScriptBuilder.AppendLine(Environment.NewLine);

        //    G_ScriptBuilder.AppendLine("AS");
        //    G_ScriptBuilder.AppendLine("BEGIN");

        //    G_ScriptBuilder.AppendLine("SET NOCOUNT ON;");

        //    G_ScriptBuilder.AppendLine("SELECT");
        //    G_ScriptBuilder.AppendLine("'" + L_Srv_GIT_Info.Branch + "' as [Branch]");
        //    G_ScriptBuilder.AppendLine(", '" + L_Srv_GIT_Info.LastCommit + "' as [LastCommit]");
        //    G_ScriptBuilder.AppendLine(", '" + L_Srv_GIT_Info.LastCommitMsg + "' as [LastCommitMsg]");
        //    G_ScriptBuilder.AppendLine(", '" + L_Srv_GIT_Info.Committer + "' as [Committer]");
        //    G_ScriptBuilder.AppendLine(", '" + DateTime.Now.ToString() + "' as [DatePushed]");


        //    G_ScriptBuilder.AppendLine("END");
        //    G_ScriptBuilder.AppendLine("GO");

        //    // Execute built script...
        //    _ExeScript(G_ScriptBuilder);

            
        //}

    }

  
}
