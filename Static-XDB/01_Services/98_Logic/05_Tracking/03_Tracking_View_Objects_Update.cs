using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Tracking_View_Objects_Update(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            G_Srv_Tracking._Check_DB_Objects(L_ProjectInfo);

            DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();

            List<DB.Tracking_Object> L_Tracking_Object = G_Srv_DB.Tracking_Object_GetAll()
                .Find(to => to.TrackingId.Equals(L_Tracking.Id))
                .OrderByDescending(to => to.Changed)
                .ThenBy(to => to.ObjectType)
                .ThenBy(to => to.ObjectName)
                .ToList();

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Tracking(L_Tracking, L_Tracking_Object)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }
    }
}
