

function _SharpHTML_Action_SetValue(P_Action)
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
                    _SharpHTML_Action_SetValue_Textbox_Textarea(L_Component, P_Action.Value);
                    break;

                case 1: // Textarea
                    _SharpHTML_Action_SetValue_Textbox_Textarea(L_Component, P_Action.Value);
                    break;

                case 2: // Checkbox
                    _SharpHTML_Action_SetValue_Checkbox(L_Component, P_Action.Value);
                    break;

                case 3: // Button
                    _SharpHTML_Action_SetValue_Button(L_Component, P_Action.Value);
                    break;

                case 5: // Dropdown
                    _SharpHTML_Action_SetValue_Dropdown(L_Component, P_Action.Value);
                    break;

                case 6: // FolderBrowser
                    _SharpHTML_Action_SetValue_FolderBrowser(L_Component, P_Action.Value);
                    break;

                case 7: // Progressbar
                    _SharpHTML_Action_SetValue_Progressbar(L_Component, P_Action.Value);
                    break;

                case 8: // PlainText/Paragraph
                    _SharpHTML_Action_SetValue_Paragraph(L_Component, P_Action.Value);
                    break;
            }
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}


function _SharpHTML_Action_SetValue_Textbox_Textarea(P_Component, P_Value)
{
    try
    {
        P_Component.value = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}


function _SharpHTML_Action_SetValue_Checkbox(P_Component, P_Value)
{
    try
    {
        P_Component.setAttribute("Value", P_Value);
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_Action_SetValue_Button(P_Component, P_Value)
{
    try
    {
        P_Component.setAttribute("Value", P_Value);
        var L_Caption = P_Component.getElementsByTagName('label')[0];
        L_Caption.textContent = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_Action_SetValue_Dropdown(P_Component, P_Value)
{
    try
    {
        P_Component.setAttribute("Value", P_Value);
        var L_Caption = P_Component.getElementsByTagName('label')[0];
        L_Caption.textContent = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_Action_SetValue_FolderBrowser(P_Component, P_Value)
{
    try
    {
        P_Component.setAttribute("Value", P_Value);
        var L_Caption = P_Component.getElementsByTagName('label')[0];
        L_Caption.textContent = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_Action_SetValue_Progressbar(P_Component, P_Value)
{
    try
    {
        P_Component.setAttribute("Value", P_Value);
        P_Component.setAttribute("style", "--ProgressbarWidth: " + P_Value + ";");

        var L_Text = P_Component.getElementsByTagName('label')[0];
        L_Text.textContent = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}

function _SharpHTML_Action_SetValue_Paragraph(P_Component, P_Value)
{
    try
    {
        P_Component.textContent = P_Value;
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}