
var G_Busy_Wait_Miliseconds = 100;
var G_Busy_Wait_Timeout = null;

function _Busy_Show()
{
    G_Busy_Wait_Timeout = setTimeout(function ()
    {
        document.getElementById("Busy_Modal").setAttribute("ishidden", "0");
    }, G_Busy_Wait_Miliseconds);
}


function _Busy_Hide()
{
    clearTimeout(G_Busy_Wait_Timeout);
    document.getElementById("Busy_Modal").setAttribute("ishidden", "1");
}