using Static_XDB.HTML;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Modal(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            if(string.IsNullOrEmpty(P_ModalInfo.Id) == false)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), P_ModalInfo.Id);
            }

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.IsHidden.ToString(), Convert.ToInt32(P_ModalInfo.IsHidden).ToString());

            L_HTML_Object.Add_Child(_Modal_Mask(P_ModalInfo));
            L_HTML_Object.Add_Child(_Modal_Content(P_ModalInfo));

            return L_HTML_Object;
        }

        public HTML_Object _Modal_Mask(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal_Mask");

            if (P_ModalInfo.CanCloseOnMask == true)
            {
                L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), "_Modal_ShowHide('" + P_ModalInfo.Id + "')");
            }

            return L_HTML_Object;
        }

        public HTML_Object _Modal_Content(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal_Content");

            L_HTML_Object.Add_Child(_Modal_Content_Header(P_ModalInfo));
            L_HTML_Object.Add_Child(_Modal_Content_Body(P_ModalInfo));
            L_HTML_Object.Add_Child(_Modal_Content_Footer(P_ModalInfo));

            return L_HTML_Object;
        }

        #region Header
        public HTML_Object _Modal_Content_Header(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal_Content_Header");

            if(P_ModalInfo.Content_Header is not null)
            {
                L_HTML_Object.Add_Child(P_ModalInfo.Content_Header);
            }
            else
            {
                L_HTML_Object.Add_Child(_Modal_Content_Header_Caption(P_ModalInfo));
                if (P_ModalInfo.HasCloseBtn == true)
                {
                    L_HTML_Object.Add_Child(_Modal_Content_Header_CloseBtn(P_ModalInfo));
                }
            }

            return L_HTML_Object;
        }

        private HTML_Object _Modal_Content_Header_Caption(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsLabel };

            L_HTML_Object.Add_Child(new HTML_Object
            {
                Type = HTML_Object_Type.IsRaw,
                RawValue = new System.Text.StringBuilder(P_ModalInfo.Caption)
            });

            return L_HTML_Object;
        }

        private HTML_Object _Modal_Content_Header_CloseBtn(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = _Button(new SH_Components_Info
            {
                Icon = SH_Components_IconTypes.close,
                Icon_Pos = SH_Components_Info_Pos.Center,
                IsFlat = 1
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _Modal_Close_Event(P_ModalInfo));

            return L_HTML_Object;
        }

        #endregion Header

        #region Body

        public HTML_Object _Modal_Content_Body(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal_Content_Body");

            if (P_ModalInfo.Content_Body is not null)
            {
                L_HTML_Object.Add_Child(P_ModalInfo.Content_Body);
            }

            return L_HTML_Object;
        }

        #endregion Body

        #region Footer

        public HTML_Object _Modal_Content_Footer(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Modal_Content_Footer");

            if (P_ModalInfo.Content_Footer is not null)
            {
                L_HTML_Object.Add_Child(P_ModalInfo.Content_Footer);
            }
            else
            {
                L_HTML_Object.Add_Child(_Modal_Content_Footer_CloseBtn(P_ModalInfo));
            }

            return L_HTML_Object;
        }

        private HTML_Object _Modal_Content_Footer_CloseBtn(SH_Component_Info_Modal P_ModalInfo)
        {
            HTML_Object L_HTML_Object = _Button(new SH_Components_Info
            {
                Caption = "Close",
                Icon = SH_Components_IconTypes.close,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _Modal_Close_Event(P_ModalInfo));

            return L_HTML_Object;
        }

        #endregion Footer

        private string _Modal_Close_Event(SH_Component_Info_Modal P_ModalInfo)
        {
            return "_Modal_ShowHide('" + P_ModalInfo.Id + "', " + Convert.ToInt32(P_ModalInfo.RemoveOnClose).ToString() + ");";
        }
    }

    public class SH_Component_Info_Modal
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public bool NoMask { get; set; }
        public bool IsHidden { get; set; }
        public bool HasCloseBtn { get; set; } = true;
        public bool CanCloseOnMask { get; set; } = true;
        public bool RemoveOnClose { get; set; } = true;
        public HTML_Object Content_Header { get; set; }
        public HTML_Object Content_Body { get; set; }
        public HTML_Object Content_Footer { get; set; }
    }
}
