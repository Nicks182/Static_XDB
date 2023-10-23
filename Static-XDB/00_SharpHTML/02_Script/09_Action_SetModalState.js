

function _SharpHTML_Action_SetModalState(P_Action)
{
    try
    {
        _Modal_ShowHide(P_Action.SourceId, 1);
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}
