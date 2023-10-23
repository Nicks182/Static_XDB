
namespace SharpHTML
{
    public partial class SH_State
    {
        List<SH_State_Item> G_Items = new List<SH_State_Item>();

        public void Add(SH_State_Item P_Item, bool P_SetFocus = true)
        {
            if(P_SetFocus == true)
            {
                Set_Focus(P_Item);
            }
            G_Items.Add(P_Item);
        }

        public void Set_Focus(SH_State_Item P_Item)
        {
            foreach (var L_Item in G_Items.Where(i => i.IsCurrentFocus == true))
            {
                L_Item.IsCurrentFocus = false;
            }
            P_Item.IsCurrentFocus = true;
        }

        public SH_State_Item Get_Current()
        {
            return G_Items.Where(i => i.IsCurrentFocus == true).FirstOrDefault();
        }

        public SH_State_Item Get_Current_Parent()
        {
            SH_State_Item L_SH_State_Item = Get_Current();
            return Get(L_SH_State_Item.ParentId);
        }

        public SH_State_Item Get(string P_Id)
        {
            return G_Items.Where(i => i.Id.Equals(P_Id)).FirstOrDefault();
        }

        public void _Remove(string P_Id)
        {
            SH_State_Item L_Item = G_Items.Where(i => i.Id.Equals(P_Id)).FirstOrDefault();
            G_Items.Remove(L_Item);
        }
    }
    
    public class SH_State_Item
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string ParentId { get; set; } = "";
        public bool IsCurrentFocus { get; set; } = false;
        public List<SH_State_Item_Control> G_Controls = new List<SH_State_Item_Control>();

        public object _GetValue(string P_Id)
        {

            SH_State_Item_Control L_State_Control = G_Controls.Where(c => c.Id.Equals(P_Id)).FirstOrDefault();
            if (L_State_Control is not null)
            {
                return L_State_Control.Value;
            }
            return null;
        }

        public string _GetValue_String(string P_Id)
        {
            object L_Value = _GetValue(P_Id);

            if (L_Value is not null)
            {
                return L_Value.ToString();
            }

            return string.Empty;
        }

        public bool _GetValue_Bool(string P_Id)
        {
            object L_Value = _GetValue(P_Id);

            if (L_Value is not null && string.IsNullOrEmpty(L_Value.ToString()) == false)
            {
                return Convert.ToBoolean(Convert.ToInt32(L_Value.ToString()));
            }

            return false;
        }

        public int _GetValue_Int(string P_Id)
        {
            object L_Value = _GetValue(P_Id);

            if (L_Value is not null && string.IsNullOrEmpty(L_Value.ToString()) == false)
            {
                return Convert.ToInt32(L_Value.ToString());
            }

            return 0;
        }
    }


    public class SH_State_Item_Control
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Caption { get; set; }
        public string Text { get; set; }
        public object Value { get; set; }
        public bool IsHidden { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsFocus { get; set; }
        public SH_FormState_Item_Control_CaptionPosition CaptionPosition { get; set; }
        public SH_Components_Types Components_Type { get; set; } = SH_Components_Types.Textbox;
        public SH_FormState_Item_Control_Validation_State Validation_State { get; set; } = SH_FormState_Item_Control_Validation_State.Pass;

        public List<HTML_Object_Attribute> Attributes { get; set; } = new List<HTML_Object_Attribute>();
        public List<SH_State_Item_Control_Event> Events { get; set; } = new List<SH_State_Item_Control_Event>();

        public Dictionary<string, object> MetaData { get; set; } = new Dictionary<string, object>();

        public object _Get_MetaValue(string P_Name)
        {
            return MetaData[P_Name];
        }
    }

    public enum SH_FormState_Item_Control_Validation_State
    {
        Pass = 0,
        Fail = 1,
    }

    public enum SH_FormState_Item_Control_CaptionPosition
    {
        Top = 0,
        Right = 1,
        Bottom = 2,
        Left = 3,
    }

    public class SH_State_Item_Control_Event
    {
        public string EventName { get; set; }
        public string Event { get; set; }
    }
}
