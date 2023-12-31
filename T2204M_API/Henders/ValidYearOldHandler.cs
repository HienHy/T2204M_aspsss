﻿using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using T2204M_API.Requirements;
namespace T2204M_API.Henders
{
	public class ValidYearOldHandler :AuthorizationHandler<YearOldRequirement>
	{
		public ValidYearOldHandler()
		{
		}




        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, YearOldRequirement requirement)
        {

            if (IsValidYearOLd(context.User, requirement))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }



            return Task.CompletedTask;
        }


        private bool IsValidYearOLd(ClaimsPrincipal user , YearOldRequirement requirement)
        {
            if(user == null)
            {
                return false;
            }



            var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);
            var _context = new T2204M_API.Entities.T2204mApiContext();
            var userData = _context.Users.Find(Convert.ToInt32(userId));
            if (userData == null || userData.Age == null) return false;
            if (userData.Age >= requirement.MinYear && userData.Age <= requirement.MaxYear)
                return true;
            return false;
        }
    }
}

