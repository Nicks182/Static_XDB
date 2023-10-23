using System.Text;
using System.Xml.Serialization;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Projects_Import_Load(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_FormState_Item = G_SH_State.Get_Current();
            string L_FolderPath = L_SH_FormState_Item._GetValue_String("Project_Import_ProjectFolder");

            if(string.IsNullOrEmpty(L_FolderPath) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Please select Project Folder.");
                return;
            }

            Srv_ProjExportImport_Info L_Srv_ProjExportImport_Info = new Srv_ProjExportImport(G_Srv_MessageBus, G_Srv_DB)._Import_Project_GetInfo(L_FolderPath);
            if (L_Srv_ProjExportImport_Info is not null)
            {
                StringBuilder L_Html = new StringBuilder();
                L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Projects_Import_Body_Info(L_Srv_ProjExportImport_Info)));

                P_TM_Message.HTMLs.Add(new TM_Message_Html
                {
                    ContainerId = HTML_Components_Names.Div_Project_Import_Info.ToString(),
                    HTML = L_Html.ToString(),
                    IsAppend = false
                });
            }
        }

    }
}
