
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Main_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Home screen and shows some info about your selected project like whether the DB is online and if there are any differences between the actual DB and source files.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Project Info: ",
                Description = "Allows you to SELECT the project you wish to work with and displays some info about the selected project.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Edit Projects: ",
                Description = "Takes you to your list of projects where you can add, edit, or remove projects.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Database Info: ",
                Description = "This section shows info related to the actual DB like if it's online and also how many differences there are if any have been made since the last push to DB. Can view which objects have changed by clicking the View Changes button.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "View Object Changes: ",
                Description = "Allows you to check and view of changes made to things like Stored Procs, Views, Tables, ect. Static-XDB will script objects from the DB and compare them to the old script files inside the project folder.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "View Data Changes: ",
                Description = "Allows you to check and view changes made to Data. Static-XDB will script the Data from a Table in the DB and compare them to the old script files inside the project folder.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Ignore: ",
                Description = "Takes you to your list of ignored objects for the selected project where you can then edit what to Ignore when pushing to files.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "GIT Info: ",
                Description = "If you’re using GIT then this section will show some info like Name, Branch, Last Commit, and if the actual DB is on the same branch as your source files.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Remote: ",
                Description = "Can click the Remote button which will open the URL in the browser.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Project Folder: ",
                Description = "Can click the Project Folder button which will open the folder.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Script Folder: ",
                Description = "Can click the Script Folder button which will open the folder.",
            });

            return _Screen_Info(L_Info_Items);
        }
    }

    
}
