
using Services.DB;
using SharpHTML;

namespace Services
{
    public class Srv_ProjectStatus
    {
        Srv_MessageBus G_Srv_MessageBus = null;
        DB.Srv_DB G_Srv_DB { get; set; }

        public DB.ProjectInfo G_ProjectInfo { get; set; }

        Srv_TimerManager G_Timer = null;
        public Srv_ProjectStatus(Srv_MessageBus P_Srv_MessageBus, DB.Srv_DB P_Srv_DB)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Srv_DB = P_Srv_DB;
            G_Timer = new Srv_TimerManager();
        }
        public void _CheckProjectStatus_Start(DB.ProjectInfo P_ProjectInfo)
        {
            G_ProjectInfo = P_ProjectInfo;

            G_Timer.PrepareTimer(
                () => G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.TransportMessage, _GetMessage()), // Action
                200, // Start Delay in ms
                2000); // Rate in ms
        }

        private string _GetMessage()
        {
            Srv_GIT_Info L_Srv_GIT_Info = Srv_GIT._Get_GIT_Info(G_ProjectInfo);

            //Srv_MSSQL_DBBranchInfo L_Srv_MSSQL_DBBranchInfo = Srv_MSSQL._Get_CreatedWithBranch_Info(G_ProjectInfo);

            DB.Tracking L_Tracking = null;

            if (G_ProjectInfo is not null)
            {
                L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(G_ProjectInfo.Id)).FirstOrDefault();
            }

            TM_Message L_TM_Message = new TM_Message();
            L_TM_Message.Message_Type = TM_Message_Type.DoNothing;

            L_TM_Message.Actions = new List<SH_Action>
            {
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_IsOnline",
                    Value = Srv_MSSQL._IsServerAndDBOnline(G_ProjectInfo)
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_DBBranch",
                    Value = L_Tracking is not null ? L_Tracking.WithBranch : "Unknown"
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_DBLastCommit",
                    Value = L_Tracking is not null ? L_Tracking.WithCommit : "Unknown"
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_DBLastCommitMsg",
                    Value = L_Tracking is not null ? L_Tracking.WithCommitMsg : "Unknown"
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_DBCommitter",
                    Value = L_Tracking is not null ? L_Tracking.WithCommitter : "Unknown"
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_DBInfo_DBDatePushed",
                    Value = L_Tracking is not null ? L_Tracking.DatePushed : "Unknown"
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_Branch",
                    Value = L_Srv_GIT_Info.Branch
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_LastCommit",
                    Value = L_Srv_GIT_Info.LastCommit
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_LastCommitMsg",
                    Value = L_Srv_GIT_Info.LastCommitMsg
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_LastCommitMsg",
                    Value = L_Srv_GIT_Info.LastCommitMsg
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_Remote",
                    Value = L_Srv_GIT_Info.Remote
                },
                new SH_Action
                {
                    Action_Type = SH_Action_Type.SetValue,
                    SourceId = "Main_GitInfo_Committer",
                    Value = L_Srv_GIT_Info.Committer
                },



            };

            return SH_ActionGen._ToJSON_String(L_TM_Message);
        }
    }
}
