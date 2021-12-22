
using System.Collections.Generic;
using UnityEngine.Analytics;

public class UnityAnalytiscTool : IAnalyticsTool
{
    public void SendMessage(string nameEvent)
    {
        Analytics.CustomEvent(nameEvent);
    }

    public void SendMessage(string nameEvent, (string key, object value) data)
    {
        var eventData = new Dictionary<string, object>{[data.key] = data.value};
        Analytics.CustomEvent(nameEvent, eventData);
    }
}
