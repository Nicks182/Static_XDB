using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        private SH_State_Item _Project_Import_GetState(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_State_Item = new SH_State_Item();


            // Project Folder
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Import_ProjectFolder",
                Caption = "Project Folder:",
                Value = "",
                Text = "",
                IsFocus = true,
                Components_Type = SH_Components_Types.FolderBrowser,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Project")
                    }
                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnClick.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Import_ProjectFolder",
                            Message_Type = Services.TM_Message_Type.FolderBrowser_Show,
                        })
                    }
                }
            });

            // Project Folder
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Import_ProjectLoad",
                Caption = "",
                Value = "View info...",
                Text = "View info...",
                IsFocus = false,
                Components_Type = SH_Components_Types.Button,
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnClick.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Message_Type = Services.TM_Message_Type.Projects_Import_Load,
                        })
                    }
                }
            });

            G_SH_State.Add(L_SH_State_Item);

            return L_SH_State_Item;
        }

        

    }
}
