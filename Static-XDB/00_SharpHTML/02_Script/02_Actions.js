

function _SharpHTML_ProcessActions(P_Actions)
{
    try
    {
        if (P_Actions)
        {
            for (var i = 0; i < P_Actions.length; i++)
            {
                switch (P_Actions[i].Action_Type)
                {
                    case "GetValue":
                        _SharpHTML_Action_GetValue(P_Actions[i]);
                        break;

                    case "SetValue":
                        _SharpHTML_Action_SetValue(P_Actions[i]);
                        break;

                    case "GetLocalStore":
                        _SharpHTML_Action_GetLocalStore(P_Actions[i]);
                        break;

                    case "SetLocalStore":
                        _SharpHTML_Action_SetLocalStore(P_Actions[i]);
                        break;

                    case "SetFocus":
                        _SharpHTML_Action_SetFocus(P_Actions[i]);
                        break;

                    case "SetHighlight":
                        _SharpHTML_Action_SetHighlight(P_Actions[i]);
                        break;

                    case "SetModalState":
                        _SharpHTML_Action_SetModalState(P_Actions[i]);
                        break;

                    case "SetHidden":
                        _SharpHTML_Action_SetHidden(P_Actions[i]);
                        break;
                }
            }

        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_MessageFromBase64(P_TM_Message)
{
    try
    {
        return JSON.parse(atob(P_TM_Message));
        
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}