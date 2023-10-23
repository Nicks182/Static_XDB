

function _SharpHTML_Action_SetLocalStore(P_Action)
{
    try
    {
        localStorage.setItem(P_Action.SourceId, P_Action.Value);
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

