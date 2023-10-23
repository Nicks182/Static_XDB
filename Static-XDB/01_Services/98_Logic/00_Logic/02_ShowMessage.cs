
using Services.DB;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {

        private string _Get_Show_Message(object P_Message)
        {
            TM_Message L_TM_Message = new TM_Message();
            L_TM_Message.Message_Type = TM_Message_Type.ShowMessage;

            L_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Message_Modal(P_Message.ToString())).ToString(),
                IsAppend = true,
            });

            return SH_ActionGen._ToJSON_String(L_TM_Message);
        }

    }
    
}
