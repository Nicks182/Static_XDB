
namespace Services
{
    public partial class Srv_Logic
    {
        public void _Launch(TM_Message P_TM_Message)
        {
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.Launch_Remote:
                    _LaunchRemote(P_TM_Message);
                    break;

                case TM_Message_Type.Launch_ProjectFolder:
                    _LaunchProjectFolder(P_TM_Message);
                    break;

                case TM_Message_Type.Launch_ScriptFolder:
                    _LaunchScriptFolder(P_TM_Message);
                    break;

            }

            

        }
    }
}
