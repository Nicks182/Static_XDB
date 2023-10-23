
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Import_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "If your project folder contains a ProjectInfo file then you can import. This file will be part of your GIT repository by default.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Project Folder: ",
                Description = "This should be the main folder. Typically this will be your GIT project folder.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "View Info: ",
                Description = "This will try and load the ProjectInfo file in the selected folder and display it's contents for review.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Save: ",
                Description = "Clicking Save will save the info from the file to the local DB and take you to the list of projects screen.",
            });

            return _Screen_Info(L_Info_Items);
        }



    }
}
