
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Data_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Shows which Tables have Data changes in the Database.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Check For Data Changes: ",
                Description = "Click to query DB to check for changes and update UI. If you have a lot of data, this may take a while to run.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Compare (><): ",
                Description = "Click compare button left of row to view changes between Data Records in Database and Script files for a given Table.",
            });

            return _Screen_Info(L_Info_Items);
        }
    }
}
