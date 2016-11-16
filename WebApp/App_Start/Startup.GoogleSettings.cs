using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp
{
    public partial class Startup
    {
        public  class GoogleSettings
        {
            public static string ClientId = "";
            public static string ClientSecret = "";

            public static string[] Scopes = new[] {
                "openid",
                "profile",
                "email",
                Google.Apis.Drive.v3.DriveService.Scope.DriveReadonly
            };

        }

    }
}