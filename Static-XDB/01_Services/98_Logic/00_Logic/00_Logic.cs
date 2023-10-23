
using Services.DB;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        Srv_MessageBus G_Srv_MessageBus { get; set; }
        Srv_HTML_Gen G_Srv_HTML_Gen { get; set; }
        HTML_Components G_HTML_Components { get; set; }

        DB.Srv_DB G_Srv_DB { get; set; }

        SH_State G_SH_State { get; set; }

        Srv_DriveBrowser G_Srv_DriveBrowser { get; set; }

        Srv_ProjectStatus G_Srv_ProjectStatus { get; set; }

        Srv_Tracking G_Srv_Tracking { get; set; }

        Srv_SMO G_Srv_SMO { get; set; }

        public Srv_Logic(Srv_MessageBus P_Srv_MessageBus)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Srv_HTML_Gen = new Srv_HTML_Gen();
            G_HTML_Components = new HTML_Components();

            G_Srv_DB = new Srv_DB();

            G_SH_State = new SH_State();

            G_Srv_ProjectStatus = new Srv_ProjectStatus(G_Srv_MessageBus, G_Srv_DB);
            G_Srv_Tracking = new Srv_Tracking(G_Srv_MessageBus, G_Srv_DB);

            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.ProgressShow, (P_ProgressInfo) =>
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.TransportMessage, _Progressbar_Show((Srv_Progress_Info)P_ProgressInfo));
            });

            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.ProgressUpdate, (P_ProgressInfo) =>
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.TransportMessage, _Progressbar_Update((Srv_Progress_Info)P_ProgressInfo));
            });

            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.ShowMessage, (P_MessageText) =>
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.TransportMessage, _Get_Show_Message(P_MessageText));
            });
        }



        
    }


    
}
