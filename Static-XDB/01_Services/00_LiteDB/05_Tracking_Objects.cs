using LiteDB;

namespace Services.DB
{
    public class Tracking_Object
    {
        public string Id { get; set; } = "";
        public string TrackingId { get; set; } = "";
        public string ObjectId { get; set; } = "";
        public string ObjectName { get; set; } = "";
        public string ObjectType { get; set; } = "";
        public string ObjectTypeDesc { get; set; } = "";
        public string CreatedOn { get; set; } = "";
        public string LastChanged { get; set; } = "";
        public int Changed { get; set; } = 0;
        public bool IsRemoved { get; set; } = false;
    }

    public partial class Srv_DB
    {
        public ILiteCollection<Tracking_Object> Tracking_Object_GetAll()
        {
            return this.G_Tracking_Object;
        }


        public Tracking_Object Tracking_Object_Get(string P_Id)
        {
            return this.G_Tracking_Object.FindOne(a => a.Id == P_Id);
        }

        public void Tracking_Object_Save(Tracking_Object P_Tracking_Object)
        {
            if (string.IsNullOrEmpty(P_Tracking_Object.Id))
            {
                P_Tracking_Object.Id = Guid.NewGuid().ToString();
                this.G_Tracking_Object.Insert(P_Tracking_Object);
            }
            else
            {
                this.G_Tracking_Object.Update(P_Tracking_Object);
            }
        }

        public void Tracking_Object_Delete(Tracking_Object P_Tracking_Object)
        {
            this.G_Tracking_Object.Delete(P_Tracking_Object.Id);
        }

    }
}
