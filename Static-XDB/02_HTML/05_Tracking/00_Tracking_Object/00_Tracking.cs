
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Tracking(Services.DB.Tracking P_Tracking, List<Services.DB.Tracking_Object> P_Tracking_Objects)
        {
            return _Screen(
                "DB Changes",
                _Tracking_SubHeader(),
                _Tracking_Info(),
                _Tracking_Body(P_Tracking, P_Tracking_Objects),
                _Tracking_Footer());
        }
    }
}
