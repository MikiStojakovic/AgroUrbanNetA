using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ClaimsPrincipleExtensions
    {
        public static async Task<AppUser> GetUserByEmail(this UserManager<AppUser> userManager, ClaimsPrincipal user)
        {
            var result = await userManager.Users.FirstOrDefaultAsync(x => x.Email == user.GetEmail());

            if (result == null) throw new AuthenticationException("User not found");

            return result;
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            var email = user.FindFirstValue(ClaimTypes.Email) ?? throw new AuthenticationException("Email not found");
            return email;
        }
    }
}