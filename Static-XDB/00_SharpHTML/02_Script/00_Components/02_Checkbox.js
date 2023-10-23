

function _SharpHTML_Checkbox_Change(P_Component)
{
    try
    {
        var L_Value = P_Component.getAttribute("Value");

        if (L_Value == "1")
        {
            P_Component.setAttribute("Value", "0");
        }
        else
        {
            P_Component.setAttribute("Value", "1");
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}
