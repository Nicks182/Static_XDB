
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Get_IgnoredObjects_Edit(SH_State_Item P_SH_State_Item)
        {
            return _Screen(
                "Ignored Objects: Edit", 
                _IgnoredObjects_Edit_SubHeader(P_SH_State_Item), 
                _IgnoredObjects_Modify_Info(), 
                _IgnoredObjects_Edit_Form_Body(P_SH_State_Item), 
                _IgnoredObjects_Edit_Footer());
        }
    }
}
