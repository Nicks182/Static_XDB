
namespace SharpHTML
{
    public partial class Srv_DriveBrowser
    {
        public List<Srv_DriveBrowser_ItemInfo> Go_Up()
        {
            return Go_Up(G_ItemType);
        }
        public List<Srv_DriveBrowser_ItemInfo> Go_Up(Srv_DriveBrowser_ItemTypes P_ItemType)
        {
            DirectoryInfo L_DirectoryInfo = new DirectoryInfo(G_Current_Dir.FullPath);
            if (L_DirectoryInfo.Parent is not null)
            {
                G_Current_Dir = new Srv_DriveBrowser_ItemInfo
                {
                    FullPath = L_DirectoryInfo.Parent.FullName,
                    Name = L_DirectoryInfo.Parent.Name,
                    Type = Srv_DriveBrowser_ItemInfo_Type.Driectory,
                };
            }
            else
            {
                _SetDefaultStartLocation(null);
            }

            return GetItems(P_ItemType);
        }


    }

}
