

function _SharpHTML_Action_GetLocalStore(P_Action)
{
    try
    {
        P_Action.Value = localStorage.getItem(P_Action.SourceId);
        //if (P_Action.Value == null)
        //{
        //    P_Action.Value = "_NA_";
        //}
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}
