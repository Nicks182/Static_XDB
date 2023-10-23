using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Body(Services.DB.Tracking P_Tracking, List<Services.DB.Tracking_Object> P_Tracking_Objects)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Tracking_Body_Grid(P_Tracking_Objects));

            

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Body_Grid(List<Services.DB.Tracking_Object> P_Tracking_Objects)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid");

            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Compare"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Name"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Changes"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Removed"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("TypeDesc"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("CreatedOn"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("LastChanged"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Id"));
            L_HTML_Object.Add_Child(_Tracking_Body_Grid_Header("Type"));
            

            foreach (var L_Item in P_Tracking_Objects)
            {
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_ViewDiff(L_Item));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.ObjectName));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.Changed.ToString()));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.IsRemoved.ToString()));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.ObjectTypeDesc));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.CreatedOn));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.LastChanged));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.ObjectId));
                L_HTML_Object.Add_Child(_Tracking_Body_Grid_Cell(L_Item.ObjectType));
                
                
                
            }

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Body_Grid_ViewDiff(Services.DB.Tracking_Object P_Tracking_Object)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Cell");

            L_HTML_Object.Add_Child(_Tracking_Body_Grid_ViewDiff_Btn(P_Tracking_Object));

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Body_Grid_ViewDiff_Btn(Services.DB.Tracking_Object P_Tracking_Object)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.compare_arrows,
                Icon_Pos = SH_Components_Info_Pos.Center
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Data = P_Tracking_Object.Id,
                Message_Type = Services.TM_Message_Type.Tracking_View_Diff
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Body_Grid_Header(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Cell");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Header");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsDiv,
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_Text)
                    }
                }
            });

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Body_Grid_Cell(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body_Grid_Cell");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsDiv,
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_Text)
                    }
                }
            });

            return L_HTML_Object;
        }

    }
}
