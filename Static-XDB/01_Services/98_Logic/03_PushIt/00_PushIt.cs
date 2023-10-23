
namespace Services
{
    public partial class Srv_Logic
    {
        public void _PushIt(TM_Message P_TM_Message)
        {
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.PushIt:
                    _PushIt_ShowModal(P_TM_Message);
                    break;

                case TM_Message_Type.PushIt_To_Files:
                    _PushIt_To_Files(P_TM_Message);
                    break;

                case TM_Message_Type.PushIt_To_DB:
                    _PushIt_To_DB(P_TM_Message);
                    break;

            }

            

        }
    }
}
