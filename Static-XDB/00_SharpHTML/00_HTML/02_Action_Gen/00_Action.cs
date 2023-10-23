
namespace SharpHTML
{
    public class SH_Action
    {
        public string SourceId { get; set; }
        public object Value { get; set; } = "";

        public SH_Action_Type Action_Type { get; set; }
    }

    public enum SH_Action_Type
    {
        DoNothing,
        GetValue,
        SetValue,
        GetLocalStore,
        SetLocalStore,
        SetFocus,
        SetHighlight,
        SetHidden,
        SetModalState,
    }
}
