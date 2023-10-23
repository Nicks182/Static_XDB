
using Services.DB;
using System.Diagnostics;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _LaunchScriptFolder(TM_Message P_TM_Message)
        {
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_TM_Message.Data);
            if (L_ProjectInfo is not null && string.IsNullOrEmpty(L_ProjectInfo.ProjectFolder) == false)
            {
                System.Diagnostics.Process.Start("explorer.exe", Srv_ScriptsFolder._Get(L_ProjectInfo));
            }
        }
    }
}
