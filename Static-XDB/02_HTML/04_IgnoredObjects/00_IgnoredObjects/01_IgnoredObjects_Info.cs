
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {

        public HTML_Object _IgnoredObjects_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "List of objects that Static-XDB will ignore when scripting the DB to Files.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Edit (+): ",
                Description = "Click the Edit button to modify which object to ignore.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Remove: ",
                Description = "Click the Remove button left of item to remove from list.",
            });

            return _Screen_Info(L_Info_Items);
        }


    }
}
