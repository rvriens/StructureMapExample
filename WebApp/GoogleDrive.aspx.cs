using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth.OAuth2.Flows;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Google.Apis.Services;
using Google.Apis.Drive.v3;
using System.Text;

namespace WebApp
{
    public partial class GoogleDrive : System.Web.UI.Page
    {

        private readonly IDataStore dataStore = new FileDataStore(GoogleWebAuthorizationBroker.Folder);


        private async System.Threading.Tasks.Task<UserCredential> GetCredentialForApiAsync()
        {
            var initializer = new GoogleAuthorizationCodeFlow.Initializer
            {
                ClientSecrets = new ClientSecrets
                {
                    ClientId = Startup.GoogleSettings.ClientId,
                    ClientSecret = Startup.GoogleSettings.ClientSecret,
                },
                Scopes = Startup.GoogleSettings.Scopes,
            };
            var flow = new GoogleAuthorizationCodeFlow(initializer);

            var identity = await HttpContext.Current.GetOwinContext()
                .Authentication.GetExternalIdentityAsync(
                DefaultAuthenticationTypes.ApplicationCookie);
            var userId = identity.FindFirstValue("GoogleUserId");

            var token = await dataStore.GetAsync<Google.Apis.Auth.OAuth2.Responses.TokenResponse>(userId);
            
            return new UserCredential(flow, userId, token);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            var credential = GetCredentialForApiAsync();
            credential.Wait();

            var initializer = new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential.Result,
                ApplicationName = "TestApp",
            };
            var service = new DriveService(initializer);

            // Fetch the list of calendars.
            var fileListRequest = service.Files.List();
            fileListRequest.PageSize = 1000;

            var files = fileListRequest.Execute().Files;
            StringBuilder sb = new StringBuilder();

            foreach (var file in files)
            {
                sb.AppendLine(string.Format("{0}<br />", file.Name));
            }

            ltrFiles.Text = sb.ToString();

        }






    }
}