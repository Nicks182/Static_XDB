using Services.DB;
using SharpHTML;
using Static_XDB.HTML;
using System.Text;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Tracking_View_Diff(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            Srv_Tracking_DiffInfo L_Srv_Tracking_DiffInfo = G_Srv_Tracking._ViewDiff(L_ProjectInfo, P_TM_Message.Data);

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._ViewDiff(L_Srv_Tracking_DiffInfo)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

        public void _Tracking_View_Diff_Data(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());
            Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo);
            
            Environment.CurrentDirectory = Srv_ScriptsFolder._Get(L_ProjectInfo);

            Srv_Tracking_DiffInfo L_Srv_Tracking_DiffInfo = G_Srv_Tracking._ViewDiff_Data(L_Srv_SMO,L_ProjectInfo, P_TM_Message.Data);
            L_Srv_Tracking_DiffInfo.IsData = true;

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._ViewDiff(L_Srv_Tracking_DiffInfo)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }
    }
}
