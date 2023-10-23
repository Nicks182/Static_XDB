
//function _Modal_ShowHide(P_ModalId)
//{
//    _Modal_ShowHide(P_ModalId, 1);
//}


function _Modal_ShowHide(P_ModalId, P_RemoveOnClose)
{
    const L_Modal = document.getElementById(P_ModalId);
    var L_IsHidden = parseInt(L_Modal.getAttribute("IsHidden"));

    if (L_IsHidden == 0)
    {
        L_Modal.setAttribute("IsHidden", "1");
        if (P_RemoveOnClose == 1)
        {
            L_Modal.remove();
        }
    }
    else
    {
        L_Modal.setAttribute("IsHidden", "0");
        
    }
}