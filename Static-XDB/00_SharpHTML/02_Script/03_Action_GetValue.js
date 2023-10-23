

function _SharpHTML_Action_GetValue(P_Action)
{
    try
    {
        var L_Component = document.getElementById(P_Action.SourceId);
        if (L_Component != null)
        {
            var L_CompType = parseInt(L_Component.getAttribute("CompType"));

            switch (L_CompType)
            {
                case 0: // Textbox
                    P_Action.Value = _SharpHTML_Action_GetValue_Textbox_Textarea(L_Component);
                    break;

                case 1: // Textarea
                    P_Action.Value = _SharpHTML_Action_GetValue_Textbox_Textarea(L_Component);
                    break;

                case 2: // Checkbox
                    P_Action.Value = _SharpHTML_Action_GetValue_Checkbox(L_Component);
                    break;
            }
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}


function _SharpHTML_Action_GetValue_Textbox_Textarea(P_Component)
{
    try
    {
        return P_Component.value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}


function _SharpHTML_Action_GetValue_Checkbox(P_Component)
{
    try
    {
        return P_Component.getAttribute("Value");
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}