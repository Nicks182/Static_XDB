

function _Init()
{
    try
    {
        window.external.sendMessage("init");
    }
    catch (ex)
    {
        alert("Function: _Init \nMsg: " + ex);
    }
}

// Generic handler used when nothing custom needs to happen... just send message to server for processing...
function _PushMessage(P_TM_Message_String)
{
    try
    {
        var L_TM_Message = _SharpHTML_MessageFromBase64(P_TM_Message_String)

        _SharpHTML_ProcessActions(L_TM_Message.Actions);

        _Message_Send(L_TM_Message)
    }
    catch (ex)
    {
        alert("Function: _PushMessage \nMsg: " + ex);
    }
}