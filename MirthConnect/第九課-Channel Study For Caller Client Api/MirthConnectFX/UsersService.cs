using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MirthConnectFX
{
    public class UsersService : ServiceBase, IUserService
    {
        public UsersService(IMirthConnectRequestFactory mirthConnectRequestFactory) 
            : base(mirthConnectRequestFactory, new MirthConnectSession(string.Empty), "users") {}
        
        public IMirthConnectSession Login(string username, string password, string version)
        {
            var request = CreateRequest().ForOperation(Operations.User.Login);
            request.AddPostData("username", username);
            request.AddPostData("password", password);
            request.AddPostData("version", version);
            
            var response = request.Execute();
            var sessionCookie = response.Cookies.FirstOrDefault(x => x.Name == "JSESSIONID");

            return new MirthConnectSession(sessionCookie != null ? sessionCookie.Value : null);
        }
    }
}