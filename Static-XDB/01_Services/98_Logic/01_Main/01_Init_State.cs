
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private SH_State_Item _Init_Get_MainState(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_FormState_Item = new SH_State_Item();

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_GetAll().FindAll().OrderBy(p => p.Name).FirstOrDefault();

            //G_Srv_Tracking._Init_DB_Objects(L_ProjectInfo);

            L_SH_FormState_Item.G_Controls.Add(_Init_Get_MainState_Project_Id(L_SH_FormState_Item, L_ProjectInfo));
            L_SH_FormState_Item.G_Controls.Add(_Init_Get_MainState_Project_Description(L_ProjectInfo));

            L_SH_FormState_Item.G_Controls.AddRange(_Init_Get_MainState_DBInfo(L_ProjectInfo));
            L_SH_FormState_Item.G_Controls.AddRange(_Init_Get_MainState_GITInfo(L_ProjectInfo));

            G_SH_State.Add(L_SH_FormState_Item);

            G_Srv_ProjectStatus._CheckProjectStatus_Start(L_ProjectInfo);

            return L_SH_FormState_Item;
        }

        private SH_State_Item_Control _Init_Get_MainState_Project_Id(SH_State_Item P_SH_FormState_Item, DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_Project_Id";
            L_SH_State_Item_Control.Caption = "Select Project:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.Dropdown;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Top;
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Name) == false)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.Id;
                L_SH_State_Item_Control.Text = P_ProjectInfo.Name;
            }
            else
            {
                L_SH_State_Item_Control.Value = null;
                L_SH_State_Item_Control.Text = "...";
            }

            L_SH_State_Item_Control.Events = new List<SH_State_Item_Control_Event>
            {
                new SH_State_Item_Control_Event
                {
                    EventName = HTML_Attribute_Names.OnClick.ToString(),
                    Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                    {
                        UniqueId = P_SH_FormState_Item.Id,
                        Message_Type = Services.TM_Message_Type.Main_Project_Select_Show,
                    })
                }
            };

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_Project_Description(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_Project_Description";
            L_SH_State_Item_Control.Caption = "Description:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.PlainText;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Top;
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.Description) == false)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.Description;
                L_SH_State_Item_Control.Text = P_ProjectInfo.Description;
            }
            else
            {
                L_SH_State_Item_Control.Value = null;
                L_SH_State_Item_Control.Text = "...";
            }

            return L_SH_State_Item_Control;
        }

    }
}
