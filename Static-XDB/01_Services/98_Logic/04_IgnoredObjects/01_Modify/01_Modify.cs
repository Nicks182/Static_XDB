using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _IgnoredObjects_Modify(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "ProjectInfoId").FirstOrDefault();


            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

            Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo);

            DB.Ignore_Type L_Ignore_Type = (DB.Ignore_Type)Enum.Parse(typeof(DB.Ignore_Type), P_TM_Message.Data);

            //List<Srv_SMO_Object> L_Srv_SMO_Objects = L_Srv_SMO._Get_SMO_Objects(L_Ignore_Type);
            List<Srv_SMO_Object> L_Srv_SMO_Objects = L_Srv_SMO._Get_SMO_Objects();

            _IgnoredObjects_Modify_Check(L_ProjectInfo, L_Srv_SMO_Objects, L_Ignore_Type);

            SH_State_Item L_SH_FormState_Item = _IgnoredObjects_Modify_GetState(L_State_Item.Id, L_ProjectInfo.Id, L_Srv_SMO_Objects);

            _IgnoredObjects_Modify_Render(P_TM_Message, L_SH_FormState_Item);

            //StringBuilder L_Html = new StringBuilder();
            //L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_IgnoredObjects_Edit(L_SH_FormState_Item)));

            //P_TM_Message.HTMLs.Add(new TM_Message_Html
            //{
            //    ContainerId = HTML_Components_Names.Div_Body.ToString(),
            //    HTML = L_Html.ToString(),
            //    IsAppend = false
            //});
        }

        private void _IgnoredObjects_Modify_Render(TM_Message P_TM_Message, SH_State_Item P_State_Item)
        {
            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Get_IgnoredObjects_Edit(P_State_Item)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

        private void _IgnoredObjects_Modify_Check(DB.ProjectInfo P_ProjectInfo, List<Srv_SMO_Object> P_Srv_SMO_Object, DB.Ignore_Type P_Ignore_Type)
        {

            List<Services.DB.Ignore> L_Ignores = G_Srv_DB.Ignore_GetAll().Find(i => i.ProjectInfoId == P_ProjectInfo.Id).ToList();

            Srv_SMO_Object L_Srv_SMO_Object;
            foreach (var L_ignore in L_Ignores)
            {
                L_Srv_SMO_Object = P_Srv_SMO_Object.Where(o => o.Name == L_ignore.Name && o.IgnoreType == L_ignore.Type).FirstOrDefault();
                if(L_Srv_SMO_Object is not null)
                {
                    L_Srv_SMO_Object.IsIgnore = true;
                }
            }
        }

    }
}
