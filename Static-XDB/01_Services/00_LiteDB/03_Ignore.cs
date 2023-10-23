using LiteDB;

namespace Services.DB
{
    public class Ignore
    {
        public string Id { get; set; } = "";
        public string ProjectInfoId { get; set; } = "";
        public string Name { get; set; } = "";
        public Ignore_Type Type { get; set; }
    }

    public enum Ignore_Type
    {
        Schema,
        User,
        Table,
        View,
        Proc,
        Func,
        Syn,
        Trig,
        Data,
    }

    public partial class Srv_DB
    {
        public ILiteCollection<Ignore> Ignore_GetAll()
        {
            return this.G_Ignore;
        }


        public Ignore Ignore_Get(string P_Id)
        {
            return this.G_Ignore.FindOne(a => a.Id == P_Id);
        }

        public void Ignore_Save(Ignore P_Ignore)
        {
            if (string.IsNullOrEmpty(P_Ignore.Id))
            {
                P_Ignore.Id = Guid.NewGuid().ToString();
                this.G_Ignore.Insert(P_Ignore);
            }
            else
            {
                this.G_Ignore.Update(P_Ignore);
            }
        }

        public void Ignore_Delete(Ignore P_Ignore)
        {
            this.G_Ignore.Delete(P_Ignore.Id);
        }

    }
}
