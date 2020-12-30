using SteamAuth;
using System;
using System.Collections.Generic;
using System.Text;

namespace RocketLeague.API.IService
{
    public interface IAuth
    {
        UserLogin LoginOnSteam(UserLogin steamUser);
        UserLogin LoginOnSteam(UserLogin steamUser, string TwoFactorAuthCode);
        void LoginOnRocketLeague(UserLogin steamUser);
    }
}
