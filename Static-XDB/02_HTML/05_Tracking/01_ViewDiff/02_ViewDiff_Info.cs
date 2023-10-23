
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _ViewDiff_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Shows line changes between SQL Object in database and script file in project folder.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Red: ",
                Description = "Something was Removed.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Green: ",
                Description = "Something was Added.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Yellow: ",
                Description = "Something was Modified.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Gray: ",
                Description = "Something was Added or Removed on the other side...",
            });

            return _Screen_Info(L_Info_Items);
        }
    }
}
