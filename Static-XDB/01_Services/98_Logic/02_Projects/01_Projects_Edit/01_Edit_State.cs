using System.Text;

using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        private SH_State_Item _Edit_Project_GetState(TM_Message P_TM_Message)
        {
            SH_State_Item L_SH_State_Item = new SH_State_Item();

            DB.ProjectInfo L_ProjectInfo = null;
            if (string.IsNullOrEmpty(P_TM_Message.Data) == false)
            {
                L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_TM_Message.Data);
            }
            else
            {
                L_ProjectInfo = new DB.ProjectInfo();
            }

            // Project DB Id (Null or empty will result in a new object when DB save is called)
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "ProjectInfoId",
                IsHidden = true,
                Value = P_TM_Message.Data,
            });

            // Project Folder
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_ProjectFolder",
                Caption = "Project Folder:",
                Value = L_ProjectInfo.ProjectFolder,
                Text = L_ProjectInfo.ProjectFolder,
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
                            Data = "Project_ProjectFolder",
                            Message_Type = Services.TM_Message_Type.FolderBrowser_Show,
                        })
                    }
                }
            });

            // Script Folder
            //L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            //{
            //    Id = "Project_ScriptFolder",
            //    Caption = "Script Folder Name:",
            //    Value = L_ProjectInfo.ScriptFolder,
            //    Text = L_ProjectInfo.ScriptFolder,

            //    Attributes = new List<HTML_Object_Attribute>
            //    {
            //        new HTML_Object_Attribute
            //        {
            //            Name = HTML_Attribute_Names.Class.ToString(),
            //            Value = new StringBuilder("Projects_Edit_Form_Body_Scripts")
            //        },

            //    },
            //    Events = new List<SH_State_Item_Control_Event>
            //    {
            //        new SH_State_Item_Control_Event
            //        {
            //            EventName = HTML_Attribute_Names.OnChange.ToString(),
            //            Event = HTML_Components._PushMessage_Event(new Services.TM_Message
            //            {
            //                UniqueId = L_SH_State_Item.Id,
            //                Data = "Project_ScriptFolder",
            //                Message_Type = Services.TM_Message_Type.ValueChange,
            //                Actions = new List<SH_Action>
            //                {
            //                    new SH_Action
            //                    {
            //                        Action_Type = SH_Action_Type.GetValue,
            //                        SourceId = "Project_ScriptFolder"
            //                    }
            //                }
            //            })
            //        }
            //    }
            //});
            //L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            //{
            //    Id = "Project_ScriptFolder",
            //    Caption = "Script Folder:",
            //    Value = L_ProjectInfo.ScriptFolder,
            //    Text = L_ProjectInfo.ScriptFolder,
            //    Components_Type = SH_Components_Types.FolderBrowser,
            //    Attributes = new List<HTML_Object_Attribute>
            //    {
            //        new HTML_Object_Attribute
            //        {
            //            Name = HTML_Attribute_Names.Class.ToString(),
            //            Value = new StringBuilder("Projects_Edit_Form_Body_Scripts")
            //        }
            //    },
            //    Events = new List<SH_State_Item_Control_Event>
            //    {
            //        new SH_State_Item_Control_Event
            //        {
            //            EventName = HTML_Attribute_Names.OnClick.ToString(),
            //            Event = HTML_Components._PushMessage_Event(new Services.TM_Message
            //            {
            //                UniqueId = L_SH_State_Item.Id,
            //                Data = "Project_ScriptFolder",
            //                Message_Type = Services.TM_Message_Type.FolderBrowser_Show,
            //            })
            //        }
            //    }
            //});

            // Name
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Name",
                Caption = "Name:",
                Value = L_ProjectInfo.Name,
                Text = L_ProjectInfo.Name,
                
                Attributes = new List<HTML_Object_Attribute>
                { 
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Name")
                    },

                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Name",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Name"
                                }
                            }
                        })
                    }
                }
            });

            // Sql Version
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_SQLVersion",
                Caption = "Target Sql Version:",
                Value = L_ProjectInfo.SQLVersion,
                Text = Srv_MSSQL._GetSQLVersion_Text(L_ProjectInfo.SQLVersion),
                Components_Type = SH_Components_Types.Dropdown,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Sqlversion")
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
                            Message_Type = Services.TM_Message_Type.Projects_Show_SQLVersions,
                        })
                    }
                }
            });

            // Server
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Server",
                Caption = "Server:",
                Value = L_ProjectInfo.Server,
                Text = L_ProjectInfo.Server,
                Components_Type = SH_Components_Types.Textbox,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Server")
                    }
                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Server",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Server"
                                }
                            }
                        })
                    }
                }
            });

            // Port
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Port",
                Caption = "Port:",
                Value = L_ProjectInfo.Port,
                Text = L_ProjectInfo.Port,
                Components_Type = SH_Components_Types.Textbox,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Port")
                    }
                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Port",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Port"
                                }
                            }
                        })
                    }
                }
            });

            // DBName
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_DBName",
                Caption = "DB Name:",
                Value = L_ProjectInfo.DBName,
                Text = L_ProjectInfo.DBName,
                Components_Type = SH_Components_Types.Textbox,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_DBName")
                    },

                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_DBName",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_DBName"
                                }
                            }
                        })
                    }
                }
            });

            // Username
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Username",
                Caption = "Username:",
                Value = L_ProjectInfo.Username,
                Text = L_ProjectInfo.Username,
                Components_Type = SH_Components_Types.Textbox,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Username")
                    }
                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Username",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Username"
                                }
                            }
                        })
                    }
                }
            });

            // Password
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Password",
                Caption = "Password:",
                Value = L_ProjectInfo.Password,
                Text = L_ProjectInfo.Password,
                Components_Type = SH_Components_Types.Textbox,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Password")
                    }
                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Password",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Password"
                                }
                            }
                        })
                    }
                }
            });

            // Use Intergrated Security
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Intergrated",
                Caption = "Intergrated:",
                Value = Convert.ToInt32(L_ProjectInfo.Integrated),
                Text = L_ProjectInfo.Integrated.ToString(),
                Components_Type = SH_Components_Types.Checkbox,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Intergrated")
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
                            Data = "Project_Intergrated",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Intergrated"
                                }
                            }
                        })
                    }
                }
            });

            // Trust Server Certificate
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Trust",
                Caption = "Trust Server:",
                Value = Convert.ToInt32(L_ProjectInfo.TrustServerCertificate),
                Text = L_ProjectInfo.TrustServerCertificate.ToString(),
                Components_Type = SH_Components_Types.Checkbox,
                CaptionPosition = SH_FormState_Item_Control_CaptionPosition.Left,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Trust")
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
                            Data = "Project_Trust",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Trust"
                                }
                            }
                        })
                    }
                }
            });

            // Description
            L_SH_State_Item.G_Controls.Add(new SH_State_Item_Control
            {
                Id = "Project_Description",
                Caption = "Description:",
                Value = L_ProjectInfo.Description,
                Text = L_ProjectInfo.Description,
                Components_Type = SH_Components_Types.Textarea,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Projects_Edit_Form_Body_Description")
                    },

                },
                Events = new List<SH_State_Item_Control_Event>
                {
                    new SH_State_Item_Control_Event
                    {
                        EventName = HTML_Attribute_Names.OnChange.ToString(),
                        Event = HTML_Components._PushMessage_Event(new Services.TM_Message
                        {
                            UniqueId = L_SH_State_Item.Id,
                            Data = "Project_Description",
                            Message_Type = Services.TM_Message_Type.ValueChange,
                            Actions = new List<SH_Action>
                            {
                                new SH_Action
                                {
                                    Action_Type = SH_Action_Type.GetValue,
                                    SourceId = "Project_Description"
                                }
                            }
                        })
                    }
                }
            });

            G_SH_State.Add(L_SH_State_Item);

            return L_SH_State_Item;
        }

        private HTML_Object_Attribute _Edit_Project_GetState_Get_Server_Click(string P_UniqueId)
        {
            HTML_Object_Attribute L_HTML_Object_Attribute = new HTML_Object_Attribute();

            L_HTML_Object_Attribute.Name = HTML_Attribute_Names.OnClick.ToString();
            L_HTML_Object_Attribute.Value = new StringBuilder(HTML_Components._PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_UniqueId,
                Message_Type = Services.TM_Message_Type.Projects_Show_Server,
            }));

            return L_HTML_Object_Attribute;
        }

        private HTML_Object_Attribute _Edit_Project_GetState_Get_SQLVersion_Click(string P_UniqueId)
        {
            HTML_Object_Attribute L_HTML_Object_Attribute = new HTML_Object_Attribute();

            L_HTML_Object_Attribute.Name = HTML_Attribute_Names.OnClick.ToString();
            L_HTML_Object_Attribute.Value = new StringBuilder(HTML_Components._PushMessage_Event(new Services.TM_Message
            {
                UniqueId = P_UniqueId,
                Message_Type = Services.TM_Message_Type.Projects_Show_SQLVersions,
            }));

            return L_HTML_Object_Attribute;
        }

    }
}
