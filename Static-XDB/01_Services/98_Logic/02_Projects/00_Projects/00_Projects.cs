
namespace Services
{
    public partial class Srv_Logic
    {
        public void _Projects(TM_Message P_TM_Message)
        {
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.Projects_Show:
                    _Projects_Show(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Export:
                    _Projects_Export(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Import:
                    _Projects_Import(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Import_Load:
                    _Projects_Import_Load(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Import_Cancel:
                    _Projects_Import_Cancel(P_TM_Message);
                    break;
                case TM_Message_Type.Projects_Import_Save:
                    _Projects_Import_Save(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Edit:
                    _Projects_Edit(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Edit_Remove:
                    _Projects_Remove(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Edit_Cancel:
                    _Projects_Cancel(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Edit_Save:
                    _Projects_Save(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Show_Server:
                    //_Projects_Show_Server_Modal(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Select_Server:
                    //_Projects_Select_Server(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Show_SQLVersions:
                    _Projects_Show_SQLVersion_Modal(P_TM_Message);
                    break;

                case TM_Message_Type.Projects_Select_SQLVersions:
                    _Projects_Select_SQLVersion(P_TM_Message);
                    break;

            }
        }
    }
}
