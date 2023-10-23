namespace Services
{
    public partial class Srv_Tracking
    {
        private Srv_MessageBus G_Srv_MessageBus;
        private Srv_Progress G_Srv_Progress;
        DB.Srv_DB G_Srv_DB { get; set; }

        bool G_DoCancel = false;

        public Srv_Tracking(Srv_MessageBus P_Srv_MessageBus, DB.Srv_DB P_Srv_DB)
        {
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Srv_DB = P_Srv_DB;

            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.Cancel_Job, (P_Message) =>
            {
                G_DoCancel = true;
            });
        }

        //public void _CancelMe()
        //{
        //    G_DoCancel = true;
        //}
    }

}
