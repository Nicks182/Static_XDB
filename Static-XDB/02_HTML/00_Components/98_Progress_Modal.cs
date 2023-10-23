
using Services;
using SharpHTML;

namespace Static_XDB.HTML
{
    public partial class HTML_Components
    {
        public HTML_Object _Progress_Modal(Srv_Progress_Info P_Srv_Progress_Info)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Modal(new SH_Component_Info_Modal
            {
                Id = "Progress_Modal",
                Caption = "Progress...",
                Content_Body = _Progress_Modal_Body(P_Srv_Progress_Info),
                Content_Footer = _Progress_Modal_Footer(),
                HasCloseBtn = false,
                CanCloseOnMask = false,
            });

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Body(Srv_Progress_Info P_Srv_Progress_Info)
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Progressbar_Modal_Body");

            
            L_HTML_Object.Add_Child(_Progress_Modal_Body_Text(P_Srv_Progress_Info));
            L_HTML_Object.Add_Child(_Progress_Modal_Body_Bar(P_Srv_Progress_Info));
            L_HTML_Object.Add_Child(_Progress_Modal_Body_Time(P_Srv_Progress_Info));

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Body_Time(Srv_Progress_Info P_Srv_Progress_Info)
        {
            HTML_Object L_HTML_Object = G_SH_Components._PlainText(new SH_Components_Info
            {
                Id = "Prog_Time",
                Value = string.Format(@"{0} Hrs, {1} Min, {2} Sec",
                P_Srv_Progress_Info.ElapsedTime.Hours, P_Srv_Progress_Info.ElapsedTime.Minutes, P_Srv_Progress_Info.ElapsedTime.Seconds)
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Progressbar_Modal_Body_Time");

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Body_Text(Srv_Progress_Info P_Srv_Progress_Info)
        {
            HTML_Object L_HTML_Object = G_SH_Components._PlainText(new SH_Components_Info
            {
                Id = "Prog_Text",
                Value = "Starting..."
            });

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Body_Bar(Srv_Progress_Info P_Srv_Progress_Info)
        {
            HTML_Object L_HTML_Object = G_SH_Components._Progressbar(new SH_Components_Info
            {
                Id = "Prog_Value",
                Value = P_Srv_Progress_Info.Value.ToString("N0") + "%"
            });

            return L_HTML_Object;
        }



        public HTML_Object _Progress_Modal_Footer()
        {
            HTML_Object L_HTML_Object = new HTML_Object { Type = HTML_Object_Type.IsDiv };

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Progressbar_Modal_Footer");

            L_HTML_Object.Add_Child(_Progress_Modal_Footer_CancelBtn());
            L_HTML_Object.Add_Child(_Progress_Modal_Footer_OKBtn());

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Footer_CancelBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "Cancel",
                Icon = SH_Components_IconTypes.cancel,
                IsFlat = 0,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), "Progressbar_Modal_Footer_CancelBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Progressbar_Modal_Footer_CancelBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.ProgressCancel,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "Progress_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }

        public HTML_Object _Progress_Modal_Footer_OKBtn()
        {
            HTML_Object L_HTML_Object = G_SH_Components._Button(new SH_Components_Info
            {
                Caption = "OK",
                Icon = SH_Components_IconTypes.done,
                Icon_Pos = SH_Components_Info_Pos.Right,
                IsFlat = 0,
                IsHidden = 1,
            });

            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Id.ToString(), "Progressbar_Modal_Footer_OKBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.Class.ToString(), "Progressbar_Modal_Footer_OKBtn");
            L_HTML_Object.Add_Attribute(HTML_Attribute_Names.OnClick.ToString(), _PushMessage_Event(new Services.TM_Message
            {
                Message_Type = Services.TM_Message_Type.DoNothing,
                Actions = new List<SH_Action>
                {
                    new SH_Action
                    {
                        Action_Type = SH_Action_Type.SetModalState,
                        SourceId = "Progress_Modal",
                    }
                }
            }));

            return L_HTML_Object;
        }




    }

}
