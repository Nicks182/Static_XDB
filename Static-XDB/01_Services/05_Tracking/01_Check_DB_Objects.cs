using System.Data;
using System.Text;

using Microsoft.Data.SqlClient;

using Services.DB;

namespace Services
{
    public partial class Srv_Tracking
    {
        //public void _Init_DB_Objects(DB.ProjectInfo P_ProjectInfo)
        //{
        //    if (Srv_MSSQL._IsServerAndDBOnline(P_ProjectInfo) == true)
        //    {
        //        DataTable L_DataTable = _Check_DB_Objects_GetData(P_ProjectInfo);

        //        DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(P_ProjectInfo.Id) == true).FirstOrDefault();

        //        if (L_Tracking is not null)
        //        {
        //            List<DB.Tracking_Object> L_Tracking_Objects = G_Srv_DB.Tracking_Object_GetAll().Find(to => to.TrackingId.Equals(L_Tracking.Id) == true).ToList();

        //            for (int to = 0; to < L_Tracking_Objects.Count; to++)
        //            {
        //                G_Srv_DB.Tracking_Object_Delete(L_Tracking_Objects[to]);
        //            }

        //            //G_Srv_DB.Tracking_Delete(L_Tracking);
        //        }
        //        else
        //        {
        //            L_Tracking = new Tracking();
        //            L_Tracking.ProjectInfoId = P_ProjectInfo.Id;
        //            G_Srv_DB.Tracking_Save(L_Tracking);
        //        }

        //        DB.Tracking_Object L_Tracking_Object;
        //        for (int r = 0; r < L_DataTable.Rows.Count; r++)
        //        {
        //            L_Tracking_Object                   = new Tracking_Object();
        //            L_Tracking_Object.TrackingId        = L_Tracking.Id;
        //            L_Tracking_Object.ObjectId          = L_DataTable.Rows[r]["ObjectId"].ToString();
        //            L_Tracking_Object.ObjectName        = L_DataTable.Rows[r]["ObjectName"].ToString();
        //            L_Tracking_Object.ObjectType        = L_DataTable.Rows[r]["ObjectType"].ToString();
        //            L_Tracking_Object.ObjectTypeDesc    = L_DataTable.Rows[r]["ObjectTypeDesc"].ToString();
        //            L_Tracking_Object.CreatedOn         = L_DataTable.Rows[r]["CreatedOn"].ToString();
        //            L_Tracking_Object.LastChanged       = L_DataTable.Rows[r]["LastChanged"].ToString();
        //            L_Tracking_Object.ObjectId          = L_DataTable.Rows[r]["ObjectId"].ToString();
        //            L_Tracking_Object.IsRemoved         = false;
        //            L_Tracking_Object.Changed           = 0;

        //            G_Srv_DB.Tracking_Object_Save(L_Tracking_Object);
        //        }
                
        //    }
        //}

