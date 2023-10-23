
namespace SharpHTML
{
    public partial class Srv_DriveBrowser
    {
        public List<Srv_DriveBrowser_ItemInfo> GetDrives()
        {
            List< Srv_DriveBrowser_ItemInfo > L_Items = new List<Srv_DriveBrowser_ItemInfo>();

            foreach(var L_Drive in DriveInfo.GetDrives())
            {
                L_Items.Add(new Srv_DriveBrowser_ItemInfo
                {
                    FullPath = L_Drive.RootDirectory.FullName,
                    Name = L_Drive.Name,
                    Type = Srv_DriveBrowser_ItemInfo_Type.Drive,
                });
            }

            return L_Items;
        }

    }

}
