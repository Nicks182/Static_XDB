
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _FolderBrowser_Modal(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "FolderBrowser_Modal",
                Caption = "Choose: Folder",
                Content_Body = _FolderBrowser_Body(P_Srv_DriveBrowser),
                Content_Footer = _FolderBrowser_Footer(),
            });

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), "Div_FolderBrowser_Modal_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Body");

            L_HTML_Object.Add_Child(_FolderBrowser_Body_CurrentPath(P_Srv_DriveBrowser));
            L_HTML_Object.Add_Child(_FolderBrowser_Body_Content(P_Srv_DriveBrowser));

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body_CurrentPath(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Body_CurrentPath");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder("Location: " + P_Srv_DriveBrowser.GetCurrentLocation().FullPath)
            });

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body_Content(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Body_Content");

            L_HTML_Object.Add_Child(_FolderBrowser_Body_Content_GoUp(P_Srv_DriveBrowser));
            L_HTML_Object.Add_Child(_FolderBrowser_Body_Content_Items(P_Srv_DriveBrowser));

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body_Content_GoUp(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Up",
                Icon = SH_Components_IconTypes.drive_folder_upload,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Body_Content_GoUp");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.FolderBrowser_GoUp,
            }));

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body_Content_Items(Srv_DriveBrowser P_Srv_DriveBrowser)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Body_Content_Items");

            foreach(var L_Item in P_Srv_DriveBrowser.GetItems())
            {
                L_HTML_Object.Add_Child(_FolderBrowser_Body_Content_Items(L_Item));
            }

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_Body_Content_Items(Srv_DriveBrowser_ItemInfo P_Srv_DriveBrowser_ItemInfo)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = P_Srv_DriveBrowser_ItemInfo.Name,
                Text_Align = SH_Components_Info_Pos.Left,
                Icon = SH_Components_IconTypes.drive_file_move,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.FolderBrowser_GoTo,
                Data = P_Srv_DriveBrowser_ItemInfo.FullPath,
            }));

            return L_HTML_Object;
        }


        public HTML_Object _FolderBrowser_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Footer");

            L_HTML_Object.Add_Child(_FolderBrowser_CancelBtn());
            L_HTML_Object.Add_Child(_FolderBrowser_SelectBtn());

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_CancelBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.arrow_back_ios_new,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Footer_CancelBtn");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.FolderBrowser_Cancel,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "FolderBrowser_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

        public HTML_Object _FolderBrowser_SelectBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Select",
                Icon = SH_Components_IconTypes.arrow_forward_ios,
                Icon_Pos = SH_Components_Info_Pos.Right,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "FolderBrowser_Modal_Footer_SelectBtn");

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.FolderBrowser_Select,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "FolderBrowser_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }


    }

}
