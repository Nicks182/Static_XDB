
namespace SharpHTML
{
    public enum SH_Components_Types
    {
        Textbox = 0,
        Textarea = 1,
        Checkbox = 2,
        Button = 3,
        Password = 4,
        Dropdown = 5,
        FolderBrowser = 6,
        Progressbar = 7,
        PlainText = 8,
    }
    public class SH_Components_Info
    {
        public string Id { get; set; }
        public string Caption { get; set; }
        public string Value { get; set; }
        public int IsReadonly { get; set; }
        public int IsHidden { get; set; }
        public int IsFlat { get; set; } = 1;
        public bool IsFocus { get; set; }

        public SH_Components_IconTypes Icon { get; set; } = SH_Components_IconTypes.None;
        public SH_Components_Info_Pos Icon_Pos { get; set; } = SH_Components_Info_Pos.Left;
        public SH_Components_Info_Pos Text_Align { get; set; } = SH_Components_Info_Pos.Center;

    }

    public class SH_Components_Info_Action
    {
        public SH_Components_Info_Action_Trigger_Type Trigger { get; set; }
        public SH_Components_Info_Action_Type Action_Type { get; set; }
        public string SourceId { get; set; }
        
    }

    public enum SH_Components_Info_Action_Trigger_Type
    {
        _DoNothing,
        OnClick,
        OnKeyDown,
        OnKeyUp,
    }

    public enum SH_Components_Info_Action_Type
    {
        _DoNothing,
        GetValue,
        SetValue,
    }

    public enum SH_Components_Info_Pos
    {
        Left,
        Center,
        Right
    }

}
