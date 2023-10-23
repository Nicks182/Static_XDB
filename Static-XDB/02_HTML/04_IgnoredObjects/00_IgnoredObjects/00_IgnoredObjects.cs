
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Get_IgnoredObjects(SH_State_Item P_SH_State_Item, List<Services.DB.Ignore> P_Ignores)
        {
            return _Screen(
                "Ignored Objects",
                //_IgnoredObjects_SubHeader(P_SH_State_Item), 
                null, 
                _IgnoredObjects_Info(), 
                _IgnoredObjects_Body(P_Ignores), 
                _IgnoredObjects_Footer());

        }

        

    }
}
