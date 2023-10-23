using System.Xml.Serialization;

namespace Services
{
    public partial class Srv_ProjExportImport
    {
        public void _Export_Project(string P_ProjectId)
        {
            
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_GetAll().Find(p => p.Id.Equals(P_ProjectId)).FirstOrDefault();
            List<DB.Ignore> L_Ignores = G_Srv_DB.Ignore_GetAll().Find(i => i.ProjectInfoId.Equals(P_ProjectId)).ToList();

            XmlSerializer L_XmlSerializer = new XmlSerializer(typeof(DB.ProjectInfo));
            using (TextWriter writer = new StreamWriter(Path.Combine(L_ProjectInfo.ProjectFolder, G_ProjectInfo_Filename)))
            {
                L_XmlSerializer.Serialize(writer, L_ProjectInfo);
            }

            L_XmlSerializer = new XmlSerializer(typeof(List<DB.Ignore>));
            using (TextWriter writer = new StreamWriter(Path.Combine(L_ProjectInfo.ProjectFolder, G_ProjectIgnores_Filename)))
            {
                L_XmlSerializer.Serialize(writer, L_Ignores);
            }

            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Export completed.");
        }

    }

}
