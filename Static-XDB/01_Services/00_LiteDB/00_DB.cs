using System.Diagnostics;

using LiteDB;

namespace Services.DB
{
    public partial class Srv_DB
    {
        const string G_DB_Name = "Static_XDB.LiteDB";
        private LiteDatabase G_DB;

        private ILiteCollection<ProjectInfo> G_ProjectInfo;
        private ILiteCollection<Ignore> G_Ignore;
        private ILiteCollection<Config> G_Config;
        private ILiteCollection<Tracking> G_Tracking;
        private ILiteCollection<Tracking_Object> G_Tracking_Object;
        private ILiteCollection<Tracking_Data> G_Tracking_Data;
        


        public Srv_DB()
        {
            G_DB = new LiteDatabase(GetAppPath());
            
            this.G_ProjectInfo      = G_DB.GetCollection<ProjectInfo>("ProjectInfo");
            this.G_Ignore           = G_DB.GetCollection<Ignore>("Ignore");
            this.G_Config           = G_DB.GetCollection<Config>("Config");
            this.G_Tracking         = G_DB.GetCollection<Tracking>("Tracking");
            this.G_Tracking_Object  = G_DB.GetCollection<Tracking_Object>("Tracking_Object");
            this.G_Tracking_Data    = G_DB.GetCollection<Tracking_Data>("Tracking_Data");
        }

        public void Dispose()
        {
            G_DB.Dispose();
        }

        private string GetAppPath()
        {
            //return Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory , G_DB_Name);
            //return Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), G_DB_Name);
            return Path.Combine(Process.GetCurrentProcess().MainModule.FileName.Replace("\\Static-XDB.exe", "").Replace("\\dotnet.exe", ""), G_DB_Name);
        }

        public void ClearDB()
        {
            //this.G_DB_Apps.DeleteAll();
            //this.G_DB_Devices.DeleteAll();
        }

    }
}
