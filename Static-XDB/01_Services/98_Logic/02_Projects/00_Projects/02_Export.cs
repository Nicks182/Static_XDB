using System.Text;
using System.Xml.Serialization;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Projects_Export(TM_Message P_TM_Message)
        {
            //DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_GetAll().Find(p => p.Id.Equals(P_TM_Message.Data)).FirstOrDefault();

            //XmlSerializer L_XmlSerializer = new XmlSerializer(typeof(DB.ProjectInfo));
            //using (TextWriter writer = new StreamWriter(Path.Combine(L_ProjectInfo.ProjectFolder, "ProjectInfo.xml")))
            //{
            //    L_XmlSerializer.Serialize(writer, L_ProjectInfo);
            //}

            new Srv_ProjExportImport(G_Srv_MessageBus, G_Srv_DB)._Export_Project(P_TM_Message.Data);
        }

    }
}
