using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Projects_Body(List<Services.DB.ProjectInfo> P_ProjectInfos)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            //L_HTML_Object.Add_Child(_Projects_Add_Btn());
            L_HTML_Object.Add_Child(new HTML_Object { Type = HTML_Object_Type.IsDiv });
            L_HTML_Object.Add_Child(_Projects_Body_Header_Name());
            L_HTML_Object.Add_Child(_Projects_Body_Header_Description());

            for (int i = 0; i < P_ProjectInfos.Count; i++)
            {
                L_HTML_Object.Add_Child(_Projects_Body_Edit(P_ProjectInfos[i]));
                L_HTML_Object.Add_Child(_Projects_Body_Name(P_ProjectInfos[i]));
                L_HTML_Object.Add_Child(_Projects_Body_Description(P_ProjectInfos[i]));
                
            }


            return L_HTML_Object;
        }


        //private HTML_Object _Projects_Add_Btn()
        //{
        //    HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
        //    {
        //        Icon = SH_Components_IconTypes.add,
        //        Icon_Pos = SH_Components_Info_Pos.Center,
        //        IsFlat = 0,
        //    });

        //    L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
        //    {
        //        Message_Type = Services.TM_Message_Type.Projects_Edit
        //    }));

        //    return L_HTML_Object;
        //}

        private HTML_Object _Projects_Body_Header_Name()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body_Header_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder("Name"),
            });

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Header_Description()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body_Header_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder("Description"),
            });

            return L_HTML_Object;
        }


        private HTML_Object _Projects_Body_Edit(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body_Item_Edit");

            L_HTML_Object.Add_Child(_Projects_Body_Edit_Update_Btn(P_ProjectInfo));
            L_HTML_Object.Add_Child(_Projects_Body_Edit_Export_Btn(P_ProjectInfo));
            L_HTML_Object.Add_Child(_Projects_Body_Edit_Remove_Btn(P_ProjectInfo));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Edit_Update_Btn(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.edit,
                Icon_Pos = SH_Components_Info_Pos.Center,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Edit,
                Data = P_ProjectInfo.Id.ToString()
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Edit_Export_Btn(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.publish,
                Icon_Pos = SH_Components_Info_Pos.Center,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Export,
                Data = P_ProjectInfo.Id.ToString()
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Edit_Remove_Btn(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.delete_forever,
                Icon_Pos = SH_Components_Info_Pos.Center,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Projects_Edit_Remove,
                Data = P_ProjectInfo.Id.ToString()
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Name(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body_Item_Record");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_ProjectInfo.Name)
            });

            return L_HTML_Object;
        }

        private HTML_Object _Projects_Body_Description(Services.DB.ProjectInfo P_ProjectInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Projects_Body_Item_Record");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_ProjectInfo.Description)
            });

            return L_HTML_Object;
        }


    }
}
