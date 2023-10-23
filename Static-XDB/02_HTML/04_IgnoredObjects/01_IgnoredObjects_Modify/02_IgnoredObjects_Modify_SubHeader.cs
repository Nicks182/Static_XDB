using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _IgnoredObjects_Edit_SubHeader(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_SubHeader");

            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns());
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Text(P_SH_State_Item));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_SubHeader_Btns()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_SubHeader_Btns");

            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Data, "Table Data"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Schema, "Schemas"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.User, "Users"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Table, "Tables"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.View, "Views"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Proc, "Procedures"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Func, "Functions"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Trig, "Triggers"));
            L_HTML_Object.Add_Child(_IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type.Syn, "Synonyms"));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_SubHeader_Btns_Button(Services.DB.Ignore_Type P_Type, string P_Caption)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = P_Caption,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Data = P_Type.ToString(),
                Message_Type = Services.TM_Message_Type.Ignores_Modify_ChangeType
            }));

            return L_HTML_Object;
        }

        private HTML_Object _IgnoredObjects_Edit_SubHeader_Text(SH_State_Item P_SH_State_Item)
        {
            SH_State_Item_Control L_State_Control = P_SH_State_Item.G_Controls.Where(c => c.Id == "IgnoreType_Text").FirstOrDefault();

            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "IgnoredObjects_Edit_SubHeader_Text");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(L_State_Control.Value.ToString())
            });

            return L_HTML_Object;
        }



    }
}
