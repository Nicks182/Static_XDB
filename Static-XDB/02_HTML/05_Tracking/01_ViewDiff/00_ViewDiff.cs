
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _ViewDiff(Srv_Tracking_DiffInfo P_Srv_Tracking_DiffInfo)
        {
            return _Screen(
                "Comparing: (" + P_Srv_Tracking_DiffInfo.ObjectName + ")",
                _ViewDiff_SubHeader(P_Srv_Tracking_DiffInfo),
                _ViewDiff_Info(),
                _ViewDiff_Body(P_Srv_Tracking_DiffInfo),
                _ViewDiff_Footer(P_Srv_Tracking_DiffInfo));
        }

        
    }
}
