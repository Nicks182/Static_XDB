using Static_XDB.HTML;
using System.Reflection;

namespace SharpHTML
{
    public partial class SH_Components
    {
        public HTML_Object _Busy_Modal()
        {
            HTML_Object L_HTML_Object = _Modal(new SH_Component_Info_Modal
            {
                Id = "Busy_Modal",
                Caption = "Busy...",
                Content_Body = _Busy_Modal_Body(),
                Content_Footer = _Busy_Modal_Footer(),
                CanCloseOnMask = false,
                IsHidden = false,
                RemoveOnClose = false,
            });

            return L_HTML_Object;
        }

        public HTML_Object _Busy_Modal_Body()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsRaw, NoClean = true };

            L_HTML_Object.RawValue = new System.Text.StringBuilder(
                "<div class=\"mixtape-container\">" +
                    "<div class=\"mixtape-inner\">" +
                        "<div class=\"mixtape-inner-middle\">" +
                            "<div class=\"mixtape-inner-tape\">" +
                                "<div class=\"mixtape-inner-tape-ring\">" +
                                    "<span></span><span></span><span></span><span></span><span></span>" +
                                "</div>" +
                            "</div>" +
                            "<div class=\"mixtape-inner-tape\">" +
                                "<div class=\"mixtape-inner-tape-ring\">" +
                                    "<span></span><span></span><span></span><span></span><span></span>" +
                                "</div>" +
                            "</div>" +
                        "</div>" +
                    "</div>" +
                    "<div class=\"mixtape-bottom\">" +
                        "<div class=\"mixtape-bottom-circle\"></div>" +
                        "<div class=\"mixtape-bottom-circle\"></div>" +
                        "<div class=\"mixtape-bottom-circle\"></div>" +
                        "<div class=\"mixtape-bottom-circle\"></div>" +
                    "</div>" +
                    "<div class=\"mixtape-detail\">" +
                        "<div class=\"screw\"></div>" +
                        "<div class=\"screw\"></div>" +
                        "<div class=\"screw\"></div>" +
                        "<div class=\"screw\"></div>" +
                        "<span class=\"tape-hole\"></span><span class=\"tape-hole\"></span><span class=\"tape-hole\"></span>" +
                    "</div>" +
                "</div>");

            return L_HTML_Object;
        }

        public HTML_Object _Busy_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };


            return L_HTML_Object;
        }

    }

}
