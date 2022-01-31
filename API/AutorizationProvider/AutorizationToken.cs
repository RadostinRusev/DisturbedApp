using AppsService.DTOs;
using AppsService.Implementation;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace API.AutorizationProvider
{
    public class AutorizationToken : OAuthAuthorizationServerProvider
    {
        UserManagmentService userManagmentService = new UserManagmentService();

        /*  UserVM loguser = responseData.Find(u => u.Name == model.Name &&
                                                                u.Password == model.Password);
  */

        //  UserRepository userRepository = new UserRepository();
        List<UserDTO> userdto = new List<UserDTO>();
        
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); 
        }
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            foreach (var item in userManagmentService.Get())
            {
                userdto.Add(new UserDTO
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            for (int i = 0; i < userdto.Count(); i++)
            {
                if (userdto[i].Name == context.UserName)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                    identity.AddClaim(new Claim("username", "user"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Hi User"));
                    context.Validated(identity);
                    break;
                }
                else if (context.UserName == "admin" && context.Password == "admin")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                    identity.AddClaim(new Claim("username", "admin"));
                    identity.AddClaim(new Claim(ClaimTypes.Name, "Hi Admin"));
                    context.Validated(identity);
                    break;
                }            
                else
                {                  
                    continue;
                }
            }
            
            return;



           
        }
    }
}