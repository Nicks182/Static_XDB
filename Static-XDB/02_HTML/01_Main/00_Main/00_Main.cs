
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main(SH_State_Item P_SH_State_Item)
        {
            return _Screen(
                "Home",
                null, 
                _Main_Info(), 
                _Main_Body(P_SH_State_Item), 
                _Main_Footer());
        }
    }

    
}
