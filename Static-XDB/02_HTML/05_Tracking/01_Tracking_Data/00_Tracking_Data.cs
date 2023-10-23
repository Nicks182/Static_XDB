
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Tracking_Data(List<Services.DB.Tracking_Data> P_Tracking_Data)
        {
            return _Screen(
                "DB Changes",
                _Tracking_Data_SubHeader(),
                _Tracking_Data_Info(),
                _Tracking_Data_Body(P_Tracking_Data),
                _Tracking_Data_Footer());
        }
    }
}
