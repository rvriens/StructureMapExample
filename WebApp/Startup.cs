using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Responses;
using Google.Apis.Util.Store;
using Microsoft.Owin;
using Microsoft.Owin.Security.Google;
using Owin;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

[assembly: OwinStartupAttribute(typeof(WebApp.Startup))]
namespace WebApp
{
    public partial class Startup {

        // The data store we use to save the user's access token once they log in.
        private IDataStore dataStore = new FileDataStore(GoogleWebAuthorizationBroker.Folder);

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

          
        }
    }
}
