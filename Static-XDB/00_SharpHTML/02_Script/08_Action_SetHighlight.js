

function _SharpHTML_Action_SetHighlight(P_Action)
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
                    _SharpHTML_Action_SetHighlight_Generic(L_Component)
                    break;

                case 1: // Textarea
                    _SharpHTML_Action_SetHighlight_Generic(L_Component)
                    break;

                case 2: // Checkbox
                    //_SharpHTML_Action_SetHighlight_Generic(L_Component)
                    break;

                case 3: // Button
                    //_SharpHTML_Action_SetHighlight_Generic(L_Component)
                    break;
            }
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}


function _SharpHTML_Action_SetHighlight_Generic(P_Component)
{
    try
    {
        P_Component.select();
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

