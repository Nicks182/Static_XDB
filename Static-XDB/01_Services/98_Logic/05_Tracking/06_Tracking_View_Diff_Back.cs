
namespace Services
{
    public partial class Srv_Logic
    {
        public void _Tracking_View_Diff_Back(TM_Message P_TM_Message)
        {
            _Tracking_View_Render(P_TM_Message, P_TM_Message.Data);
        }

        public void _Tracking_View_Diff_Data_Back(TM_Message P_TM_Message)
        {
            _Tracking_View_Data(P_TM_Message, P_TM_Message.Data);
        }


    }
}
