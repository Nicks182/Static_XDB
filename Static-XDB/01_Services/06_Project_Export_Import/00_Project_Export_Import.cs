namespace Services
{
    public partial class Srv_ProjExportImport
    {
        const string G_ProjectInfo_Filename = "ProjectInfo.xml";
        const string G_ProjectIgnores_Filename = "ProjectIgnores.xml";

        private Srv_MessageBus G_Srv_MessageBus;
        private Srv_Progress G_Srv_Progress;
        DB.Srv_DB G_Srv_DB { get; set; }

        public Srv_ProjExportImport(Srv_MessageBus P_Srv_MessageBus, DB.Srv_DB P_Srv_DB)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Srv_DB = P_Srv_DB;

        }

    }

    public class Srv_ProjExportImport_Info
    {
        public DB.ProjectInfo ProjectInfo { get; set; }
        public List<DB.Ignore> Ignores { get; set; }
    }
}
