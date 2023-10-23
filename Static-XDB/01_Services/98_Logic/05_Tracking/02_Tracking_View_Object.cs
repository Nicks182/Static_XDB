using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private void _Tracking_View(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "Main_Project_Id").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            if (L_ProjectInfo is null)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "No project selected. Create a new project first.");
                return;
            }

            SH_State_Item L_Tracking_State = _Tracking_State(L_State_Item.Id, L_ProjectInfo);


            //DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();

            _Tracking_View_Render(P_TM_Message, L_ProjectInfo.Id);

            //List<DB.Tracking_Object> L_Tracking_Object = G_Srv_DB.Tracking_Object_GetAll()
            //    .Find(to => to.TrackingId.Equals(L_Tracking.Id))
            //    .OrderByDescending(to => to.Changed)
            //    .ThenBy(to => to.ObjectType)
            //    .ThenBy(to => to.ObjectName)
            //    .ToList();

            //StringBuilder L_Html = new StringBuilder();
            //L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Tracking(L_Tracking, L_Tracking_Object)));

            //P_TM_Message.HTMLs.Add(new TM_Message_Html
            //{
            //    ContainerId = HTML_Components_Names.Div_Body.ToString(),
            //    HTML = L_Html.ToString(),
            //    IsAppend = false
            //});
        }

        private void _Tracking_View_Render(TM_Message P_TM_Message, string P_ProjectId)
        {
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_ProjectId);

            DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();

            if(L_Tracking is null)
            {
                new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo)._Remake_DB_Tracking_Update(L_ProjectInfo);
                L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();
            }

            _Tracking_View_Render(P_TM_Message, L_Tracking);
        }
        private void _Tracking_View_Render(TM_Message P_TM_Message, DB.Tracking P_Tracking)
        {
            //DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();

            List<DB.Tracking_Object> L_Tracking_Object = G_Srv_DB.Tracking_Object_GetAll()
                .Find(to => to.TrackingId.Equals(P_Tracking.Id))
                .OrderByDescending(to => to.Changed)
                .ThenBy(to => to.ObjectType)
                .ThenBy(to => to.ObjectName)
                .ToList();

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Tracking(P_Tracking, L_Tracking_Object)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

    }
}
