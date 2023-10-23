
using SharpHTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _Projects_Save(TM_Message P_TM_Message)
        {
            SH_State_Item L_State_Item = G_SH_State.Get_Current();

            SH_State_Item_Control L_State_Control = null;
            foreach (var L_Action in P_TM_Message.Actions)
            {
                L_State_Control = L_State_Item.G_Controls.Where(c => c.Id == L_Action.SourceId).FirstOrDefault();
                if (L_State_Control is not null)
                {
                    L_State_Control.Value = L_Action.Value;
                }
            }

            // Do validation check...

            if(string.IsNullOrEmpty(L_State_Item._GetValue_String("Project_ProjectFolder")) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Project Folder is required.");
                return;
            }

            //if (string.IsNullOrEmpty(L_State_Item._GetValue_String("Project_ScriptFolder")) == true)
            //{
            //    P_TM_Message.Message_Type = TM_Message_Type.ShowMessage;
            //    P_TM_Message.Data = "Script Folder is required!";
            //    return;
            //}

            if (string.IsNullOrEmpty(L_State_Item._GetValue_String("Project_Name")) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Name is required.");
                return;
            }

            if (string.IsNullOrEmpty(L_State_Item._GetValue_String("Project_Server")) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "Server is required.");
                return;
            }

            if (string.IsNullOrEmpty(L_State_Item._GetValue_String("Project_DBName")) == true)
            {
                G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ShowMessage, "DB Name is required.");
                return;
            }

            string L_ProjectInfoId = L_State_Item._GetValue_String("ProjectInfoId");

            DB.ProjectInfo L_ProjectInfo = G_Srv_DB.ProjectInfo_Get(L_ProjectInfoId);

            if(L_ProjectInfo is null)
            {
                L_ProjectInfo = new DB.ProjectInfo();
            }
            
            L_ProjectInfo.Name                      = L_State_Item._GetValue_String("Project_Name");
            L_ProjectInfo.Port                      = L_State_Item._GetValue_String("Project_Port");
            L_ProjectInfo.DBName                    = L_State_Item._GetValue_String("Project_DBName");
            L_ProjectInfo.Server                    = L_State_Item._GetValue_String("Project_Server");
            L_ProjectInfo.Username                  = L_State_Item._GetValue_String("Project_Username");
            L_ProjectInfo.Password                  = L_State_Item._GetValue_String("Project_Password");
            L_ProjectInfo.SQLVersion                = L_State_Item._GetValue_String("Project_SQLVersion");
            L_ProjectInfo.Description               = L_State_Item._GetValue_String("Project_Description");
            L_ProjectInfo.Integrated                = L_State_Item._GetValue_Bool("Project_Intergrated");
            //L_ProjectInfo.ScriptFolder              = L_State_Item._GetValue_String("Project_ScriptFolder");
            L_ProjectInfo.ProjectFolder             = L_State_Item._GetValue_String("Project_ProjectFolder");
            L_ProjectInfo.TrustServerCertificate    = L_State_Item._GetValue_Bool("Project_Trust");

            G_Srv_DB.ProjectInfo_Save(L_ProjectInfo);

            P_TM_Message.Actions.Clear();
            P_TM_Message.Message_Type = TM_Message_Type.Projects_Show;
            _Projects_Show(P_TM_Message);
        }

        //private object _Save_Projects_GetValue(SH_FormState_Item P_State_Item, string P_Id)
        //{

        //    SH_FormState_Item_Control L_State_Control = P_State_Item.G_Controls.Where(c => c.Id.Equals(P_Id)).FirstOrDefault();
        //    if(L_State_Control is not null)
        //    {
        //        return L_State_Control.Value;
        //    }
        //    return null;
        //}

        //private string _Save_Projects_GetValue_String(SH_FormState_Item P_State_Item, string P_Id)
        //{
        //    object L_Value = _Save_Projects_GetValue(P_State_Item, P_Id);

        //    if(L_Value is not null)
        //    {
        //        return L_Value.ToString();
        //    }

        //    return string.Empty;
        //}

        //private bool _Save_Projects_GetValue_Bool(SH_FormState_Item P_State_Item, string P_Id)
        //{
        //    object L_Value = _Save_Projects_GetValue(P_State_Item, P_Id);

        //    if (L_Value is not null && string.IsNullOrEmpty(L_Value.ToString()) == false)
        //    {
        //        return Convert.ToBoolean(Convert.ToInt32(L_Value.ToString()));
        //    }

        //    return false;
        //}

        //private int _Save_Projects_GetValue_Int(SH_FormState_Item P_State_Item, string P_Id)
        //{
        //    object L_Value = _Save_Projects_GetValue(P_State_Item, P_Id);

        //    if (L_Value is not null && string.IsNullOrEmpty(L_Value.ToString()) == false)
        //    {
        //        return Convert.ToInt32(L_Value.ToString());
        //    }

        //    return 0;
        //}

    }
}
