using System.Xml.Serialization;

namespace Services
{
    public partial class Srv_ProjExportImport
    {
        public Srv_ProjExportImport_Info _Import_Project_GetInfo(string P_Path)
        {
            Srv_ProjExportImport_Info L_Srv_ProjExportImport_Info = new Srv_ProjExportImport_Info();

            if (File.Exists(Path.Combine(P_Path, G_ProjectInfo_Filename)) == false)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, G_ProjectInfo_Filename + " file not found.");
                return null;
            }

            XmlSerializer L_XmlSerializer = new XmlSerializer(typeof(DB.ProjectInfo));
            using (TextReader reader = new StreamReader(Path.Combine(P_Path, G_ProjectInfo_Filename)))
            {
                L_Srv_ProjExportImport_Info.ProjectInfo = (DB.ProjectInfo)L_XmlSerializer.Deserialize(reader);
            }

            if (File.Exists(Path.Combine(P_Path, G_ProjectIgnores_Filename)) == true)
            {
                L_XmlSerializer = new XmlSerializer(typeof(List<DB.Ignore>));
                using (TextReader reader = new StreamReader(Path.Combine(P_Path, G_ProjectIgnores_Filename)))
                {
                    L_Srv_ProjExportImport_Info.Ignores = (List<DB.Ignore>)L_XmlSerializer.Deserialize(reader);
                }

                
            }

            return L_Srv_ProjExportImport_Info;
        }

    }

}
