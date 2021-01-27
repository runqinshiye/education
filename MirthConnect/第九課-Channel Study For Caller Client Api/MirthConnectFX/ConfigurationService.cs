using MirthConnectFX.Model;
using MirthConnectFX.Utility;

namespace MirthConnectFX
{
    public class ConfigurationService : ServiceBase, IConfigurationService
    {
        public ConfigurationService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session) 
            : base(mirthConnectRequestFactory, session, "server") {}

        public string GetVersion()
        {
            var request = CreateRequest().ForOperation(Operations.Configuration.GetVerson);
            var response = request.ExecuteGet();

            return response.Content;
        }

        public void SetGlobalScripts(GlobalScripts scripts)
        {
            var request = CreateRequest().ForOperation(Operations.Configuration.SetGlobalScripts);
            request.AddPostData("scripts", scripts.ToXml());

            request.Execute();
        }

        public ServerConfiguration GetServerConfiguation()
        {
            var request = CreateRequest().ForOperation(Operations.Configuration.GetServerConfiguration);
            var response = request.Execute();

            return response.Content.ToObject<ServerConfiguration>();
        }
    }
}