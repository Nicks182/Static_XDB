using LiteDB;

namespace Services.DB
{
    public class Tracking_Data
    {
        public string Id { get; set; } = "";
        public string TrackingId { get; set; } = "";
        public string TableName { get; set; } = "";
        public string LastCheck { get; set; } = "";
        public int Changed { get; set; } = 0;
    }

    public partial class Srv_DB
    {
        public ILiteCollection<Tracking_Data> Tracking_Data_GetAll()
        {
            return this.G_Tracking_Data;
        }


        public Tracking_Data Tracking_Data_Get(string P_Id)
        {
            return this.G_Tracking_Data.FindOne(a => a.Id == P_Id);
        }

        public void Tracking_Data_Save(Tracking_Data P_Tracking_Data)
        {
            if (string.IsNullOrEmpty(P_Tracking_Data.Id))
            {
                P_Tracking_Data.Id = Guid.NewGuid().ToString();
                this.G_Tracking_Data.Insert(P_Tracking_Data);
            }
            else
            {
                this.G_Tracking_Data.Update(P_Tracking_Data);
            }
        }

        public void Tracking_Data_Delete(Tracking_Data P_Tracking_Data)
        {
            this.G_Tracking_Data.Delete(P_Tracking_Data.Id);
        }

    }
}
