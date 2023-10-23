using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _IgnoredObjects_Body(List<Services.DB.Ignore> P_Ignores)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_List");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_IgnoredObjects_Add_Btn());
            L_HTML_Object.Add_Child(_IgnoredObjects_Body_Header_Type());
            L_HTML_Object.Add_Child(_IgnoredObjects_Body_Header_Name());

            for (int i = 0; i < P_Ignores.Count; i++)
            {
                L_HTML_Object.Add_Child(_IgnoredObjects_Body_Edit(P_Ignores[i]));
                L_HTML_Object.Add_Child(_IgnoredObjects_Body_Type(P_Ignores[i]));
                L_HTML_Object.Add_Child(_IgnoredObjects_Body_Name(P_Ignores[i]));

            }


            return L_HTML_Object;
        }


        private HTML_Object _IgnoredObjects_Add_Btn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.edit,
                Icon_Pos = SH_Components_Info_Pos.Center,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Data = "Data",
                Message_Type = Services.TM_Message_Type.Ignores_Modify_Show
            }));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Body_Header_Type()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_Header_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder("Type"),
            });

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Body_Header_Name()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_Header_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder("Name"),
            });

            return L_HTML_Object;
        }


        private HTML_Object _IgnoredObjects_Body_Edit(Services.DB.Ignore P_Ignore)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_Item_Edit");

            L_HTML_Object.Add_Child(_IgnoredObjects_Body_Edit_Remove_Btn(P_Ignore));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Body_Edit_Remove_Btn(Services.DB.Ignore P_Ignore)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.delete_forever,
                Icon_Pos = SH_Components_Info_Pos.Center,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Ignores_Modify_Remove,
                Data = P_Ignore.Id.ToString()
            }));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Body_Type(Services.DB.Ignore P_Ignore)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_Item_Record");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_Ignore.Type.ToString())
            });

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Body_Name(Services.DB.Ignore P_Ignore)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Body_Items_Item_Record");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_Ignore.Name)
            });

            return L_HTML_Object;
        }

        


    }
}
