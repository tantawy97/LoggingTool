using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using System.Security.Claims;

namespace LoggingTool_Blazor
{
    public class CustomAuthorizationMessageHandler: AuthenticationStateProvider
    {

        private readonly ILocalStorageService localstorage;

        public CustomAuthorizationMessageHandler(ILocalStorageService localstorage)
        {
                this.localstorage = localstorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new System.Security.Claims.ClaimsPrincipal());
            string email = await localstorage.GetItemAsStringAsync("Email");
            if (!string.IsNullOrEmpty(email))
            {
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name,email)
                    }, "Test Authentication Type");
                state=new AuthenticationState(new ClaimsPrincipal(identity));
            }
            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
