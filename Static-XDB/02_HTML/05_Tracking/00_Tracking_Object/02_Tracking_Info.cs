
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Shows which SQL Objects have changes in the Database.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Check For Changes: ",
                Description = "Click to query DB to check for changes and refresh UI.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Compare (><): ",
                Description = "Click compare button left of row to view differences between object in Database and Script file.",
            });

            return _Screen_Info(L_Info_Items);
        }
    }
}
