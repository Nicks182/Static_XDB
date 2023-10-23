

function _Projects_Show_Info()
{
    try
    {
        const L_Component = document.getElementById("Div_Projects_Edit");
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
        alert("Function: _Projects_Show_Info \nMsg: " + ex);
    }
}
