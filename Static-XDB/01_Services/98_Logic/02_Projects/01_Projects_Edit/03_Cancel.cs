
namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _Projects_Cancel(TM_Message P_TM_Message)
        {
            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.Projects_Show;
            _Projects_Show(P_TM_Message);


        }


    }
}
