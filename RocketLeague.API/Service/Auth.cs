using RocketLeague.API.IService;
using System;
using System.Collections.Generic;
using System.Text;
using SteamAuth;
using Newtonsoft.Json.Linq;
using RocketLeague.API.Utilities;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace RocketLeague.API.Service
{
    public class Auth : IAuth
    {
        private ServiceRequestHelper _serviceRequestHelper;
        public Auth()
        {
            _serviceRequestHelper = new ServiceRequestHelper();
        }

        public UserLogin LoginOnSteam(UserLogin steamUser)
        {
            UserLogin user = steamUser;
            user.DoLogin();
            return user;
        }

        public UserLogin LoginOnSteam(UserLogin steamUser, string TwoFactorAuthCode)
        {
            steamUser.TwoFactorCode = TwoFactorAuthCode.ToUpper();
            steamUser.DoLogin();
            return steamUser;
        }

        public void LoginOnRocketLeague(UserLogin steamUser)
        {
            dynamic data = new JObject();
            data.Service = "Auth/AuthPlayer";
            data.Version = 1;
            data.ID = 1;

            dynamic parameters = new JObject();
            parameters.Platform = "Steam";
            parameters.PlayerName = steamUser.Username;
            parameters.PlayerID = steamUser.Session.SteamID;
            parameters.Language = Costants.RLLanguage;
            parameters.AuthTicket = steamUser.Session.OAuthToken;
            parameters.BuildRegion = "";
            parameters.FeatureSet = Costants.RLFeatureSet;
            parameters.bSkipAuth = false;
            data.Params = parameters;

            var result = _serviceRequestHelper.RLPost(data);
        }
    }
}
