using System.Text;
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        private HTML_Object _Tracking_Data_Body(List<Services.DB.Tracking_Data> P_Tracking_Datas)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Body");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid(P_Tracking_Datas));

            

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_Body_Grid(List<Services.DB.Tracking_Data> P_Tracking_Datas)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Data_Body_Grid");

            L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_Header("Compare"));
            L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_Header("Name"));
            L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_Header("Changes"));
            

            foreach (Services.DB.Tracking_Data L_Item in P_Tracking_Datas)
            {
                L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_ViewDiff(L_Item));
                L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_Cell(L_Item.TableName));
                L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_Cell(L_Item.Changed.ToString()));
                
                
                
            }

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_Body_Grid_ViewDiff(Services.DB.Tracking_Data P_Tracking_Data)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Data_Body_Grid_Cell");

            L_HTML_Object.Add_Child(_Tracking_Data_Body_Grid_ViewDiff_Btn(P_Tracking_Data));

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_Body_Grid_ViewDiff_Btn(Services.DB.Tracking_Data P_Tracking_Data)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.compare_arrows,
                Icon_Pos = SH_Components_Info_Pos.Center
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Data = P_Tracking_Data.TableName,
                Message_Type = Services.TM_Message_Type.Tracking_View_Diff_Data
            }));

            return L_HTML_Object;
        }

        private HTML_Object _Tracking_Data_Body_Grid_Header(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Data_Body_Grid_Cell");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Data_Body_Grid_Header");

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

        private HTML_Object _Tracking_Data_Body_Grid_Cell(string P_Text)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Tracking_Data_Body_Grid_Cell");

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
