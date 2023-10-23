
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _PushIt_ShowModal(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_SH_State_Item.G_Controls.Where(c => c.Id == "Main_Project_Id").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            if(L_ProjectInfo is null)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "No project selected. Create a new project first.");
                return;
            }

            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;
            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._PushIt_Modal(P_TM_Message.UniqueId)).ToString(),
                IsAppend = true
            });


        }
    }
}
