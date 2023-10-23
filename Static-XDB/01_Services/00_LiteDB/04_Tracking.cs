using LiteDB;

namespace Services.DB
{
    public class Tracking
    {
        public string Id { get; set; } = "";
        public string ProjectInfoId { get; set; } = "";
        public string Name { get; set; } = "";
        public string WithBranch { get; set; } = "";
        public string WithCommit { get; set; } = "";
        public string WithCommitMsg { get; set; } = "";
        public string WithCommitter { get; set; } = "";
        public string DatePushed { get; set; } = "";
        public bool WasObjectsInit { get; set; } = false;
        public bool WasDataInit { get; set; } = false;
    }

    public partial class Srv_DB
    {
        public ILiteCollection<Tracking> Tracking_GetAll()
        {
            return this.G_Tracking;
        }


        public Tracking Tracking_Get(string P_Id)
        {
            return this.G_Tracking.FindOne(a => a.Id == P_Id);
        }

        public void Tracking_Save(Tracking P_Tracking)
        {
            if (string.IsNullOrEmpty(P_Tracking.Id))
            {
                P_Tracking.Id = Guid.NewGuid().ToString();
                this.G_Tracking.Insert(P_Tracking);
            }
            else
            {
                this.G_Tracking.Update(P_Tracking);
            }
        }

        public void Tracking_Delete(Tracking P_Tracking)
        {
            this.G_Tracking.Delete(P_Tracking.Id);
        }

    }
}
