
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Import(SH_State_Item P_SH_State_Item)
        {
            return _Screen(
                "Project: Import", 
                null,
                _Projects_Import_Info(),
                _Projects_Import_Body(P_SH_State_Item),
                _Projects_Import_Footer(P_SH_State_Item));
        }
    }
}
