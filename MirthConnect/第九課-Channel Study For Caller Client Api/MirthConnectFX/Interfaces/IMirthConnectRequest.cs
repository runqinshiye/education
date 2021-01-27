namespace MirthConnectFX
{
    public interface IMirthConnectRequest
    {
        string AuthSessionId { get; set; }
        string ContentType { get; set; }

        IMirthConnectRequest ForOperation(string operation);
        IMirthConnectResponse Execute();
        IMirthConnectResponse ExecuteJustBody();
        IMirthConnectResponse ExecuteGet();
        IMirthConnectResponse ExecutePut();
        void AddPostData(string key, string value);
        void AddUrlData(string key, string value);
    }
}