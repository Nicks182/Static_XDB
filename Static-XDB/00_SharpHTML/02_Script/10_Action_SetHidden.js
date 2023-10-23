

function _SharpHTML_Action_SetHidden(P_Action)
{
    try
    {
        var L_Component = document.getElementById(P_Action.SourceId);
        if (L_Component != null)
        {
            L_Component.setAttribute("IsHidden", P_Action.Value);
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}