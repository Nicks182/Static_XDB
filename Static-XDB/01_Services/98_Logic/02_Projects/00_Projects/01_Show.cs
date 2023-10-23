using System.Text;

using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Projects_Show(TM_Message P_TM_Message)
        {
            List<DB.ProjectInfo> L_ProjectInfos = G_Srv_DB.ProjectInfo_GetAll().FindAll().ToList();

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Projects(L_ProjectInfos)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

    }
}
