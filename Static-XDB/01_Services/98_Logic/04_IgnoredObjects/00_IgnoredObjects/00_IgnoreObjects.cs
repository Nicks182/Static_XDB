
namespace Services
{
    public partial class Srv_Logic
    {
        public void _IgnoredObjects(TM_Message P_TM_Message)
        {
            
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.Ignores_Show:
                    _IgnoredObjects_Show(P_TM_Message);
                    break;

                case TM_Message_Type.Ignores_Modify_Show:
                    _IgnoredObjects_Modify(P_TM_Message);
                    break;

                case TM_Message_Type.Ignores_Modify_Remove:
                    _IgnoredObjects_Remove(P_TM_Message);
                    break;

                case TM_Message_Type.Ignores_Modify_ChangeType:
                    _IgnoredObjects_ChangeType(P_TM_Message);
                    break;

                case TM_Message_Type.Ignores_Modify_Save:
                    _IgnoredObjects_Save(P_TM_Message);
                    break;

                case TM_Message_Type.Ignores_Modify_Close:
                    _IgnoredObjects_Close(P_TM_Message);
                    break;
            }

            

        }
    }
}
