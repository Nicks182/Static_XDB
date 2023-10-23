
namespace SharpHTML
{
    public partial class Srv_DriveBrowser
    {
        Srv_DriveBrowser_ItemTypes G_ItemType { get; set; } = Srv_DriveBrowser_ItemTypes.Only_Directories; // Default
        Srv_DriveBrowser_ItemInfo G_Current_Dir { get; set; }

        public Srv_DriveBrowser()
        {
            _SetDefaultStartLocation(null);
        }

        public Srv_DriveBrowser(string P_StartDir)
        {
            _SetDefaultStartLocation(P_StartDir);
        }

        public Srv_DriveBrowser(Srv_DriveBrowser_ItemTypes P_ItemType)
        {
            G_ItemType = P_ItemType;
            _SetDefaultStartLocation(null);
        }

        public Srv_DriveBrowser(string P_StartDir, Srv_DriveBrowser_ItemTypes P_ItemType)
        {
            G_ItemType = P_ItemType;
            _SetDefaultStartLocation(P_StartDir);
        }

        private void _SetDefaultStartLocation(string P_StartDir)
        {
            if (string.IsNullOrEmpty(P_StartDir) == true)
            {
                G_Current_Dir = new Srv_DriveBrowser_ItemInfo
                {
                    FullPath = "This PC",
                    Name = "This PC",
                    Type = Srv_DriveBrowser_ItemInfo_Type.ThisPC,
                };
            }
            else
            {
                DirectoryInfo L_DirectoryInfo = new DirectoryInfo(P_StartDir);
                G_Current_Dir = new Srv_DriveBrowser_ItemInfo
                {
                    FullPath = L_DirectoryInfo.FullName,
                    Name = L_DirectoryInfo.Name,
                    Type = Srv_DriveBrowser_ItemInfo_Type.Driectory,
                };
            }
        }

        public Srv_DriveBrowser_ItemInfo GetCurrentLocation()
        {
            return G_Current_Dir;
        }

    }

    public class Srv_DriveBrowser_ItemInfo
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public Srv_DriveBrowser_ItemInfo_Type Type { get; set; }
    }

    public enum Srv_DriveBrowser_ItemInfo_Type
    {
        Drive,
        Driectory,
        File,
        ThisPC,
    }

    public enum Srv_DriveBrowser_ItemTypes
    {
        Only_Directories,
        Only_Files,
        Both,
    }
}
