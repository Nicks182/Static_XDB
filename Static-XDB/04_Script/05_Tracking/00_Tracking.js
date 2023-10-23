

function _Tracking_ViewDiff_ScrollChange(P_Sender)
{
    try
    {
        const L_DiffPanes = document.getElementsByClassName('ViewDiff_Body_DiffPane');
        for (var i = 0; i < L_DiffPanes.length; i++)
        {
            if (L_DiffPanes.item(i) != P_Sender)
            {
                if (L_DiffPanes.item(i).scrollTop != P_Sender.scrollTop)
                {
                    L_DiffPanes.item(i).scrollTop = P_Sender.scrollTop;
                }

                if (L_DiffPanes.item(i).scrollLeft != P_Sender.scrollLeft)
                {
                    L_DiffPanes.item(i).scrollLeft = P_Sender.scrollLeft;
                }
            }
        }
    }
    catch (ex)
    {
        alert("Function: _Tracking_ViewDiff_ScrollChange \nMsg: " + ex);
    }
}

