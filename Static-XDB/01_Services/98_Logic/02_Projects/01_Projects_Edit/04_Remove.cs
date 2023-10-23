
namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _Projects_Remove(TM_Message P_TM_Message)
        {
            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(P_TM_Message.Data);

            if (L_ProjectInfo is null)
            {
                P_TM_Message.Actions.Clear();
                P_TM_Message.Message_Type = TM_Message_Type.Projects_Show;
                return;
            }


            DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(L_ProjectInfo.Id)).FirstOrDefault();

            if(L_Tracking is not null)
            {
                List<DB.Tracking_Object> L_Tracking_Object = G_Srv_DB.Tracking_Object_GetAll().Find(td => td.TrackingId.Equals(L_Tracking.Id)).ToList();

                for(int i = 0; i <  L_Tracking_Object.Count; i++)
                {
                    G_Srv_DB.Tracking_Object_Delete(L_Tracking_Object[i]);
                }

                List<DB.Tracking_Data> L_Tracking_Data = G_Srv_DB.Tracking_Data_GetAll().Find(td => td.TrackingId.Equals(L_Tracking.Id)).ToList();

                for (int i = 0; i < L_Tracking_Data.Count; i++)
                {
                    G_Srv_DB.Tracking_Data_Delete(L_Tracking_Data[i]);
                }
            }

            List<DB.Ignore> L_Ignore = G_Srv_DB.Ignore_GetAll().Find(td => td.ProjectInfoId.Equals(L_ProjectInfo.Id)).ToList();

            for (int i = 0; i < L_Ignore.Count; i++)
            {
                G_Srv_DB.Ignore_Delete(L_Ignore[i]);
            }

            G_Srv_DB.ProjectInfo_Delete(L_ProjectInfo);

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.Projects_Show;
            _Projects_Show(P_TM_Message);
        }


    }
}
