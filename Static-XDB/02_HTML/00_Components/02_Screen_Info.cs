using System.Text;

using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Screen_Info(List<HTML_ScreenInfo_Item> P_Info_Items)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Info");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.HasBorder.ToString(), "1");

            for(int i = 0; i < P_Info_Items.Count; i++)
            {
                L_HTML_Object.Add_Child(_Screen_Info_Item(P_Info_Items[i]));
            }

            return L_HTML_Object;
        }


        private HTML_Object _Screen_Info_Item(HTML_ScreenInfo_Item P_HTML_ScreenInfo_Item)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Screen_Info_Item");

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsLabel,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Screen_Info_Item_Caption")
                    }
                },
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_HTML_ScreenInfo_Item.Caption)
                    }
                }
            });


            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsLabel,
                Attributes = new List<HTML_Object_Attribute>
                {
                    new HTML_Object_Attribute
                    {
                        Name = HTML_Attribute_Names.Class.ToString(),
                        Value = new StringBuilder("Screen_Info_Item_Description")
                    }
                },
                Children = new List<HTML_Object>
                {
                    new HTML_Object
                    {
                        Type = HTML_Object_Type.IsRaw,
                        RawValue = new StringBuilder(P_HTML_ScreenInfo_Item.Description)
                    }
                }
            });


            return L_HTML_Object;
        }

    }

    public class HTML_ScreenInfo
    {
        public List<HTML_ScreenInfo_Item> Items { get; set; } = new List<HTML_ScreenInfo_Item>();
    }

    public class HTML_ScreenInfo_Item
    {
        public string Caption { get; set; }
        public string Description { get; set; }
    }
}
