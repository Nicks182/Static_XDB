
namespace Services
{
    public class Srv_TimerManager
    {
        private System.Threading.Timer? G_Timer;
        private AutoResetEvent? G_AutoResetEvent;
        private Action? G_Action;
        public bool IsTimerStarted { get; set; }
        public void PrepareTimer(Action P_Action)
        {
            PrepareTimer(P_Action, 500, 30);
        }
        public void PrepareTimer(Action P_Action, int P_StartDelay, int P_Rate)
        {
            StopTimer();
            if (IsTimerStarted == false)
            {
                G_Action = P_Action;
                G_AutoResetEvent = new AutoResetEvent(false);
                G_Timer = new System.Threading.Timer(Execute, G_AutoResetEvent, P_StartDelay, P_Rate);
                IsTimerStarted = true;
            }
        }
        public void Execute(object? stateInfo)
        {
            G_Action();
        }

        public void StopTimer()
        {
            if (IsTimerStarted == true)
            {
                G_Timer.Dispose();
                G_Action = null;
                IsTimerStarted = false;
            }
        }
    }
}
