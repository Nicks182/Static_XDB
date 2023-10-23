using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _IgnoredObjects_ChangeType(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "IgnoreType").FirstOrDefault();

            L_State_Control.Value = P_TM_Message.Data;

            _IgnoredObjects_Modify_Render(P_TM_Message, L_State_Item);

            //SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();


            //DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            //Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo);

            //DB.Ignore_Type L_Ignore_Type = (DB.Ignore_Type)Enum.Parse(typeof(DB.Ignore_Type), P_TM_Message.Data);

            //List<Srv_SMO_Object> L_Srv_SMO_Objects = L_Srv_SMO._Get_SMO_Objects(L_Ignore_Type);

            //_IgnoredObjects_Modify_Check(L_ProjectInfo, L_Srv_SMO_Objects, L_Ignore_Type);

            //_IgnoredObjects_Modify_GetState_Controls(L_State_Item, L_ProjectInfo.Id, L_Ignore_Type, L_Srv_SMO_Objects);

            //StringBuilder L_Html = new StringBuilder();
            //L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_IgnoredObjects_Edit(L_State_Item)));

            //P_TM_Message.HTMLs.Add(new TM_Message_Html
            //{
            //    ContainerId = HTML_Components_Names.Div_Body.ToString(),
            //    HTML = L_Html.ToString(),
            //    IsAppend = false
            //});

        }

        
    }
}
