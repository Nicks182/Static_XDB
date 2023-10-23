

function _IgnoredObjects_Show_Info()
{
    try
    {
        const L_Component = document.getElementById("Div_IgnoredObjects_Body_Container");
        var L_IsHidden = parseInt(L_Component.getAttribute("IsHidden"));

        if (L_IsHidden == 1)
        {
            L_Component.setAttribute("IsHidden", "0");
        }
        else
        {
            L_Component.setAttribute("IsHidden", "1");
        }
    }
    catch (ex)
    {
        alert("Function: _IgnoredObjects_Show_Info \nMsg: " + ex);
    }
}

function _IgnoredObjects_Edit_Show_Info()
{
    try
    {
        const L_Component = document.getElementById("Div_IgnoredObjects_Edit");
        var L_IsHidden = parseInt(L_Component.getAttribute("IsHidden"));

        if (L_IsHidden == 1)
        {
            L_Component.setAttribute("IsHidden", "0");
        }
        else
        {
            L_Component.setAttribute("IsHidden", "1");
        }
    }
    catch (ex)
    {
        alert("Function: _IgnoredObjects_Edit_Show_Info \nMsg: " + ex);
    }
}
