
using SharpHTML;

namespace Services
{
    public class TM_Message
    {
        public string UniqueId { get; set; } = "";
        public string Data { get; set; } = "";

        public TM_Message_Type Message_Type { get; set; } = TM_Message_Type.DoNothing;
        public List<TM_Message_Html> HTMLs { get; set; } = new List<TM_Message_Html>();
        public List<SH_Action> Actions { get; set; } = new List<SH_Action>();
    }

    public enum TM_Message_Type
    {
        DoNothing,
        Init,
        Screen_Back,
        ShowMessage,
        ShowModal,
        ProgressUpdate,
        ProgressCancel,
        ValueChange,

        Main_Project_Select_Show,
        Main_Project_Select_Set,

        FolderBrowser_Show,
        FolderBrowser_GoTo,
        FolderBrowser_GoUp,
        FolderBrowser_Select,
        FolderBrowser_Cancel,
        Projects_Show,
        Projects_Export,
        Projects_Import,
        Projects_Import_Load,
        Projects_Import_Cancel,
        Projects_Import_Save,
        Projects_Edit,
        Projects_Edit_Remove,
        Projects_Edit_Cancel,
        Projects_Edit_Save,
        Projects_Show_Server,
        Projects_Select_Server,
        Projects_Show_SQLVersions,
        Projects_Select_SQLVersions,
        
        PushIt,
        PushIt_To_Files,
        PushIt_To_DB,

        Ignores_Show,
        Ignores_Import,
        Ignores_Export,
        Ignores_Modify_Show,
        Ignores_Modify_Remove,
        Ignores_Modify_ChangeType,
        Ignores_Modify_Save,
        Ignores_Modify_Close,
        
        Tracking_View_Objects,
        Tracking_View_Data,
        Tracking_Check_Objects,
        Tracking_Check_Data,
        Tracking_View_Diff,
        Tracking_View_Diff_Data,
        Tracking_View_Diff_Back,
        Tracking_View_Diff_Back_Data,
        
        Launch_Remote,
        Launch_ProjectFolder,
        Launch_ScriptFolder,
    }


}
