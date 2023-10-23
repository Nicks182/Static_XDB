
using Services.DB;
using System.Diagnostics;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _LaunchRemote(TM_Message P_TM_Message)
        {
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_TM_Message.Data);
            if (L_ProjectInfo is not null)
            {
                Srv_GIT_Info L_Srv_GIT_Info = Srv_GIT._Get_GIT_Info(L_ProjectInfo);

                if (L_Srv_GIT_Info is not null && string.IsNullOrEmpty(L_Srv_GIT_Info.Remote) == false)
                {
                    Process.Start(new ProcessStartInfo(L_Srv_GIT_Info.Remote) { UseShellExecute = true });
                }
            }
        }
    }
}
