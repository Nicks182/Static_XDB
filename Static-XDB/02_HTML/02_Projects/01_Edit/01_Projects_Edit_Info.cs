
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Project_Edit_Info()
        {
            List<HTML_ScreenInfo_Item> L_Info_Items = new List<HTML_ScreenInfo_Item>();

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Specify detail about where your project is stored, where the scripts are stored inside of project folder, and the actual Database.",
                Description = "",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Project Folder: ",
                Description = "This should be the main folder. Typically this will be your GIT project folder.",
            });

            //L_Info_Items.Add(new HTML_ScreenInfo_Item
            //{
            //    Caption = "Scripts Folder Name: ",
            //    Description = "Static-XDB will place the generated script files in this folder inside of your Project Folder. You can specify your own folder name or leave it blank and it will default to 'Scripts'.",
            //});

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Name: ",
                Description = "Short name to easily identiy the project.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "SQL Version: ",
                Description = "SQL Version used to ensure scripts are compatible with minimum version of MS SQL.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Server: ",
                Description = "The Server you wish to use for this project.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Port: ",
                Description = "Port number used for SQL server. Can leave blank for default.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Username: ",
                Description = "Can leave blank if using Intergrated Security.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Password: ",
                Description = "Can leave blank if using Intergrated Security.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Intergrated: ",
                Description = "Use current Windows account to connect to SQL Server.",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Trust Server Certificate: ",
                Description = "Just trust me bro....",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "DB Name: ",
                Description = "The name of the Database to be used. Static-XDB will create the DB if it does not already exist",
            });

            L_Info_Items.Add(new HTML_ScreenInfo_Item
            {
                Caption = "Description: ",
                Description = "Extra info about the Project.",
            });

            return _Screen_Info(L_Info_Items);
        }



    }
}
