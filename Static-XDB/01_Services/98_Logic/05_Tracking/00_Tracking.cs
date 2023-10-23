
namespace Services
{
    public partial class Srv_Logic
    {
        public void _Tracking(TM_Message P_TM_Message)
        {
            switch (P_TM_Message.Message_Type)
            {
                case TM_Message_Type.Tracking_View_Objects:
                    _Tracking_View(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_View_Data:
                    _Tracking_View_Data(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_Check_Objects:
                    _Tracking_View_Objects_Update(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_Check_Data:
                    _Tracking_View_Data_Update(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_View_Diff:
                    _Tracking_View_Diff(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_View_Diff_Data:
                    _Tracking_View_Diff_Data(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_View_Diff_Back:
                    _Tracking_View_Diff_Back(P_TM_Message);
                    break;

                case TM_Message_Type.Tracking_View_Diff_Back_Data:
                    _Tracking_View_Diff_Data_Back(P_TM_Message);
                    break;

            }

            

        }
    }
}
