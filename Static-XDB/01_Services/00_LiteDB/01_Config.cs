using LiteDB;

namespace Services.DB
{
    public class Config
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    public partial class Srv_DB
    {
        public ILiteCollection<Config> Config_GetAll()
        {
            return this.G_Config;
        }


        public Config Config_Get(string P_Id)
        {
            return this.G_Config.FindOne(a => a.Id == P_Id);
        }

        public void Config_Save(Config P_Config)
        {
            if (string.IsNullOrEmpty(P_Config.Id))
            {
                P_Config.Id = Guid.NewGuid().ToString();
                this.G_Config.Insert(P_Config);
            }
            else
            {
                this.G_Config.Update(P_Config);
            }
        }

        public void Config_Delete(Config P_Config)
        {
            this.G_Config.Delete(P_Config.Id);
        }

    }
}
