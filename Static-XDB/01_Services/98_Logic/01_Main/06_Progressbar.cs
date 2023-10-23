
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        public string _Progressbar_Show(Srv_Progress_Info P_Srv_Progress_Info)
        {
            TM_Message L_TM_Message = new TM_Message();
            L_TM_Message.Message_Type = TM_Message_Type.DoNothing;
            L_TM_Message.HTMLs.Add(new TM_Message_Html
            {
                ContainerId = HTML_Components_Names.Div_ModalHolder.ToString(),
                HTML = G_Srv_HTML_Gen._BuildHtml(G_HTML_Components._Progress_Modal(new Srv_Progress_Info
                {
                    Text = P_Srv_Progress_Info.Text,
                    Value = P_Srv_Progress_Info.Value
                })).ToString(),
                IsAppend = true
            });

            return SH_ActionGen._ToJSON_String(L_TM_Message);
        }

        private string _Progressbar_Update(Srv_Progress_Info P_Srv_Progress_Info)
        {
            TM_Message L_TM_Message = new TM_Message();
            L_TM_Message.Message_Type = TM_Message_Type.ProgressUpdate;

            L_TM_Message.Actions.Add(new SH_Action
            {
                Action_Type = SH_Action_Type.SetValue,
                SourceId = "Prog_Time",
                Value = string.Format(@"{0} Hrs, {1} Min, {2} Sec",
                    P_Srv_Progress_Info.ElapsedTime.Hours, P_Srv_Progress_Info.ElapsedTime.Minutes, P_Srv_Progress_Info.ElapsedTime.Seconds)
            });

            L_TM_Message.Actions.Add(new SH_Action
            {
                Action_Type = SH_Action_Type.SetValue,
                SourceId = "Prog_Text",
                Value = P_Srv_Progress_Info.Text
            });

            L_TM_Message.Actions.Add(new SH_Action
            {
                Action_Type = SH_Action_Type.SetValue,
                SourceId = "Prog_Value",
                Value = P_Srv_Progress_Info.Value.ToString("N0") + "%"
            });

            if(Math.Ceiling(P_Srv_Progress_Info.Value) == 100)
            {
                L_TM_Message.Actions.Add(new SH_Action
                {
                    Action_Type = SH_Action_Type.SetHidden,
                    SourceId = "Progressbar_Modal_Footer_CancelBtn",
                    Value = "1"
                });

                L_TM_Message.Actions.Add(new SH_Action
                {
                    Action_Type = SH_Action_Type.SetHidden,
                    SourceId = "Progressbar_Modal_Footer_OKBtn",
                    Value = "0"
                });
            }

            return SH_ActionGen._ToJSON_String(L_TM_Message);
        }

    }
}
