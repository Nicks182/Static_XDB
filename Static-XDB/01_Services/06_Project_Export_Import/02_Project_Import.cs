using System.Xml.Serialization;

namespace Services
{
    public partial class Srv_ProjExportImport
    {
        public void _Import_Project(string P_Path)
        {
            if (File.Exists(Path.Combine(P_Path, G_ProjectInfo_Filename)) == false)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, G_ProjectInfo_Filename + " file not found.");
                return;
            }

            DB.ProjectInfo L_ProjectInfo = new DB.ProjectInfo();

            XmlSerializer L_XmlSerializer = new XmlSerializer(typeof(DB.ProjectInfo));
            using (TextReader reader = new StreamReader(Path.Combine(P_Path, G_ProjectInfo_Filename)))
            {
                L_ProjectInfo = (DB.ProjectInfo)L_XmlSerializer.Deserialize(reader);
            }


            if(G_Srv_DB.ProjectInfo_GetAll().Find(p => p.Name.Equals(L_ProjectInfo.Name)).Any() == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Project with the same Name already exists.");
                return;
            }

            L_ProjectInfo.Id = null;
            G_Srv_DB.ProjectInfo_Save(L_ProjectInfo);

            if (File.Exists(Path.Combine(P_Path, G_ProjectIgnores_Filename)) == true)
            {
                List<DB.Ignore> L_Ignores = new List<DB.Ignore>();

                L_XmlSerializer = new XmlSerializer(typeof(List<DB.Ignore>));
                using (TextReader reader = new StreamReader(Path.Combine(P_Path, G_ProjectIgnores_Filename)))
                {
                    L_Ignores = (List<DB.Ignore>)L_XmlSerializer.Deserialize(reader);
                }

                for (int i = 0; i < L_Ignores.Count; i++)
                {
                    L_Ignores[i].Id = null;
                    G_Srv_DB.Ignore_Save(L_Ignores[i]);
                }
            }
            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Import completed.");

        }

    }

}
