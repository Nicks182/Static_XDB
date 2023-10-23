using System.Text;

using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Form_Item(SH_State_Item_Control P_SH_FormState_Item_Control)
        {
            HTML_Object L_Item = 
            _Form_Item(
                _Form_Item_Caption(P_SH_FormState_Item_Control),
                _Form_Item_Input(P_SH_FormState_Item_Control)
                );

            L_Item.Add_Attribute(HTML_Attribute_Names.CapPos.ToString(), ((int)P_SH_FormState_Item_Control.CaptionPosition).ToString());

            for (int i = 0; i < P_SH_FormState_Item_Control.Attributes.Count; i++)
            {
                L_Item.Add_Attribute(P_SH_FormState_Item_Control.Attributes[i].Name, P_SH_FormState_Item_Control.Attributes[i].Value.ToString());
            }

            return L_Item;
        }

        public HTML_Object _Form_Item(HTML_Object P_Caption, HTML_Object P_Input)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.CompType.ToString(), "71");
            

            P_Caption.Add_Attribute("FormCaption", "1");
            P_Input.Add_Attribute("FormInput", "1");

            //if (_Form_Item_IsCheckbox(P_Input) == true)
            //{
            //    L_HTML_Object.Add_Attribute("IsCheck", "1");

            //    L_HTML_Object.Add_Child(P_Input);
            //    L_HTML_Object.Add_Child(P_Caption);
            //}
            //else
            //{
            //    L_HTML_Object.Add_Child(P_Caption);
            //    L_HTML_Object.Add_Child(P_Input);
            //}

            L_HTML_Object.Add_Child(P_Caption);
            L_HTML_Object.Add_Child(P_Input);

            return L_HTML_Object;
        }

        //public HTML_Object _Form_Item_Legend(HTML_Object P_Caption)
        //{
        //    HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

        //    L_HTML_Object.Add_Child(P_Caption);

        //    return L_HTML_Object;
        //}


        private bool _Form_Item_IsCheckbox(HTML_Object P_Input)
        {
            if(P_Input.Attributes.Where(a => a.Name == "CompType" && a.Value.ToString() == "2").Count() > 0)
            {
                return true;
            }

            return false;
        }

        private HTML_Object _Form_Item_Caption(SH_State_Item_Control P_SH_FormState_Item_Control)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Attribute("Title", P_SH_FormState_Item_Control.Caption);

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new StringBuilder(P_SH_FormState_Item_Control.Caption)
            });

            return L_HTML_Object;
        }

        public HTML_Object _Form_Item_Input(SH_State_Item_Control P_SH_FormState_Item_Control)
        {
            HTML_Object L_HTML_Object = null;

            if(P_SH_FormState_Item_Control.Value is null)
            {
                P_SH_FormState_Item_Control.Value = "";
            }

            switch (P_SH_FormState_Item_Control.Components_Type)
            {
                case SH_Components_Types.Checkbox:
                    L_HTML_Object = _Checkbox(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = Convert.ToInt32(P_SH_FormState_Item_Control.Value).ToString(),
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;

                case SH_Components_Types.Button:
                    L_HTML_Object = _Button(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Caption = P_SH_FormState_Item_Control.Value.ToString(),
                        Value = P_SH_FormState_Item_Control.Value.ToString(),
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                        Text_Align = SH_Components_Info_Pos.Left,
                    });
                    break;

                case SH_Components_Types.Textarea:
                    L_HTML_Object = _Textarea(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = P_SH_FormState_Item_Control.Text,
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;

                case SH_Components_Types.Dropdown:
                    L_HTML_Object = _Dropdown(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = P_SH_FormState_Item_Control.Text,
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;

                case SH_Components_Types.FolderBrowser:
                    L_HTML_Object = _FolderBrowser(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = P_SH_FormState_Item_Control.Value.ToString(),
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;

                case SH_Components_Types.PlainText:
                    L_HTML_Object = _PlainText(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = P_SH_FormState_Item_Control.Value.ToString(),
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;

                default:
                    L_HTML_Object = _Textbox(new SH_Components_Info
                    {
                        Id = P_SH_FormState_Item_Control.Id,
                        Value = P_SH_FormState_Item_Control.Text,
                        IsFocus = P_SH_FormState_Item_Control.IsFocus,
                    });
                    break;
            }

            for(int i = 0; i < P_SH_FormState_Item_Control.Events.Count; i++)
            {
                L_HTML_Object.Add_Attribute(P_SH_FormState_Item_Control.Events[i].EventName, P_SH_FormState_Item_Control.Events[i].Event);
            }

            return L_HTML_Object;
        }

    }

}
