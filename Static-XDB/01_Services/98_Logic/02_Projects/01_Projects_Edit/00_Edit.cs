using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _Projects_Edit(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_FormState_Item = _Edit_Project_GetState(P_TM_Message);

            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Projects_Edit(L_SH_FormState_Item)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

    }
}
