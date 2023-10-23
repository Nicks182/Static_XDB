
using Services.DB;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        public void _ProcessMessage(TM_Message P_TM_Message)
        {
            switch(P_TM_Message.Message_Type)
            {
                case TM_Message_Type.DoNothing:
                    //Maybe something happened Client side, but serverside... Just do nothing...
                    break;

                case TM_Message_Type.Init:
                    _Init(P_TM_Message);
                    break;

                case TM_Message_Type.ProgressCancel:
                    _ProgressCancel();
                    break;

                case TM_Message_Type.ValueChange:
                    _ValueChange(P_TM_Message);
                    break;


                case TM_Message_Type.Main_Project_Select_Show:
                    _Main_Project_Select_Show(P_TM_Message);
                    break;

                case TM_Message_Type.Main_Project_Select_Set:
                    _Main_Project_Select_Set(P_TM_Message);
                    break;

                case TM_Message_Type.FolderBrowser_Show:
                case TM_Message_Type.FolderBrowser_GoTo:
                case TM_Message_Type.FolderBrowser_GoUp:
                case TM_Message_Type.FolderBrowser_Select:
                case TM_Message_Type.FolderBrowser_Cancel:
                    _FolderBrowser(P_TM_Message);
                    break;


                #region Projects
                case TM_Message_Type.Projects_Show:
                case TM_Message_Type.Projects_Export:
                case TM_Message_Type.Projects_Import:
                case TM_Message_Type.Projects_Import_Load:
                case TM_Message_Type.Projects_Import_Cancel:
                case TM_Message_Type.Projects_Import_Save:
                case TM_Message_Type.Projects_Edit:
                case TM_Message_Type.Projects_Edit_Remove:
                case TM_Message_Type.Projects_Edit_Cancel:
                case TM_Message_Type.Projects_Edit_Save:
                case TM_Message_Type.Projects_Show_Server:
                case TM_Message_Type.Projects_Select_Server:
                case TM_Message_Type.Projects_Show_SQLVersions:
                case TM_Message_Type.Projects_Select_SQLVersions:
                    _Projects(P_TM_Message);
                    break;

                #endregion Projects


                #region PushIt
                case TM_Message_Type.PushIt:
                case TM_Message_Type.PushIt_To_Files:
                case TM_Message_Type.PushIt_To_DB:
                    _PushIt(P_TM_Message);
                    break;
                #endregion PushIt


                #region Ignores
                case TM_Message_Type.Ignores_Show:
                case TM_Message_Type.Ignores_Modify_Show:
                case TM_Message_Type.Ignores_Modify_Remove:
                case TM_Message_Type.Ignores_Modify_ChangeType:
                case TM_Message_Type.Ignores_Modify_Save:
                case TM_Message_Type.Ignores_Modify_Close:
                    _IgnoredObjects(P_TM_Message);
                    break;
                #endregion Ignores

                #region Tracking
                case TM_Message_Type.Tracking_View_Objects:
                case TM_Message_Type.Tracking_View_Data:
                case TM_Message_Type.Tracking_Check_Objects:
                case TM_Message_Type.Tracking_Check_Data:
                case TM_Message_Type.Tracking_View_Diff:
                case TM_Message_Type.Tracking_View_Diff_Data:
                case TM_Message_Type.Tracking_View_Diff_Back:
                case TM_Message_Type.Tracking_View_Diff_Back_Data:
                    _Tracking(P_TM_Message);
                    break;
                #endregion Tracking


                #region Launch URL || Directory
                case TM_Message_Type.Launch_Remote:
                case TM_Message_Type.Launch_ProjectFolder:
                case TM_Message_Type.Launch_ScriptFolder:
                    _Launch(P_TM_Message);
                    break;
                #endregion Launch URL || Directory

            }
        }

    }

    
}
