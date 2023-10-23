
namespace SharpHTML
{
    public partial class Srv_DriveBrowser
    {
        public List<Srv_DriveBrowser_ItemInfo> Go_To(string P_Path)
        {
            return Go_To(G_ItemType, P_Path);
        }
        public List<Srv_DriveBrowser_ItemInfo> Go_To(Srv_DriveBrowser_ItemTypes P_ItemType, string P_Path)
        {
            DirectoryInfo L_DirectoryInfo = new DirectoryInfo(P_Path);
            G_Current_Dir = new Srv_DriveBrowser_ItemInfo
            {
                FullPath = L_DirectoryInfo.FullName,
                Name = L_DirectoryInfo.Name,
                Type = Srv_DriveBrowser_ItemInfo_Type.Driectory,
            };

            return GetItems(P_ItemType);
        }



    }

}
