using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Main_Body_DBInfo(SH_State_Item P_SH_State_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), HTML_Components_Names.Div_ProjectInfo.ToString());
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Main_Body_Section_Header("Database Info:"));

            foreach (var L_Item in P_SH_State_Item.G_Controls.Where(c => c.Id.Contains("Main_DBInfo_")).ToList())
            {
                //L_HTML_Object.Add_Child(G_SH_Components._Form_Item(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_DBInfo_Item_Caption(L_Item));
                L_HTML_Object.Add_Child(_Main_Body_DBInfo_Item_Control(L_Item));
            }

            L_HTML_Object.Add_Child(_Main_Body_DBInfo_Item_ViewChanges());

            return L_HTML_Object;
        }

        

        private HTML_Object _Main_Body_DBInfo_Item_Caption(SH_State_Item_Control P_SH_State_Item_Control)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_Section_Item_Caption");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_SH_State_Item_Control.Caption)
            });

            return L_HTML_Object;
        }

        private HTML_Object _Main_Body_DBInfo_Item_Control(SH_State_Item_Control P_SH_State_Item_Control)
        {
            return G_SH_Components._Form_Item_Input(P_SH_State_Item_Control);
        }

        private HTML_Object _Main_Body_DBInfo_Item_ViewChanges()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Main_Body_DBInfo_ViewChanges");

            L_HTML_Object.Add_Child(_Main_Body_DBInfo_Item_ViewChanges_Object());
            L_HTML_Object.Add_Child(_Main_Body_DBInfo_Item_ViewChanges_Data());
            L_HTML_Object.Add_Child(_Main_Body_DBInfo_Ignore());

            return L_HTML_Object;
        }

        private HTML_Object _Main_Body_DBInfo_Item_ViewChanges_Object()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "View Object Changes",
                Text_Align = SH_Components_Info_Pos.Center,
                Icon = SH_Components_IconTypes.compare_arrows,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), HTML_Components._PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Tracking_View_Objects,
            }));



            return L_HTML_Object;
        }

        private HTML_Object _Main_Body_DBInfo_Item_ViewChanges_Data()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "View Data Changes",
                Text_Align = SH_Components_Info_Pos.Center,
                Icon = SH_Components_IconTypes.difference,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), HTML_Components._PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Tracking_View_Data,
            }));



            return L_HTML_Object;
        }

        private HTML_Object _Main_Body_DBInfo_Ignore()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Ignore...",
                Text_Align = SH_Components_Info_Pos.Center,
                Icon = SH_Components_IconTypes.block,
                Icon_Pos = SH_Components_Info_Pos.Left,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.Ignores_Show,
                Data = "Schema", // Show Schema items by default.
            }));

            return L_HTML_Object;
        }

    }
}
