
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public void _Main_Project_Select_Show(TM_Message P_TM_Message)
        {
            List<DB.ProjectInfo> L_ProjectInfos = G_Srv_DB.ProjectInfo_GetAll().FindAll().OrderBy(p => p.Name).ToList();

            P_TM_Message.Message_Type = TM_Message_Type.DoNothing;
            P_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Main_Project_Select_Modal(L_ProjectInfos)).ToString(),
                IsAppend = true
            });
        }

        public void _Main_Project_Select_Set(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == "Main_Project_Id").FirstOrDefault();

            if (L_State_Control is not null && L_State_Control.Value is not null)
            {
                L_State_Control.Value = P_TM_Message.Data;

                DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_State_Control.Value.ToString());

                if (L_ProjectInfo is not null)
                {
                    P_TM_Message.Actions = new List<SH_Action>
                    {
                        new SH_Action
                        {
                            Action_Type = SH_Action_Type.SetValue,
                            SourceId = "Main_Project_Id",
                            Value = L_ProjectInfo.Name
                        },
                        new SH_Action
                        {
                            Action_Type = SH_Action_Type.SetValue,
                            SourceId = "Main_Project_Description",
                            Value = L_ProjectInfo.Description
                        }
                    };

                    G_Srv_ProjectStatus._CheckProjectStatus_Start(L_ProjectInfo);
                }

                

            }
        }


    }
}
