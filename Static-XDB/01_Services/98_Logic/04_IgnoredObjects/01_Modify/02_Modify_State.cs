
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public SH_State_Item _IgnoredObjects_Modify_GetState(string P_ParentId, string P_ProjectInfo_Id, List<Srv_SMO_Object> P_Srv_SMO_Objects)
        {

            SH_State_Item L_SH_FormState_Item = new SH_State_Item();
            L_SH_FormState_Item.ParentId = P_ParentId;

            _IgnoredObjects_Modify_GetState_Controls(L_SH_FormState_Item, P_ProjectInfo_Id, DB.Ignore_Type.Data, P_Srv_SMO_Objects);

            G_SH_State.Add(L_SH_FormState_Item);

            return L_SH_FormState_Item;


        }

        private string _IgnoredObjects_Modify_GetState_Controls_GetId(string P_Name, DB.Ignore_Type P_Ignore_Type)
        {
            if(P_Ignore_Type == DB.Ignore_Type.Data)
            {
                return P_Name + "_Data";
            }

            return P_Name;
        }

        private void _IgnoredObjects_Modify_GetState_Controls(SH_State_Item P_SH_FormState_Item, string P_ProjectInfo_Id, DB.Ignore_Type P_Ignore_Type, List<Srv_SMO_Object> P_Srv_SMO_Objects)
        {
            P_SH_FormState_Item.G_Controls.Clear();

            P_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ProjectInfoId",
                IsHidden = true,
                Value = P_ProjectInfo_Id,
            });

            P_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "IgnoreType",
                IsHidden = true,
                Value = P_Ignore_Type.ToString(),
            });

            P_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "IgnoreType_Text",
                Value = _IgnoredObjects_Modify_GetState_Controls_IgnoreType_Text(P_Ignore_Type),
                Components_Type = SH_Components_Types.PlainText,
            });

            foreach (Srv_SMO_Object L_Object in P_Srv_SMO_Objects)
            {
                P_SH_FormState_Item.G_Controls.Add(new SH_State_Item_Control
                {
                    Id = "Check_" + _IgnoredObjects_Modify_GetState_Controls_GetId(L_Object.Name, L_Object.IgnoreType),
                    Caption = L_Object.Name,
                    Value = Convert.ToInt32(L_Object.IsIgnore),
                    Text = L_Object.IsIgnore.ToString(),
                    Components_Type = SH_Components_Types.Checkbox,
                    CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Right,
                    MetaData = new Dictionary<string, object>
                    {
                        { "Name", L_Object.Name},
                        { "IgnoreType", L_Object.IgnoreType},
                    },
                    Events = new List<SH_State_Item_Control_Event>
                    {
                        new SH_State_Item_Control_Event
                        {
                            EventName = HTML_Attribute_Names.OnClick.ToString(),
                            Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                            {
                                UniqueId = P_SH_FormState_Item.Id,
                                Data = "Check_" + _IgnoredObjects_Modify_GetState_Controls_GetId(L_Object.Name, L_Object.IgnoreType),
                                Message_Type = Services.TM_Message_Type.ValueChange,
                                Actions = new List<SH_Action>
                                {
                                    new SH_Action
                                    {
                                        Action_Type = SH_Action_Type.GetValue,
                                        SourceId = "Check_" + _IgnoredObjects_Modify_GetState_Controls_GetId(L_Object.Name, L_Object.IgnoreType)
                                    }
                                }
                            })
                        }
                    }
                });
            }
        }

        private string _IgnoredObjects_Modify_GetState_Controls_IgnoreType_Text(DB.Ignore_Type P_Ignore_Type)
        {
            switch (P_Ignore_Type)
            {
                case DB.Ignore_Type.Schema:
                    return "Viewing: Schemas";

                case DB.Ignore_Type.User:
                    return "Viewing: Users";

                case DB.Ignore_Type.Table:
                    return "Viewing: Tables";

                case DB.Ignore_Type.View:
                    return "Viewing: Views";

                case DB.Ignore_Type.Proc:
                    return "Viewing: Procedures";

                case DB.Ignore_Type.Func:
                    return "Viewing: Functions";

                case DB.Ignore_Type.Trig:
                    return "Viewing: Triggers";

                case DB.Ignore_Type.Syn:
                    return "Viewing: Synonyms";

                default:
                    return "Viewing: Table Data";
            }


        }
    }

    
}
