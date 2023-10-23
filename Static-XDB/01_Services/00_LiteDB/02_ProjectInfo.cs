using LiteDB;

namespace Services.DB
{
    public class ProjectInfo
    {
        public string Id { get; set; } = string.Empty;
        
        public string Name { get; set; } = "";
        public string Server { get; set; } = "";
        public string Port { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = string.Empty;
        
        public string DBName { get; set; } = "";
        public string SQLVersion { get; set; } = "";
        public string ProjectFolder { get; set; } = "";
        //public string ScriptFolder { get; set; } = "";
        public string Description { get; set; } = "";

        public bool Integrated { get; set; } = false;
        public bool TrustServerCertificate { get; set; } = false;
    }

    public partial class Srv_DB
    {
        public ILiteCollection<ProjectInfo> ProjectInfo_GetAll()
        {
            return this.G_ProjectInfo;
        }


        public ProjectInfo ProjectInfo_Get(string P_Id)
        {
            return this.G_ProjectInfo.FindOne(a => a.Id == P_Id);
        }

        public void ProjectInfo_Save(ProjectInfo P_ProjectInfo)
        {
            if (string.IsNullOrEmpty(P_ProjectInfo.Id))
            {
                P_ProjectInfo.Id = Guid.NewGuid().ToString();
                this.G_ProjectInfo.Insert(P_ProjectInfo);
            }
            else
            {
                this.G_ProjectInfo.Update(P_ProjectInfo);
            }
        }

        public void ProjectInfo_Delete(ProjectInfo P_ProjectInfo)
        {
            this.G_ProjectInfo.Delete(P_ProjectInfo.Id);
        }

    }
}