        public void _Check_DB_Objects(DB.ProjectInfo P_ProjectInfo)
        {
            G_DoCancel = false;
            if (Srv_MSSQL._IsServerAndDBOnline(P_ProjectInfo) == true)
            {
                DataTable L_DataTable = _Check_DB_Objects_GetData(P_ProjectInfo);

                DB.Tracking L_Tracking = G_Srv_DB.Tracking_GetAll().Find(t => t.ProjectInfoId.Equals(P_ProjectInfo.Id) == true).FirstOrDefault();

                if(L_Tracking is null)
                {
                    L_Tracking = new Tracking();
                    L_Tracking.ProjectInfoId = P_ProjectInfo.Id;
                    G_Srv_DB.Tracking_Save(L_Tracking);
                }

                List<DB.Tracking_Object> L_Tracking_Objects = G_Srv_DB.Tracking_Object_GetAll().Find(to => to.TrackingId.Equals(L_Tracking.Id) == true).OrderByDescending(to => to.Changed).ThenBy(to => to.ObjectType).ThenBy(to => to.ObjectName).ToList();

                for(int to = 0; to < L_Tracking_Objects.Count; to++)
                {
                    L_DataTable.DefaultView.RowFilter = "ObjectId = '" + L_Tracking_Objects[to].ObjectId + "'";
                    if(L_Tracking_Objects[to].IsRemoved != (L_DataTable.DefaultView.Count == 0))
                    {
                        L_Tracking_Objects[to].Changed++;
                    }
                    L_Tracking_Objects[to].IsRemoved = (L_DataTable.DefaultView.Count == 0);

                    G_Srv_DB.Tracking_Object_Save(L_Tracking_Objects[to]);
                }
                    

                DB.Tracking_Object L_Tracking_Object;
                for (int r = 0; r < L_DataTable.Rows.Count; r++)
                {
                    L_Tracking_Object = L_Tracking_Objects.FirstOrDefault(to => to.ObjectId == L_DataTable.Rows[r]["ObjectId"].ToString());
                    if(L_Tracking_Object is null)
                    {
                        L_Tracking_Object = new DB.Tracking_Object
                        {
                            TrackingId = L_Tracking.Id
                        };

                        L_Tracking_Object.Changed           = L_Tracking.WasObjectsInit ? 1 : 0;
                        L_Tracking_Object.ObjectId          = L_DataTable.Rows[r]["ObjectId"].ToString();
                        L_Tracking_Object.IsRemoved         = false;
                        L_Tracking_Object.CreatedOn         = L_DataTable.Rows[r]["CreatedOn"].ToString();
                        L_Tracking_Object.ObjectName        = L_DataTable.Rows[r]["ObjectName"].ToString();
                        L_Tracking_Object.ObjectType        = L_DataTable.Rows[r]["ObjectType"].ToString();
                        L_Tracking_Object.LastChanged       = L_DataTable.Rows[r]["LastChanged"].ToString();
                        L_Tracking_Object.ObjectTypeDesc    = L_DataTable.Rows[r]["ObjectTypeDesc"].ToString();
                    }
                    else
                    {
                        if (L_DataTable.Rows[r]["LastChanged"].ToString().Equals(L_Tracking_Object.LastChanged) == false)
                        {
                            L_Tracking_Object.Changed++;
                            L_Tracking_Object.LastChanged = L_DataTable.Rows[r]["LastChanged"].ToString();
                        }
                    }

                    
                    G_Srv_DB.Tracking_Object_Save(L_Tracking_Object);
                }

                if (L_Tracking.WasObjectsInit == false)
                {
                    L_Tracking.WasObjectsInit = true;
                    G_Srv_DB.Tracking_Save(L_Tracking);
                }
            }
        }

        private DataTable _Check_DB_Objects_GetData(DB.ProjectInfo P_ProjectInfo)
        {
            DataTable L_DataTable = new DataTable();
            SqlConnectionStringBuilder L_SqlConnectionStringBuilder = new SqlConnectionStringBuilder(Srv_MSSQL._Get_Connection_String(P_ProjectInfo));
            L_SqlConnectionStringBuilder.ConnectTimeout = 5;

            using (SqlConnection L_SqlConnection = new SqlConnection(L_SqlConnectionStringBuilder.ToString()))
            {
                using (SqlCommand L_SqlCommand = new SqlCommand(_Check_DB_Objects_Query(P_ProjectInfo).ToString(), L_SqlConnection))
                {
                    using (SqlDataAdapter L_SqlDataAdapter = new SqlDataAdapter(L_SqlCommand))
                    {
                        
                        L_SqlDataAdapter.Fill(L_DataTable);

                    }
                }
            }

            return L_DataTable;
        }

        private StringBuilder _Check_DB_Objects_Query(DB.ProjectInfo P_ProjectInfo)
        {
            StringBuilder L_Query = new StringBuilder();

            L_Query.AppendLine("SELECT");
            L_Query.AppendLine("object_id   AS [ObjectId],");
            L_Query.AppendLine("name        AS [ObjectName],");
            L_Query.AppendLine("type        AS [ObjectType],");
            L_Query.AppendLine("type_desc   AS [ObjectTypeDesc],");
            L_Query.AppendLine("create_date AS [CreatedOn],");
            L_Query.AppendLine("modify_date AS [LastChanged]");
            L_Query.AppendLine("FROM");
            L_Query.AppendLine("[" + P_ProjectInfo.DBName + "].sys.objects");
            L_Query.AppendLine("WHERE");
            L_Query.AppendLine("type in ('P', 'U', 'FN', 'V', 'SN')");

            L_Query.AppendLine("UNION ALL");

            L_Query.AppendLine("SELECT");
            L_Query.AppendLine("object_id   AS [ObjectId],");
            L_Query.AppendLine("name        AS [ObjectName],");
            L_Query.AppendLine("type        AS [ObjectType],");
            L_Query.AppendLine("type_desc   AS [ObjectTypeDesc],");
            L_Query.AppendLine("create_date AS [CreatedOn],");
            L_Query.AppendLine("modify_date AS [LastChanged]");
            L_Query.AppendLine("FROM");
            L_Query.AppendLine("[" + P_ProjectInfo.DBName + "].sys.triggers");

            L_Query.AppendLine("ORDER BY");
            L_Query.AppendLine("[ObjectType], [ObjectName] ");

            return L_Query;
        }
    }

}
