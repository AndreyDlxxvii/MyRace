public interface IAnalyticsTool
{
    void SendMessage(string nameEvent);
    void SendMessage(string nameEvent, (string key, object value) data);
}
