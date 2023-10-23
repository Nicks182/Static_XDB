
function _Screen_Show_Info()
{
    try
    {
        const L_Component = document.getElementById("Div_Screen");
        var L_IsHidden = parseInt(L_Component.getAttribute("ShowInfo"));

        if (L_IsHidden == 1)
        {
            L_Component.setAttribute("ShowInfo", "0");
        }
        else
        {
            L_Component.setAttribute("ShowInfo", "1");
        }
    }
    catch (ex)
    {
        alert("Function: _Screen_Show_Info \nMsg: " + ex);
    }
}

