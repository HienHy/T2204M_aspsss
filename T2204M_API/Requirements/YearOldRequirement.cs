﻿using System;
using Microsoft.AspNetCore.Authorization;
namespace T2204M_API.Requirements
{
	public class YearOldRequirement: IAuthorizationRequirement
	{
		public YearOldRequirement(int min , int max)
		{


			MinYear = min;
			MaxYear = max;

		}


		public int MaxYear { get; set; }
        public int MinYear { get; set; }

    }
}

