
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Edit(SH_State_Item P_SH_State_Item)
        {
            return _Screen(
                "Project: Edit", 
                null, 
                _Project_Edit_Info(), 
                _Project_Edit_Body(P_SH_State_Item), 
                _Project_Edit_Footer());
        }
    }
}
