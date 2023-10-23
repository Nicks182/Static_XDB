
using System.Diagnostics;
using System.Xml.Serialization;

namespace Services
{
    public class Srv_Progress
    {
        Srv_MessageBus G_Srv_MessageBus;

        Srv_Progress_Info G_Progress_Info;

        Stopwatch G_Stopwatch;

        Srv_TimerManager G_Timer = null;

        int G_TotalSteps = 0;

        public Srv_Progress(Srv_MessageBus P_Srv_MessageBus, int P_TotalSteps)
        {
            G_TotalSteps = P_TotalSteps;
            G_Srv_MessageBus = P_Srv_MessageBus;
            G_Progress_Info = new Srv_Progress_Info
            {
                Text = "Starting...",
                Value = 0
            };

            G_Timer = new Srv_TimerManager();
        }

        public void _SetProgress(double P_Value, string P_Text)
        {
            G_Progress_Info.Value = (P_Value / G_TotalSteps) * 100;
            G_Progress_Info.Text = P_Text;

            G_Progress_Info.ElapsedTime = G_Stopwatch.Elapsed;

            if(G_Progress_Info.Value > 99)
            {
                _Cancel();
            }

            _PushProgress();
        }

        public void _ShowProgress()
        {
            G_Stopwatch = new Stopwatch();
            G_Stopwatch.Start();
            G_Progress_Info.ElapsedTime = G_Stopwatch.Elapsed;
            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ProgressShow, G_Progress_Info);

            _Timer_Start();
        }

        public void _Cancel()
        {
            G_Progress_Info.ElapsedTime = G_Stopwatch.Elapsed;
            G_Stopwatch.Stop();
            G_Timer.StopTimer();

            _PushProgress();
        }

        private void _PushProgress()
        {
            G_Srv_MessageBus.Emit(Srv_MessageBus_EventNames.ProgressUpdate, G_Progress_Info);
        }

        private void _Timer_Start()
        {

            G_Timer.PrepareTimer(
                () => _Timer_Tick(), // Action
                1000, // Start Delay in ms
                1000); // Rate in ms
        }

        private void _Timer_Tick()
        {
            G_Progress_Info.ElapsedTime = G_Stopwatch.Elapsed;
            _PushProgress();
        }
    }

    public class Srv_Progress_Info
    {
        public double Value { get; set; }
        public string Text { get; set; }

        public TimeSpan ElapsedTime { get; set; }
    }
}
