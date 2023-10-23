using System.Text;
using Microsoft.SqlServer.Management.Smo;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private void _Tracking_View_Data(TM_Message P_TM_Message)
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


            _Tracking_View_Data(P_TM_Message, L_ProjectInfo.Id);

        }

        private void _Tracking_View_Data(TM_Message P_TM_Message, string P_ProjectId)
        {
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_ProjectId);
            //Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, L_ProjectInfo);
            //List<Table> L_Tables = L_Srv_SMO._Get_Table_Data();

            //List<Srv_Tracking_DiffInfo> L_Srv_Tracking_DiffInfos = new List<Srv_Tracking_DiffInfo>();
            //for (int i = 0; i < L_Tables.Count; i++)
            //{
            //    L_Srv_Tracking_DiffInfos.Add(G_Srv_Tracking._ViewDiff_Data(L_ProjectInfo, L_Tables[i].Name));
            //}

            _Tracking_View_Data(P_TM_Message, G_Srv_DB.Tracking_Data_GetAll().Find(td => td.Changed > 0).ToList());
        }
        private void _Tracking_View_Data(TM_Message P_TM_Message, List<DB.Tracking_Data> P_Tracking_Data)
        {
            
            StringBuilder L_Html = new StringBuilder();
            L_Html.Append(G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Tracking_Data(P_Tracking_Data)));

            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_Body.ToString(),
                HTML = L_Html.ToString(),
                IsAppend = false
            });
        }

    }
}
