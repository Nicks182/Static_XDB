
namespace SharpHTML
{
    public partial class Srv_DriveBrowser
    {
        public List<Srv_DriveBrowser_ItemInfo> GetItems()
        {
            return GetItems(G_ItemType);
        }

        public List<Srv_DriveBrowser_ItemInfo> GetItems(Srv_DriveBrowser_ItemTypes P_ItemType)
        {
            List<Srv_DriveBrowser_ItemInfo> L_Items = new List<Srv_DriveBrowser_ItemInfo>();

            if(G_Current_Dir.Type == Srv_DriveBrowser_ItemInfo_Type.ThisPC)
            {
                return GetDrives();
            }

            DirectoryInfo L_DirectoryInfo = new DirectoryInfo(G_Current_Dir.FullPath);

            if (P_ItemType == Srv_DriveBrowser_ItemTypes.Only_Directories || P_ItemType == Srv_DriveBrowser_ItemTypes.Both)
            {
                foreach (DirectoryInfo L_DirInfo in L_DirectoryInfo.EnumerateDirectories())
                {
                    L_Items.Add(new Srv_DriveBrowser_ItemInfo
                    {
                        FullPath = L_DirInfo.FullName,
                        Name = L_DirInfo.Name,
                        Type = Srv_DriveBrowser_ItemInfo_Type.Driectory
                    });
                }
            }

            if (P_ItemType == Srv_DriveBrowser_ItemTypes.Only_Files || P_ItemType == Srv_DriveBrowser_ItemTypes.Both)
            {
                foreach (FileInfo L_FileInfo in L_DirectoryInfo.GetFiles())
                {
                    L_Items.Add(new Srv_DriveBrowser_ItemInfo
                    {
                        FullPath = L_FileInfo.FullName,
                        Name = L_FileInfo.Name,
                        Type = Srv_DriveBrowser_ItemInfo_Type.File
                    });
                }
            }

            return L_Items;
        }

    }

}
