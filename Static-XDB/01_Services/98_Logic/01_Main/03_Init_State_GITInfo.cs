
using Services.DB;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        private List<SH_State_Item_Control> _Init_Get_MainState_GITInfo(DB.ProjectInfo P_ProjectInfo)
        {
            List<SH_State_Item_Control> L_SH_State_Item_Controls = new List<SH_State_Item_Control>();

            

            L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            {
                Id = "Main_GitInfo_Branch",
                Caption = "Branch: ",
                Value = "Unkown",
                Text = "Unkown",
                Components_Type = SH_Components_Types.PlainText,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left
            });

            L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            {
                Id = "Main_GitInfo_Committer",
                Caption = "Committer:",
                Value = "Unkown",
                Text = "Unkown",
                Components_Type = SH_Components_Types.PlainText,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left
            });

            //L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            //{
            //    Id = "Main_GitInfo_DBBranch",
            //    Caption = "DB Branch: ",
            //    Value = "Unkown",
            //    Text = "Unkown",
            //    Components_Type = SH_Components_Types.PlainText,
            //    CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left
            //});

            L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            {
                Id = "Main_GitInfo_LastCommitMsg",
                Caption = "Last Commit Msg:",
                Value = "Unkown",
                Text = "Unkown",
                Components_Type = SH_Components_Types.PlainText,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left
            });

            L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            {
                Id = "Main_GitInfo_LastCommit",
                Caption = "Last Commit:",
                Value = "Unkown",
                Text = "Unkown",
                Components_Type = SH_Components_Types.PlainText,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left
            });

            L_SH_State_Item_Controls.Add(new SH_State_Item_Control
            {
                Id = "Main_GitInfo_Remote",
                Caption = "Remote:",
                Value = "Unkown",
                Text = "Unkown",
                Components_Type = SH_Components_Types.Button,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left,
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnClick.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            Data = P_ProjectInfo is null ? "" : P_ProjectInfo.Id,
                            Message_Type = Services.TM_Message_Type.Launch_Remote,
                        })
                    }
                }
            });

            L_SH_State_Item_Controls.Add(_Init_Get_MainState_GITInfo_Folder(P_ProjectInfo));
            L_SH_State_Item_Controls.Add(_Init_Get_MainState_GITInfo_ScriptsFolder(P_ProjectInfo));

            return L_SH_State_Item_Controls;
        }

        private SH_State_Item_Control _Init_Get_MainState_GITInfo_Folder(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_GitInfo_GITFolder";
            L_SH_State_Item_Control.Caption = "Project Folder:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.Button;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.ProjectFolder) == false)
            {
                L_SH_State_Item_Control.Value = P_ProjectInfo.ProjectFolder;
                L_SH_State_Item_Control.Text = P_ProjectInfo.ProjectFolder;
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            L_SH_State_Item_Control.Events = new List<SH_State_Item_Control_Event>
            {
                new SH_State_Item_Control_Event
                {
                    EventName = HTML_Attribute_Names.OnClick.ToString(),
                    Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                    {
                        Data = P_ProjectInfo is null ? "" : P_ProjectInfo.Id,
                        Message_Type = Services.TM_Message_Type.Launch_ProjectFolder,
                    })
                }
            };

            return L_SH_State_Item_Control;
        }

        private SH_State_Item_Control _Init_Get_MainState_GITInfo_ScriptsFolder(DB.ProjectInfo P_ProjectInfo)
        {
            SH_State_Item_Control L_SH_State_Item_Control = new SH_State_Item_Control();
            L_SH_State_Item_Control.Id = "Main_GitInfo_ScriptFolder";
            L_SH_State_Item_Control.Caption = "Script Folder:";
            L_SH_State_Item_Control.Components_Type = SH_Components_Types.Button;
            L_SH_State_Item_Control.CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left;
            
            if (P_ProjectInfo is not null && string.IsNullOrEmpty(P_ProjectInfo.ProjectFolder) == false)
            {
                L_SH_State_Item_Control.Value = Srv_ScriptsFolder._Get(P_ProjectInfo);
                L_SH_State_Item_Control.Text = Srv_ScriptsFolder._Get(P_ProjectInfo);
            }
            else
            {
                L_SH_State_Item_Control.Value = "...";
                L_SH_State_Item_Control.Text = "...";
            }

            L_SH_State_Item_Control.Events = new List<SH_State_Item_Control_Event>
            {
                new SH_State_Item_Control_Event
                {
                    EventName = HTML_Attribute_Names.OnClick.ToString(),
                    Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                    {
                        Data = P_ProjectInfo is null ? "" : P_ProjectInfo.Id,
                        Message_Type = Services.TM_Message_Type.Launch_ScriptFolder,
                    })
                }
            };

            return L_SH_State_Item_Control;
        }


    }
}
