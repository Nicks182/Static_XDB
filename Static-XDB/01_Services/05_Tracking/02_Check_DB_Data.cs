using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;
using Microsoft.SqlServer.Management.Smo;
using Services.DB;

namespace Services
{
    public partial class Srv_Tracking
    {
        public Task _Check_DB_Data(DB.ProjectInfo P_ProjectInfo)
        {
            
            Task L_Task = Task.Run(() =>
            {
                DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(P_ProjectInfo.Id) == true).FirstOrDefault();

                if (L_Tracking is not null)
                {
                    List<DB.Tracking_Data> L_Tracking_Datas = G_Srv_DB.Tracking_Data_GetAll().Find(to => to.TrackingId.Equals(L_Tracking.Id) == true).ToList();

                    for (int to = 0; to < L_Tracking_Datas.Count; to++)
                    {
                        G_Srv_DB.Tracking_Data_Delete(L_Tracking_Datas[to]);
                    }
                }
                else
                {
                    L_Tracking = new Tracking();
                    L_Tracking.ProjectInfoId = P_ProjectInfo.Id;
                    G_Srv_DB.Tracking_Save(L_Tracking);
                }

                Environment.CurrentDirectory = Srv_ScriptsFolder._Get(P_ProjectInfo);
                Srv_SMO L_Srv_SMO = new Srv_SMO(G_Srv_MessageBus, G_Srv_DB, P_ProjectInfo);
                List<Table> L_Tables = L_Srv_SMO._Get_Table_Data();

                G_Srv_Progress = new Srv_Progress(G_Srv_MessageBus, L_Tables.Count + 1);
                G_Srv_Progress._ShowProgress();

                Srv_Tracking_DiffInfo L_Srv_Tracking_DiffInfo;
                Tracking_Data L_Tracking_Data;
                for (int i = 0; i < L_Tables.Count; i++)
                {
                    if(G_DoCancel == true)
                    {
                        G_DoCancel = false;
                        break;
                    }
                    G_Srv_Progress._SetProgress(i, "Checking Table: " + L_Tables[i].Name);

                    L_Srv_Tracking_DiffInfo = _ViewDiff_Data(L_Srv_SMO, P_ProjectInfo, L_Tables[i].Name);

                    if (L_Srv_Tracking_DiffInfo is not null)
                    {
                        L_Tracking_Data = G_Srv_DB.Tracking_Data_GetAll().Find(td => td.TrackingId == L_Tracking.Id && td.TableName == L_Srv_Tracking_DiffInfo.ObjectName).FirstOrDefault();

                        if (L_Tracking_Data is null)
                        {
                            L_Tracking_Data = new Tracking_Data();
                        }
                        L_Tracking_Data.TrackingId = L_Tracking.Id;
                        L_Tracking_Data.Changed = L_Srv_Tracking_DiffInfo.TotalChanges;
                        L_Tracking_Data.TableName = L_Srv_Tracking_DiffInfo.ObjectName;
                        L_Tracking_Data.LastCheck = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                        G_Srv_DB.Tracking_Data_Save(L_Tracking_Data);
                    }
                }

                    G_Srv_Progress._SetProgress(L_Tables.Count + 1, "Check Data changes completed!");
            });

            

            return L_Task;
        }

    }

}
