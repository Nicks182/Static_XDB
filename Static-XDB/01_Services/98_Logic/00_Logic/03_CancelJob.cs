
using Services.DB;
using SharpHTML;
using Static_XDB.HTML;

namespace Services
{
    public partial class Srv_Logic
    {
        
        private void _ProgressCancel()
        {
            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.Cancel_Job, "Cencelled!");
        }

    }
    
}
