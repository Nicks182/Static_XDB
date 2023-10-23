
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _IgnoredObjects_Modify_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Select which object(s) Static-XDB should ignore when Pushing to Files.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Click one of the buttons to list different type of objects like Views, Tables, ect.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "When an object is CHECKED, Static-XDB will ignore that object and NOT script it and the object will not be part of the project.",
                Description = "",
            });

            return _Screen_Info(L_Info_Items);
        }
    }
}
