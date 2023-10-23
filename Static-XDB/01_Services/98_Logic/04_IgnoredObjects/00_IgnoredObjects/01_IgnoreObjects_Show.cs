using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _IgnoredObjects_Show(TM_Message P_TM_Message)
        {

            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "Main_Project_Id").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            if(L_ProjectInfo is null)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "No project selected. Create a new project first.");
                return;
            }

            SH_State_Item L_SH_FormState_Item = _IgnoredObjects_Show_State(L_State_Item.Id, L_ProjectInfo);

            _IgnoredObjects_Show_Render(P_TM_Message, L_SH_FormState_Item, L_ProjectInfo.Id);

        }

        private void _IgnoredObjects_Show_Render(TM_Message P_TM_Message, SH_State_Item P_State_Item, string P_ProjectInfoId)
        {

            List<Services.DB.Ignore> L_Ignores = G_Srv_DB.Ignore_GetAll().Find(i => i.ProjectInfoId == P_ProjectInfoId).OrderBy(i => i.Name).ToList();

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_IgnoredObjects(P_State_Item, L_Ignores)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

    }
}
