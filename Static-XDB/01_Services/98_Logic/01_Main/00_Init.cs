using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Init(TM_Message P_TM_Message)
        {
            StringBuilder L_Html = new StringBuilder();
            SH_State_Item L_SH_State_Item = _Init_Get_MainState(P_TM_Message);

            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Main(L_SH_State_Item)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_BusyHolder.ToString(),
                HTML = G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_Busy()).ToString(),
                IsAppend = false
            });
        }



    }
}
