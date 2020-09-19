using DevOne.Security.Cryptography.BCrypt;
using Microsoft.Owin.Security.OAuth;
using MobileNotificationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace MobileNotificationService.Providers
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            using (var ctx = new DatabaseContext())
            {
                var username = context.UserName.Split(' ')[0];
                var systemId = context.UserName.Split(' ')[1];
                var user = ctx.Users.SingleOrDefault(w => w.Username == username);
                if (user != null && BCryptHelper.CheckPassword(context.Password, user.PasswordHash) && user.SystemId.ToString() == systemId)
                {
                    var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Username));
                    identity.AddClaim(new Claim("SystemID", user.SystemId.ToString()));
                    identity.AddClaim(new Claim(ClaimTypes.Role, user.Role));
                    context.Validated(identity);
                }
                else
                {
                    context.SetError("Invalid_grant", "wrong credentials");
                }

            }
        }

    }
}