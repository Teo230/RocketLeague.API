using SteamAuth;
using System;

namespace RocketLeague.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            API.IService.IAuth auth = new API.Service.Auth();

            UserLogin steamUser = new UserLogin("","");
            steamUser = auth.LoginOnSteam(steamUser);
            Console.WriteLine("Steam Code:");
            var code = Console.ReadLine();
            steamUser = auth.LoginOnSteam(steamUser, code);
            auth.LoginOnRocketLeague(steamUser);
        }
    }
}
