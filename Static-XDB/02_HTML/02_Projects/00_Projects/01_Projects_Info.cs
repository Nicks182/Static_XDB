
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Projects_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Lists all your projects. Can add, edit, export, and remove projects here or import a project from file.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "New: ",
                Description = "Allows you to add a new project.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Import: ",
                Description = "Allows you to import project info from a file if the project folder contains one.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Edit: ",
                Description = "Will take you to the edit screen for specific project.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Export: ",
                Description = "Will export project details including Ignored items to xml files inside of project folder. These files will be part of your GIT repository by default. The files can then be imported by other's after cloning the repository to their local machines.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Remove: ",
                Description = "Will delete specific project from the local DB.",
            });

            return _Screen_Info(L_Info_Items);
        }



    }
}
