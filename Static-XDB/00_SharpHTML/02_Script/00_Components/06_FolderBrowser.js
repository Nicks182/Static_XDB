

async function _SharpHTML_FolderBrowser_Show(P_Component)
{
    try
    {
        const dirHandle = await window.showDirectoryPicker();
        
        
    }
    catch (P_Ex)
    {
        _SharpHTML_LogError(P_Ex);
    }
}
