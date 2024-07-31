using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace RentACar.Client.Utils
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService localStorageService;
        private readonly HttpClient client;
        private readonly AuthenticationState anonymous;
        //private readonly IsbaSatisDbContext context;

        public AuthStateProvider(ILocalStorageService LocalStorageService, HttpClient Client/*IsbaSatisDbContext _context*/)
        {
            //context = _context;
            localStorageService = LocalStorageService;
            client = Client;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            String apiToken = await localStorageService.GetItemAsStringAsync("token");

            if (String.IsNullOrEmpty(apiToken))
                return anonymous;


            String email = await localStorageService.GetItemAsStringAsync("email");
            //var userRoles = context.UserRoles.Include(c => c.Users).Where(c => c.Users.EMailAddress == email);
            //var claims = new List<Claim>();
            //claims.Add(new Claim(ClaimTypes.Email, email));
            //foreach (var item in userRoles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, item.RoleType.ToString()));
            //}

            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", apiToken);

            return new AuthenticationState(cp);
        }

        public void NotifyUserLogin(String email)
        {
            var cp = new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }, "jwtAuthType"));
            var authState = Task.FromResult(new AuthenticationState(cp));

            NotifyAuthenticationStateChanged(authState);
        }

        public void NotifyUserLogout()
        {
            var authState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authState);
        }
    }
}
