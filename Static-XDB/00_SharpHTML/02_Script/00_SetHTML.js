

function _SharpHTML_SetHTML(P_HTMLs)
{
    try
    {
        var L_Container = null;
        for (var i = 0; i < P_HTMLs.length; i++)
        {
            L_Container = document.getElementById(P_HTMLs[i].ContainerId);
            if (L_Container != null)
            {
                if (P_HTMLs[i].IsAppend == true)
                {
                    L_Container.innerHTML += P_HTMLs[i].HTML;
                }
                else
                {
                    L_Container.innerHTML = P_HTMLs[i].HTML;
                }
            }
        }
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}
