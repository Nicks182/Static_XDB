using System.Text;
using System.Xml.Serialization;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Projects_Import_Save(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_FormState_Item = G_SH_State.Get_Current();

            string L_FolderPath = L_SH_FormState_Item._GetValue_String("Project_Import_ProjectFolder");

            if (string.IsNullOrEmpty(L_FolderPath) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Please select Project Folder.");
                return;
            }

            Srv_ProjExportImport_Info L_Srv_ProjExportImport_Info = new Srv_ProjExportImport(G_Srv_MessageBus, G_Srv_DB)._Import_Project_GetInfo(L_FolderPath);
            if (L_Srv_ProjExportImport_Info is not null)
            {
                if(G_Srv_DB.ProjectInfo_GetAll().Find(p => p.Name.Equals(L_Srv_ProjExportImport_Info.ProjectInfo.Name)).Any() == true)
                {
                    G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Project with name '" + L_Srv_ProjExportImport_Info.ProjectInfo.Name + "' already exists.");
                    P_TM_Message.Message_Type = TM_Message_Type.DoNothing;
                    return;
                }

                L_Srv_ProjExportImport_Info.ProjectInfo.Id = null;
                L_Srv_ProjExportImport_Info.ProjectInfo.ProjectFolder = L_FolderPath;
                G_Srv_DB.ProjectInfo_Save(L_Srv_ProjExportImport_Info.ProjectInfo);

                for(int i = 0; i < L_Srv_ProjExportImport_Info.Ignores.Count; i++)
                {
                    L_Srv_ProjExportImport_Info.Ignores[i].Id = null;
                    L_Srv_ProjExportImport_Info.Ignores[i].ProjectInfoId = L_Srv_ProjExportImport_Info.ProjectInfo.Id;
                    G_Srv_DB.Ignore_Save(L_Srv_ProjExportImport_Info.Ignores[i]);
                }

                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Import Done.");

                P_TM_Message.Actions.Clear();
                P_TM_Message.Message_Type = TM_Message_Type.Projects_Show;
                _Projects_Show(P_TM_Message);
            }
        }

    }
}
