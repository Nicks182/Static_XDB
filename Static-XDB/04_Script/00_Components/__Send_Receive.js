

function _Message_Send(P_TM_Message)
{
    try
    {
        _Busy_Show();
        window.external.sendMessage(JSON.stringify(P_TM_Message));
    }
    catch (ex)
    {
        _Busy_Hide();
        alert("Function: _Message_Send \nMsg: " + ex);
    }
}

function _Message_Receive(P_TM_Message)
{
    try
    {
        var L_TM_Message = JSON.parse(P_TM_Message);
        console.log(L_TM_Message);
        _UpdatePage(L_TM_Message);

        _SharpHTML_ProcessActions(L_TM_Message.Actions);

        switch (L_TM_Message.Message_Type)
        {
            case "Init":
                break;

            case "ShowMessage":
                console.log(L_TM_Message.Data);
                break;

            case "ProgressUpdate":
                //console.log(L_TM_Message);
                break;
        }
        _Busy_Hide();
    }
    catch (ex)
    {
        _Busy_Hide();
        alert("Function: _Message_Receive \nMsg: " + ex);
    }
}

function _UpdatePage(P_TM_Message)
{
    try
    {
        _SharpHTML_SetHTML(P_TM_Message.HTMLs);

    }
    catch (ex)
    {
        alert("Function: _UpdatePage \nMsg: " + ex);
    }
}