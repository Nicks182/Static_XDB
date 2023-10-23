
namespace Services
{
    public class Srv_MessageBus
    {
        Dictionary<Srv_MessageBus_EventNames, List<Action<object>>> events = new Dictionary<Srv_MessageBus_EventNames, List<Action<object>>>();

        public void RegisterEvent(Srv_MessageBus_EventNames name, Action<object> eventHandler)
        {
            List<Action<object>> eventActions = new List<Action<object>>();
            if (events.ContainsKey(name))
            {
                eventActions = events[name];
            }
            eventActions.Add(eventHandler);

            events[name] = eventActions;
        }


        object sequence = "";
        public void Emit(Srv_MessageBus_EventNames eventName, object argument)
        {
            lock (sequence)
            {
                if (events.ContainsKey(eventName))
                {
                    
                    //Application.Current.Dispatcher.Invoke(() =>
                    //{
                        var eventActions = events[eventName];
                        eventActions.ForEach(x => x.Invoke(argument));
                    //});
                }
            }
        }

    }

    public enum Srv_MessageBus_EventNames
    {
        DoNothing,
        TransportMessage,
        ProgressUpdate,
        ProgressShow,
        ShowMessage,
        Cancel_Job,
    }
}
